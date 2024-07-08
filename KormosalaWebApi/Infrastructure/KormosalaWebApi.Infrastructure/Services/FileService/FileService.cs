using KormosalaWebApi.Application.Services.FileService;
using KormosalaWebApi.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Infrastructure.Services.FileService
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                using FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(stream);
                await stream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<string> FileRenameAsync(string fileName, string path, bool first =true)
        {
            var extension = Path.GetExtension(fileName);
            string oldName = Path.GetFileNameWithoutExtension(fileName);
            string newFileName = $"{NameOperation.CharacterReplace(fileName)}{extension}";

            if (File.Exists($"{path}{newFileName}"))
            {
                await FileRenameAsync(path,newFileName, false);
            }
            else
            {
                return newFileName;    
            }
            return "";
        }

        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath,path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);


            List<(string fileName, string path)> datas = new();
            List<bool> results = new List<bool>();

            foreach (var file in files)
            {
                
                //todo Lesson 27

                //string newFileName = await FileRenameAsync(file.FileName);
                //var result = await CopyFileAsync($"{uploadPath}\\{newFileName}", file);
                //results.Add(result);
                //datas.Add((newFileName, $"{uploadPath}\\{newFileName}"));
            }

            if (results.TrueForAll(r=>r.Equals(true)))
            {
                return datas;
            }

            
            //todo Return error message!
            return null;
        }
    }
}
