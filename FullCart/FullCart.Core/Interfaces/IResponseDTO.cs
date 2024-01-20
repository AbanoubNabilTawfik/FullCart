using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Core.Interfaces
{
    public interface IResponseDTO
    {
        #region Public Properties
        bool IsPassed { get; set; }
        string? Message { get; set; }
        int TotalCount { get; set; }
        int TotalPageCount { get; set; }
        dynamic? Data { get; set; }
        #endregion
    }
}
