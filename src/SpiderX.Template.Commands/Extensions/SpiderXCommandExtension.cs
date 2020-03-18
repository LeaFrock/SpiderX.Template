using System.CommandLine;
using Microsoft.Extensions.Configuration;

namespace SpiderX.Template.Commands.Extensions
{
    public static class SpiderXCommandExtension
    {
        public static Command AddSpiderXCommand<TBuilder>(this Command command, IConfiguration config) where TBuilder : ISpiderXCommandBuilder, new()
        {
            var builder = new TBuilder();
            var child = builder.Build(config);
            command.AddCommand(child);
            return command;
        }
    }
}