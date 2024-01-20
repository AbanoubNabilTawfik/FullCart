using AutoMapper;
using FullCart.Data.DbModels.SecuritySchema;
using FullCart.Data.DbModels.UserSchema;
using FullCart.DTO.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services
{
    public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, RegisterDto>().ReverseMap();
            CreateMap<ApplicationUser, User>().ReverseMap();
            CreateMap<ApplicationUser, AuthorizedUserDto>().ReverseMap();


            

        }
    }
}
