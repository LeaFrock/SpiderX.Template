using System;
using System.IO;

namespace SpiderX.Template.Common.Process
{
    public static class DotnetCmdProcessHelper
    {
        public const string FileName = "dotnet";

        public static bool ReinstallTemplate(ICmdProcessCaller processCaller, DirectoryInfo templateDirInfo, string templateType, string keyword, bool force = false)
        {
            if (force)
            {
                if (!UninstallTemplate(processCaller, templateDirInfo))
                {
                    return false;
                }
            }
            else
            {
                if (ExistTemplate(processCaller, templateType, keyword))
                {
                    return true;
                }
            }
            return InstallTemplate(processCaller, templateDirInfo);
        }

        public static bool InstallTemplate(ICmdProcessCaller processCaller, DirectoryInfo templateDirInfo) => Execute(processCaller, "new -i " + templateDirInfo.FullName);

        public static bool UninstallTemplate(ICmdProcessCaller processCaller, DirectoryInfo templateDirInfo) => Execute(processCaller, "new -u " + templateDirInfo.FullName);

        public static bool ShowTemplateList(ICmdProcessCaller processCaller, string type) => Execute(processCaller, $"new --list --type {type}");

        public static bool ExistTemplate(ICmdProcessCaller processCaller, string type, string keyword)
        {
            bool result = false;
            Execute(processCaller, $"new --list --type {type}", (sr) =>
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (!string.IsNullOrEmpty(str) && str.Contains(keyword))
                    {
                        result = true;
                        break;
                    }
                }
            });
            return result;
        }

        public static bool Execute(ICmdProcessCaller processCaller, string command, Action<StreamReader> resultAction = null)
        {
            var process = processCaller.Call(command);
            if (process is null || process.StartInfo?.FileName != FileName)
            {
                return false;
            }
            Console.WriteLine($"{nameof(DotnetCmdProcessHelper)} executes 'dotnet {command}'");
            using (var sr = process.StandardOutput)
            {
                if (resultAction is null)
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
                else
                {
                    resultAction.Invoke(sr);
                }
            }
            Console.WriteLine($"{nameof(DotnetCmdProcessHelper)} runs {(process.ExitTime - process.StartTime).TotalMilliseconds.ToString()}ms");
            ProcessHelper.EnsureProcessExited(process);
            return true;
        }
    }
}