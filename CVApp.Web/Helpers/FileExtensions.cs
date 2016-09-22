using CVApp.Web.Models;
using System.IO;
using System.Web;

namespace CVApp.Web.Helpers
{
    public static class FileExtensions
    {
        public static void SetContentOfFile(this Candidate fileEntity, HttpPostedFileBase file)
        {
            using (var stream = new MemoryStream())
            {
                var fileStream = file.InputStream;
                fileStream.CopyTo(stream);
                fileEntity.ResumeFile = stream.ToArray();
            }
        }
    }
}