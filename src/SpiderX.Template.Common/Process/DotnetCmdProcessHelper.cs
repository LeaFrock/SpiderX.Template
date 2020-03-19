using System;
using System.Diagnostics;
using System.IO;
using SpiderX.Template.Common.Nuget;

namespace SpiderX.Template.Common.Process
{
    public static class DotnetCmdProcessHelper
    {
        public const string FileName = "dotnet";

        public const string DotnetTemplateType = "spiderx";

        public static bool InstallTemplate(ICmdProcessCaller processCaller, NugetPackageInfo packageInfo)
        {
            string command = "new -i " + packageInfo.Id + (string.IsNullOrEmpty(packageInfo.Version) ? null : ("::" + packageInfo.Version));
            bool instOK = true;
            bool exeOK = Execute(processCaller, command, (sr) =>
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (!string.IsNullOrEmpty(str) && str.Contains(": error "))
                    {
                        Console.WriteLine($"{nameof(InstallTemplate)} Error: {str}");
                        instOK = false;
                        break;
                    }
                }
            });
            return instOK && exeOK;
        }

        public static bool UninstallTemplate(ICmdProcessCaller processCaller, NugetPackageInfo packageInfo) => Execute(processCaller, "new -u " + packageInfo.Id);

        public static bool CheckTemplateUpdates(ICmdProcessCaller processCaller) => Execute(processCaller, "new --update-check");

        public static bool ApplyTemplateUpdates(ICmdProcessCaller processCaller) => Execute(processCaller, "new --update-apply");

        public static bool ShowTemplateList(ICmdProcessCaller processCaller, string type = DotnetTemplateType) => Execute(processCaller, $"new --list --type {type}");

        public static bool ExistTemplate(ICmdProcessCaller processCaller, string keyword, string type = DotnetTemplateType)
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
            Stopwatch sw = Stopwatch.StartNew();
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
            sw.Stop();
            Console.WriteLine($"{nameof(DotnetCmdProcessHelper)} runs {sw.ElapsedMilliseconds}ms");
            process.Dispose();
            return true;
        }
    }
}