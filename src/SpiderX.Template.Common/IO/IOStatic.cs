using System;
using System.Diagnostics;
using System.IO.Compression;

namespace SpiderX.Template.Common.IO
{
    public static class IOStatic
    {
        public static bool TryExtractZipFile(string sourcePath, string targetPath, bool overwrite)
        {
            Console.WriteLine("Begin Extracting ZipFile: " + DateTime.Now.ToString("HH:mm:ss"));
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                ZipFile.ExtractToDirectory(sourcePath, targetPath, overwrite);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Abort Extracting ZipFile: {ex.Message}");
                return false;
            }
            finally
            {
                sw.Stop();
            }
            Console.WriteLine($"End Extracting ZipFile: {sw.ElapsedMilliseconds.ToString()}ms");
            return true;
        }
    }
}