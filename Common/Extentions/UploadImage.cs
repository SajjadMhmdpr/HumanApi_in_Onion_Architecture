using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extentions
{
    public static class UploadImage
    {
        public static async Task<string> SaveImage(this IFormFile file, string env, string pooshe)
        {

            try
            {
                string path = env + "\\" + pooshe + "\\" + file.FileName;

                var f = System.IO.File.Create(path);
                await file.CopyToAsync(f);

                f.Close();

                path = path.Split("wwwroot")[1];

                return path;

            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}


//try
//{
//    foreach (var item in human.Images)
//    {
//        //human.ImageName = "\\Images\\" + item.FileName;
//        if (human.Images[0].Length > 0)
//        {
//            if (!Directory.Exists(_environment.WebRootPath + "\\Images"))
//            {
//                Directory.CreateDirectory(_environment.WebRootPath + "\\Images\\");
//            }
//            using (FileStream filestream = System.IO.File
//                .Create(_environment.WebRootPath + "\\Images\\" + item.FileName))
//            {
//                item.CopyTo(filestream);
//                filestream.Flush();
//                //  return "\\Upload\\" + objFile.files.FileName;
//            }
//        }
//    }
//}
//catch (Exception ex)
//{
//    throw;
//}