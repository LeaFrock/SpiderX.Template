using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using Microsoft.Extensions.Configuration;
using SpiderX.Template.Commands.Exceptions;
using SpiderX.Template.Commands.Extensions;
using SpiderX.Template.Core.ProcessWrapper;

namespace SpiderX.Template.Commands.Builders
{
    public sealed class SpiderXNewCommandBuilder : ISpiderXCommandBuilder
    {
        private IConfiguration setting;

        public string ShortName => "new";

        public Command Build(IConfigurationRoot config)
        {
            setting = config.GetCmdSetting(ShortName) ?? throw new SpiderXConfigCommandException(this);
            var child = new Command(ShortName, "Create new project")
            {
                new Option(new string[] { "--project", "-p" }, "Give the name of new project to be created") { Argument = new Argument<string>(){ Arity = ArgumentArity.ExactlyOne }, Required = true },
                new Option(new string[] { "--namespace", "-n" }, "Give the namespace of new project") { Argument = new Argument<string>(()=> config.GetSection("LocalSettings").GetSection("DefaultNamespace").Value) { Arity = ArgumentArity.ExactlyOne } },
                new Option(new string[] { "--version", "-v" }, "Select which version of template to apply") { Argument = new Argument<string>() },
                new Option(new string[] { "--output", "-o" }, "Set the output path of files") { Argument = new Argument<DirectoryInfo>(() => new DirectoryInfo(Directory.GetCurrentDirectory())) { Arity = ArgumentArity.ExactlyOne } },
                new Option(new string[] { "--force", "-f" }, "Update and use the latest template") { Argument = new Argument<bool>() { Arity = ArgumentArity.ZeroOrOne } },
            };
            child.TreatUnmatchedTokensAsErrors = true;
            child.Handler = CommandHandler.Create<string, string, string, DirectoryInfo, bool>(Generate);
            return child;
        }

        private int Generate(string project, string @namespace, string version, DirectoryInfo output, bool force)
        {
            var processWrapper = new SpiderXNewCmdProcessWrapper(project, @namespace, setting)
            {
                ProjectNamespace = @namespace,
                Force = force,
                OutputDirInfo = output,
            };
            processWrapper.NugetPackageInfo.Version = version;
            return (int)processWrapper.Generate();
        }
    }
}