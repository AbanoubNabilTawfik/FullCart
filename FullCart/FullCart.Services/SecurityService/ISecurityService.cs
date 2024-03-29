﻿using FullCart.Core.Interfaces;
using FullCart.DTO.Security;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services.SecurityService
{
    public interface ISecurityService
    {
        Task<IResponseDTO> Register(string loggedInUserId, RegisterDto registerDto, IFormFile file);
        Task<IResponseDTO> Login(LoginDto loginDto);

    }
}
