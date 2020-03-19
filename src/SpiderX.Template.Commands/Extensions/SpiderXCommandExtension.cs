using System.CommandLine;
using Microsoft.Extensions.Configuration;

namespace SpiderX.Template.Commands.Extensions
{
    public static class SpiderXCommandExtension
    {
        public static Command AddSpiderXCommand<TBuilder>(this Command command, IConfigurationRoot config) where TBuilder : ISpiderXCommandBuilder, new()
        {
            var builder = new TBuilder();
            var child = builder.Build(config);
            command.AddCommand(child);
            return command;
        }

        public static IConfiguration GetCmdSetting(this IConfigurationRoot root, string command)
        {
            return root.GetSection("CmdSettings")?.GetSection(command.ToUpper());
        }
    }
}