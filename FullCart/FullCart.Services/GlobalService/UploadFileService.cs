using FullCart.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services.GlobalService
{
    public class UploadFileService :IUploadFileService
    {
        private readonly IConfiguration _configiuration;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IResponseDTO _response;

        public UploadFileService(
            IConfiguration configiuration,
            IHostingEnvironment hostingEnvironment,
            IResponseDTO response
            )
        {
            _configiuration = configiuration;
            _hostingEnvironment = hostingEnvironment;
            _response = response;
        }

        public async Task<IResponseDTO> UploadFile(string path, IFormFile file, bool deleteOldFiles = false)
        {
            if (file != null)
            {
                try
                {

                    if (!Directory.Exists($"{_hostingEnvironment.WebRootPath}\\{path}"))
                    {
                        Directory.CreateDirectory($"{_hostingEnvironment.WebRootPath}\\{path}");
                    }
                    else
                    {
                        if (deleteOldFiles)
                        {
                            Array.ForEach(Directory.GetFiles($"{_hostingEnvironment.WebRootPath}\\{path}"),
                                    delegate (string filePath) { File.Delete(filePath); });
                        }

                    }


                    using (FileStream filestream = File.Create($"{_hostingEnvironment.WebRootPath}\\{path}\\{file.FileName}"))
                    {
                        await file.CopyToAsync(filestream);
                        await filestream.FlushAsync();

                        var newFullPath = $"\\{path}\\{file.FileName}";

                        _response.Message = "Done";
                        _response.IsPassed = true;
                        _response.Data = newFullPath;

                    }
                }
                catch (Exception ex)
                {
                    _response.Message = ex.Message;
                    _response.Data = null;
                    _response.IsPassed = false;
                }
            }
            else
            {
                _response.Data = null;
                _response.Message = "Un_Successfull";
                _response.IsPassed = false;
            }

            return _response;

        }

    }
}
