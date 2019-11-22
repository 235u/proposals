using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SelfUpdateUtility.Library
{
    public sealed class SelfUpdate
    {
        private const string BucketName = "self-update-utility";
        private const string BucketObjectKey = "SelfUpdateUtility.zip";

        public AmazonS3Client Client { get; set; }

        public ProcessStartInfo StartInfo { get; set; }

        public string[] FilesToUpdate { get; set; }

        public async Task Push()
        {
            await UploadLatestFiles();
            await UpdateLocalTimestamp();
        }

        public async Task<bool> IsUpToDate()
        {
            DateTime? remoteTimestamp = await GetLastModifiedAsync();
            if (!remoteTimestamp.HasValue)
            {
                return true;
            }
            else
            {
                DateTime? localTimestamp = LocalTimestamp.GetUtcDateTime();
                if (!localTimestamp.HasValue)
                {
                    return false;
                }
                else
                {
                    return localTimestamp >= remoteTimestamp;
                }
            }
        }

        public async Task Pull()
        {
            using (GetObjectResponse response = await Client.GetObjectAsync(BucketName, BucketObjectKey))
            {
                RenameCurrentProcessFileName();
                UpdateLocalFiles(response);
            }

            Process.Start(StartInfo);
        }

        private async Task UploadLatestFiles()
        {
            Stream stream = GetInputStream();
            var request = new PutObjectRequest
            {
                BucketName = BucketName,
                Key = BucketObjectKey,
                ContentType = MediaTypeNames.Application.Zip,
                InputStream = stream
            };

            await Client.PutObjectAsync(request);
        }

        private Stream GetInputStream()
        {
            var stream = new MemoryStream();
            using (var archive = new ZipArchive(stream, ZipArchiveMode.Create, leaveOpen: true))
            {
                string processFileName = StartInfo.FileName;
                archive.CreateEntryFromFile(sourceFileName: processFileName, entryName: processFileName);

                string configurationFileName = processFileName + ".config";
                archive.CreateEntryFromFile(sourceFileName: configurationFileName, entryName: configurationFileName);

                foreach (string fileName in FilesToUpdate)
                {
                    archive.CreateEntryFromFile(sourceFileName: fileName, entryName: fileName);
                }
            }

            return stream;
        }

        private async Task UpdateLocalTimestamp()
        {
            GetObjectMetadataResponse metadata = await Client.GetObjectMetadataAsync(BucketName, BucketObjectKey);
            LocalTimestamp.SetUtcDateTime(metadata.LastModified);
        }

        private async Task<DateTime?> GetLastModifiedAsync()
        {
            try
            {
                GetObjectMetadataResponse response = await Client.GetObjectMetadataAsync(BucketName, BucketObjectKey);
                return response.LastModified;
            }
            catch (AmazonS3Exception ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        private void RenameCurrentProcessFileName()
        {
            string sourceFileName = StartInfo.FileName;
            string destinationFileName = sourceFileName.Replace(".exe", ".old.exe");
            if (File.Exists(destinationFileName))
            {
                File.Delete(destinationFileName);
            }

            File.Move(sourceFileName, destinationFileName);
        }

        private static void UpdateLocalFiles(GetObjectResponse response)
        {
            using (var archive = new ZipArchive(response.ResponseStream))
            {
                foreach (var entry in archive.Entries)
                {
                    entry.ExtractToFile(entry.FullName, overwrite: true);
                }
            }

            LocalTimestamp.SetUtcDateTime(response.LastModified);
        }
    }
}
