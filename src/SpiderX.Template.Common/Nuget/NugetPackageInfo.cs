using System;

namespace SpiderX.Template.Common.Nuget
{
    public sealed class NugetPackageInfo
    {
        public NugetPackageInfo(string packageId)
        {
            Id = packageId ?? throw new ArgumentNullException();
        }

        public string Id { get; }

        public string Version { get; set; }
    }
}