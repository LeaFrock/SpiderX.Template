using System;
using System.IO;
using SpiderX.Template.Common.IO;

namespace SpiderX.Template.Core.IO
{
    public static class TemplateZipFileInstaller
    {
        public static DirectoryInfo DirInfo { get; } = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SpiderX", "Templates"));

        public static DirectoryInfo Install(string commandType, string template, int version = 0, bool force = false)
        {
            string versionDirPath = Path.Combine(DirInfo.FullName, commandType.ToUpper(), version.ToString());
            if (force)
            {
                string zipFilePath = Path.Combine(versionDirPath, template + ".zip");
                if (!File.Exists(zipFilePath))
                {
                    return null;
                }
                if (!Directory.Exists(versionDirPath))
                {
                    Directory.CreateDirectory(versionDirPath);
                }
                var dirInfo = new DirectoryInfo(Path.Combine(versionDirPath, template));
                if (dirInfo.Exists)
                {
                    dirInfo.Delete(true);
                }
                if (!IOStatic.TryExtractZipFile(zipFilePath, versionDirPath, false))
                {
                    return null;
                }
                return dirInfo;
            }
            else
            {
                var dirInfo = new DirectoryInfo(Path.Combine(versionDirPath, template));
                return dirInfo.Exists ? dirInfo : null;
            }
        }
    }
}