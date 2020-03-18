using System.IO;
using System.Threading.Tasks;

namespace SpiderX.Template.Core.IO.Downloaders
{
    public interface ITemplateDownloader
    {
        public Task<FileInfo> DownloadAsync(string commandName, string zipTemplateName, int version = 0);
    }
}