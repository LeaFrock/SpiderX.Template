using System;
using System.IO;
using System.Text.Json;

namespace SpiderX.Template.Common.IO.File
{
    public static class DotnetTemplateConfigHelper
    {
        public static string GetCommandKey(DirectoryInfo templateDirInfo)
        {
            var dirInfos = templateDirInfo.GetDirectories(".template.config", SearchOption.TopDirectoryOnly);
            if (dirInfos.Length != 1)
            {
                return null;
            }
            var jsonDirInfo = dirInfos[0];
            var jsonFiles = jsonDirInfo.GetFiles("template.json", SearchOption.TopDirectoryOnly);
            if (jsonFiles.Length != 1)
            {
                return null;
            }
            var jsonFile = jsonFiles[0];
            string result = null;
            try
            {
                result = GetCommandKeyFromTemplateJsonFile(jsonFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(DotnetTemplateConfigHelper)} [{nameof(GetCommandKey)}] warns: {ex.Message}");
            }
            return result;
        }

        private static string GetCommandKeyFromTemplateJsonFile(FileInfo file)
        {
            using var fileStream = file.OpenRead();
            using var jsonDoc = JsonDocument.Parse(fileStream);
            var rootElement = jsonDoc.RootElement;
            if (!rootElement.TryGetProperty("shortName", out var shortNameElement))
            {
                return null;
            }
            return shortNameElement.GetString();
        }
    }
}