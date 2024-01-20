using AutoMapper;
using FullCart.Core.Interfaces;
using FullCart.DTO.Security;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services.SecurityService
{
    public class SecurityService:ISecurityService
    {
        private readonly IMapper _mapper;
        private readonly IResponseDTO _response;
        public SecurityService(IMapper mapper , IResponseDTO response)
        {
            _mapper = mapper;
            _response = response;
        }
        public async Task<IResponseDTO> Register(int loggedInUserId, RegisterDto registerDto, IFormFile file)
        {
			try
			{
                return null;
			}
			catch (Exception)
			{

				throw;
			}        }
    }
}
