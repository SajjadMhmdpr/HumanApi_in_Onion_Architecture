using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.StaticFiles;


namespace Common.Extentions
{ 
    public static class Download
    {
        public static async  Task<FilePostDto?> DownloadImage(this string path,string env, FileExtensionContentTypeProvider fileProvider)
        {
            var file = new FilePostDto();

            var _path = env + path;

            if (!System.IO.File.Exists(_path))
            {
                return null;
            }

            file.bytes = await System.IO.File.ReadAllBytesAsync(_path);

            if (!fileProvider.TryGetContentType(_path, out var contentType))
            {
                contentType = "application/octet-steam";
            }

            file.contentType = contentType;
            file.fileName = Path.GetFileName(_path);

            return await Task.FromResult(file);
        }
    }
}
