using FullCart.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Core.Common
{
    public class ResponseDTO:IResponseDTO
    {
        public bool IsPassed { get; set; }
        public string? Message { get; set; }
        public int TotalCount { get; set; }
        public int TotalPageCount { get; set; }
        public dynamic? Data { get; set; }
    }
}
