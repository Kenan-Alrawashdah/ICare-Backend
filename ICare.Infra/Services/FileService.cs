using ICare.Core.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;


namespace ICare.Infra.Services
{
    public class FileService : IFileService
    {
        public  int OneMBSize = 1024 * 1024;

        public  string _imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");

        public string _fielsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files");

        public  bool IsPicture(string fileName)
        {
            var ext = Path.GetExtension(fileName);
            List<string> supportedTypes = new List<string>() { ".jpg", ".jpeg", ".jfif", ".pjpeg", ".pjp", ".png", ".svg", ".webp" };
            if (supportedTypes.Contains(ext))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
     
        public  bool CheckPictureSizeInMB(long pictureLength, int maxSizeInMB)
        {
            if (pictureLength <= (OneMBSize * maxSizeInMB))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public  async Task SavePic(IFormFile file, string fileName)
        {

            Directory.CreateDirectory(_imagesFolder);
           

            var path = Path.Combine(_imagesFolder, fileName);

            //Saving the picture in the images folder
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }



        }

        public  async Task SaveFile(IFormFile file, string fileName, string folderName)
        {
            Directory.CreateDirectory(_fielsFolder);
            var folder = Path.Combine(_fielsFolder, folderName);
            Directory.CreateDirectory(folder);

            var path = Path.Combine(_fielsFolder, folderName, fileName);

            //Saving the picture in the images folder
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }



        }

        public  string GenerateFileName(string fileName)
        {
            var ext = Path.GetExtension(fileName);
            var randomName = Guid.NewGuid().ToString();
            return randomName + ext;
        }

    }
}
