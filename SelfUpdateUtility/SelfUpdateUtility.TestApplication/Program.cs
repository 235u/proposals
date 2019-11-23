using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using SelfUpdateUtility.Library;
using SelfUpdateUtility.TestApplication.Properties;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SelfUpdateUtility.TestApplication
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try
            {
                using (AmazonS3Client client = CreateClient())
                {
                    ProcessStartInfo startInfo = CreateStartInfo(args);
                    var form = new MainForm(args)
                    {
                        SelfUpdate = new SelfUpdate
                        {
                            Client = client,
                            StartInfo = startInfo,
                            FilesToUpdate = GetFilesToUpdate()
                        }
                    };

                    Application.Run(form);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MessageBoxCaption.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static AmazonS3Client CreateClient()
        {
            var credentials = GetCredentials();
            return new AmazonS3Client(credentials, RegionEndpoint.EUCentral1);
        }

        private static AWSCredentials GetCredentials()
        {
            return new BasicAWSCredentials(
                accessKey: "[access key]",
                secretKey: "[secret key]");
        }

        private static ProcessStartInfo CreateStartInfo(string[] args)
        {
            string fileName = GetCurrentProcessFileName();
            string arguments = string.Join(" ", args);
            return new ProcessStartInfo(fileName, arguments);
        }

        private static string GetCurrentProcessFileName()
        {
            return AppDomain.CurrentDomain.FriendlyName;
        }

        private static string[] GetFilesToUpdate()
        {
            return Settings.Default.FilesToUpdate.Split('/');
        }
    }
}
