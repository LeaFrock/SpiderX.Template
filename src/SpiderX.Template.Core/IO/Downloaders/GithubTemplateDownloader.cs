using System;
using System.IO;
using System.Threading.Tasks;

namespace SpiderX.Template.Core.IO.Downloaders
{
    public sealed class GithubTemplateDownloader : ITemplateDownloader
    {
        public Task<FileInfo> DownloadAsync(string commandName, string zipTemplateName, int version = 0)
        {
            throw new NotImplementedException();
        }
    }
}