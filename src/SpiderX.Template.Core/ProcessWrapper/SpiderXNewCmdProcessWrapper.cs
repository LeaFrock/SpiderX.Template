using System.IO;
using SpiderX.Template.Common.Enums;
using SpiderX.Template.Common.IO.File;
using SpiderX.Template.Common.Process;
using SpiderX.Template.Core.ProcessWrapper.Callers;

namespace SpiderX.Template.Core.ProcessWrapper
{
    public sealed class SpiderXNewCmdProcessWrapper : SpiderXCmdProcessWrapper
    {
        public const string TemplateType = "spiderx";

        private SpiderXNewCmdProcessWrapper()
        {
        }

        public DirectoryInfo OutputDirInfo { get; private set; }

        public DirectoryInfo TemplateDirInfo { get; private set; }

        public string ProjectName { get; private set; }

        public string Namespace { get; private set; }

        public string ArgumentKey { get; private set; }

        public string ArgumentResult { get; private set; }

        protected override ICmdProcessCaller Caller { get; } = new DotnetCmdProcessCaller();

        public override ResultCodeEnum Generate()
        {
            if (!OutputDirInfo.Exists)
            {
                OutputDirInfo.Create();
            }
            if (!DotnetCmdProcessHelper.ReinstallTemplate(Caller, TemplateDirInfo, TemplateType, ArgumentKey, false))
            {
                return ResultCodeEnum.TemplateInstallError;
            }
            bool createOK = false;
            bool exeOk = DotnetCmdProcessHelper.Execute(Caller, $"new {ArgumentResult} --force -o {OutputDirInfo.FullName}", (sr) =>
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (!string.IsNullOrEmpty(str) && str.EndsWith("successfully."))
                    {
                        createOK = true;
                    }
                }
            });
            return (exeOk && createOK) ? ResultCodeEnum.Success : ResultCodeEnum.Fail;
        }

        public static SpiderXNewCmdProcessWrapper Create(DirectoryInfo templateDirInfo, DirectoryInfo outputDirInfo, string projectName, string @namespace)
        {
            if (templateDirInfo is null || !templateDirInfo.Exists)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(projectName))
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(@namespace))
            {
                return null;
            }
            string keyword = DotnetTemplateConfigHelper.GetCommandKey(templateDirInfo);
            if (string.IsNullOrEmpty(keyword))
            {
                return null;
            }
            return new SpiderXNewCmdProcessWrapper
            {
                TemplateDirInfo = templateDirInfo,
                OutputDirInfo = outputDirInfo,
                ProjectName = projectName,
                Namespace = @namespace,
                ArgumentKey = keyword,
                ArgumentResult = keyword + " -n " + projectName + " --ns " + @namespace
            };
        }
    }
}