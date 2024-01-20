using FullCart.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services.GlobalService
{
    public interface IUploadFileService
    {
        Task<IResponseDTO> UploadFile(string path, IFormFile file, bool deleteOldFiles = false);

    }
}
