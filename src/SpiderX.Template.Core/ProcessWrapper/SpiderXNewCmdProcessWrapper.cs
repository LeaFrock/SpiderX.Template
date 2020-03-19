using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using SpiderX.Template.Common.Enums;
using SpiderX.Template.Common.Nuget;
using SpiderX.Template.Common.Process;
using SpiderX.Template.Core.ProcessWrapper.Callers;

namespace SpiderX.Template.Core.ProcessWrapper
{
    public sealed class SpiderXNewCmdProcessWrapper : SpiderXCmdProcessWrapper
    {
        public SpiderXNewCmdProcessWrapper(string projectName, string projectNamespace, IConfiguration config, ICmdProcessCaller caller = null)
        {
            if (config is null)
            {
                throw new ArgumentNullException();
            }
            if (string.IsNullOrEmpty(projectName))
            {
                throw new ArgumentNullException();
            }
            Caller = caller ?? new DotnetCmdProcessCaller();
            ProjectName = projectName;
            ProjectNamespace = projectNamespace;
            NugetPackageInfo = new NugetPackageInfo(config.GetSection("NugetPackageId").Value);
            CmdKey = config.GetSection(nameof(CmdKey)).Value;
        }

        protected override ICmdProcessCaller Caller { get; } = new DotnetCmdProcessCaller();

        public string ProjectName { get; }

        public NugetPackageInfo NugetPackageInfo { get; }

        public string CmdKey { get; }

        public string ProjectNamespace { get; set; }

        public DirectoryInfo OutputDirInfo { get; set; }

        public bool Force { get; set; }

        public override ResultCodeEnum Generate()
        {
            if (!OutputDirInfo.Exists)
            {
                OutputDirInfo.Create();
            }
            if (!Force)
            {
                if (!DotnetCmdProcessHelper.ExistTemplate(Caller, CmdKey) && !DotnetCmdProcessHelper.InstallTemplate(Caller, NugetPackageInfo))
                {
                    return ResultCodeEnum.TemplateInstallError;
                }
            }
            else
            {
                DotnetCmdProcessHelper.UninstallTemplate(Caller, NugetPackageInfo);
                if (!DotnetCmdProcessHelper.InstallTemplate(Caller, NugetPackageInfo))
                {
                    return ResultCodeEnum.TemplateInstallError;
                }
            }
            bool createOK = false;
            bool exeOk = DotnetCmdProcessHelper.Execute(Caller, $"new {CmdKey} -n {ProjectName} -ns {ProjectNamespace} -o {OutputDirInfo.FullName} --force", (sr) =>
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (!string.IsNullOrEmpty(str) && str.EndsWith("successfully."))
                    {
                        createOK = true;
                        break;
                    }
                }
            });
            return (exeOk && createOK) ? ResultCodeEnum.Success : ResultCodeEnum.Fail;
        }
    }
}