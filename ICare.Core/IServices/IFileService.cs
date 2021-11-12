using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
    public interface IFileService
    {
        bool CheckPictureSizeInMB(long pictureLength, int maxSizeInMB);
        string GenerateFileName(string fileName);
        bool IsPicture(string fileName);
        Task SaveFile(IFormFile file, string fileName, string folderName);
        Task SavePic(IFormFile file, string fileName);
    }
}
