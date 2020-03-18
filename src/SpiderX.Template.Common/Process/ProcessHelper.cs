using System;

namespace SpiderX.Template.Common.Process
{
    public static class ProcessHelper
    {
        public static void EnsureProcessExited(System.Diagnostics.Process cmd)
        {
            while (!cmd.HasExited)
            {
                try
                {
                    if (!cmd.WaitForExit(2 * 1000))
                    {
                        cmd.Kill();
                    }
                    Console.WriteLine($"[{nameof(EnsureProcessExited)}] exits: {cmd.ExitCode.ToString()}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{nameof(EnsureProcessExited)}] warns: {ex.Message}");
                }
                finally
                {
                    cmd.Dispose();
                }
            }
        }
    }
}