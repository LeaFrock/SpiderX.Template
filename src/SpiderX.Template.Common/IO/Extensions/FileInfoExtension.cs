using System.IO;

namespace SpiderX.Template.Common.IO.Extensions
{
    public static class FileInfoExtension
    {
        public static string GetFileNameWithoutExtension(this FileInfo fileInfo)
        {
            int index = fileInfo.Name.LastIndexOf('.');
            if (index <= 0)
            {
                return null;
            }
            return fileInfo.Name.Substring(0, index);
        }
    }
}