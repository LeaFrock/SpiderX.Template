using System;
using System.CommandLine;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SpiderX.Template.Commands.Builders;
using SpiderX.Template.Commands.Extensions;
using SpiderX.Template.Common.Enums;

namespace SpiderX.Template
{
    internal class Program
    {
        private static async Task<int> Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var rootCmd = new RootCommand() { TreatUnmatchedTokensAsErrors = true, Name = "spiderx" };
            rootCmd.AddSpiderXCommand<SpiderXNewCommandBuilder>(config);
            int result = await rootCmd.InvokeAsync(args);
            Console.WriteLine((ResultCodeEnum)result);
            Console.ReadKey();
            return result;
        }
    }
}