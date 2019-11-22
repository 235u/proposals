using System;
using System.Diagnostics;
using System.IO;

namespace SelfUpdateUtility.Library
{
    public static class LocalTimestamp
    {
        private const string Path = "LastModified.txt";

        public static DateTime? GetUtcDateTime()
        {
            if (!File.Exists(Path))
            {
                return null;
            }

            string text = File.ReadAllText(Path);
            var timestamp = DateTimeOffset.Parse(text);
            return timestamp.DateTime;
        }

        public static void SetUtcDateTime(DateTime value)
        {
            Debug.Assert(value.Kind == DateTimeKind.Utc);
            var timestamp = new DateTimeOffset(value);
            var text = timestamp.ToString();
            File.WriteAllText(Path, text);
        }
    }
}
