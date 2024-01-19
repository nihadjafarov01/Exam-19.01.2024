using Microsoft.AspNetCore.Http;

namespace Exam5.Business.Helpers
{
    public static class FileSave
    {
        public static string SaveAndProvideName(this IFormFile file, string rootPath)
        {
            string filePath = Path.Combine("images", "instructors", file.FileName);

            using (FileStream fs = File.Create(Path.Combine(rootPath,filePath)))
            {
                file.CopyTo(fs);
            }
            return filePath;
        }
    }
}
