using System.CommandLine;
using Microsoft.Extensions.Configuration;

namespace SpiderX.Template.Commands
{
    public interface ISpiderXCommandBuilder
    {
        string ShortName { get; }

        Command Build(IConfigurationRoot config);
    }
}