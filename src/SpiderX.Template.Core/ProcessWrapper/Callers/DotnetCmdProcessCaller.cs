using System.Diagnostics;
using SpiderX.Template.Common.Process;

namespace SpiderX.Template.Core.ProcessWrapper.Callers
{
    public sealed class DotnetCmdProcessCaller : ICmdProcessCaller
    {
        public Process Call(string init)
        {
            var psi = new ProcessStartInfo(DotnetCmdProcessHelper.FileName, init)
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = false
            };
            return Process.Start(psi);
        }
    }
}