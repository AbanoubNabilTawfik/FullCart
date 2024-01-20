using AutoMapper;
using FullCart.Core.Enums;
using FullCart.Core.Interfaces;
using FullCart.Data.DbContexts;
using FullCart.Data.DbModels.SecuritySchema;
using FullCart.Data.DbModels.UserSchema;
using FullCart.DTO.Security;
using FullCart.Repositories.UOW;
using FullCart.Repositories.User;
using FullCart.Services.GlobalService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Services.SecurityService
{
    public class SecurityService:ISecurityService
    {
        private readonly IMapper _mapper;
        private readonly IResponseDTO _response;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IUploadFileService _uploadFilesService;
        private readonly IConfiguration _configuration;
        public SecurityService(
            IMapper mapper , 
            IResponseDTO response,
            IUnitOfWork<AppDbContext> unitOfWork,
            UserManager<ApplicationUser> userManager,
            IUserRepository userRepository,
            IUploadFileService uploadFilesService,
            IConfiguration configuration

            )
        {
            _mapper = mapper;
            _response = response;
            _unitOfWork = unitOfWork;
            _userManager=userManager;
            _userRepository=userRepository;
            _uploadFilesService=uploadFilesService;
            _configuration = configuration;
        }

        public async Task<IResponseDTO> Login(LoginDto loginDto)
        {
            try
            {

                var appUser = await _userManager.FindByEmailAsync(loginDto.Email);

                if (appUser == null)
                {
                    _response.Message = "Email is not found";
                    _response.IsPassed = false;
                    return _response;
                }

                var authorizedUserDto = _mapper.Map<AuthorizedUserDto>(appUser);

                if (appUser.ChangePassword)
                {
                    var resetPassToken = await _userManager.GeneratePasswordResetTokenAsync(appUser);
                    // encode the token
                    authorizedUserDto.Token = WebUtility.UrlEncode(resetPassToken);
                }
                else
                {
                    authorizedUserDto.Token = GenerateJSONWebToken(appUser);
                }

                var roles = await _userManager.GetRolesAsync(appUser);
                authorizedUserDto.Role = roles[0];
                _response.IsPassed = true;
                _response.Message = "You are logged in successfully.";
                _response.Data = authorizedUserDto;

                return _response;
            }
            catch (Exception)
            {

                throw;
            }       
        }
        private string GenerateJSONWebToken(ApplicationUser appUser)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim("userId", appUser.Id),
                    new Claim("FullName", $"{appUser.FirstName} {appUser.LastName}"),
                    new Claim("Email", appUser.Email),
                    new Claim("Phone", appUser.PhoneNumber?.ToString()!),
                    new Claim("Role", appUser.UserRole.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, appUser.UserName)
                };


                IConfigurationSection? jwt = _configuration.GetSection("JWT");
                byte[]? key = Encoding.UTF8.GetBytes(jwt["Key"]);
                var tokenOptions = new JwtSecurityToken
                (
                    issuer: jwt["Issuer"],
                    audience: jwt["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(Convert.ToDouble(jwt["DurationInDays"])),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );
                string? token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return token;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IResponseDTO> Register(string loggedInUserId, RegisterDto registerDto, IFormFile file)
        {
			try
			{
                var user=await _userManager.FindByEmailAsync(registerDto.Email);
                if(user!=null)
                {
                    _response.IsPassed = true;
                    _response.Message = "User Already Exists";
                    _response.Data = user.Email;
                    return _response;
                }
                else
                {
                    if (_userRepository.Any(x =>x.FirstName == registerDto.FirstName && x.LastName == registerDto.LastName))
                    {
                        _response.IsPassed = false;
                        _response.Message = "User Already Exists";
                        _response.Data = user.Email;
                        return _response;
                    }
                    else
                    {
                        //create new user
                        if(registerDto.IsAdmin)
                        {
                            //create admin user
                            var appUser = _mapper.Map<ApplicationUser>(registerDto);
                            appUser.UserName = registerDto.Email;
                            appUser.ChangePassword = false;
                            appUser.CreatedBy = loggedInUserId;
                            appUser.CreatedOn = DateTime.Now;
                            IdentityResult result = await _userManager.CreateAsync(appUser, registerDto.Password);
                            if (!result.Succeeded)
                            {
                                _response.IsPassed = false;
                                _response.Message = $"Code: {result.Errors.FirstOrDefault().Code}, \n Description: {result.Errors.FirstOrDefault().Description}";
                                return _response;
                            }
                            var path = $"\\Users\\User_{appUser.Id}";
                            if (file != null)
                            {
                                await _uploadFilesService.UploadFile(path, file, true);
                                appUser.PersonalImagePath = $"\\{path}\\{file.FileName}";
                            }

                            //Add admin Role
                            await _userManager.AddToRoleAsync(appUser, "Admin");

                            var adminUser = _mapper.Map<User>(appUser);
                            adminUser.LMD=DateTime.Now;
                            adminUser.AppUserId = appUser.Id;
                            adminUser.Status = (int)EnCustomerStatus.Active;

                            _userRepository.Add(adminUser);
                            await _unitOfWork.SaveAsync();

                            _response.IsPassed = true;
                            _response.Message = "Admin Created Successfully";
                            _response.Data = appUser.Email; 
                            return _response;


                        }
                        else
                        {
                            //create customer user
                            var appUser = _mapper.Map<ApplicationUser>(registerDto);
                            appUser.UserName = registerDto.Email;
                            appUser.ChangePassword = false;
                            appUser.CreatedBy = loggedInUserId;
                            appUser.CreatedOn = DateTime.Now;
                            IdentityResult result = await _userManager.CreateAsync(appUser, registerDto.Password);
                            if (!result.Succeeded)
                            {
                                _response.IsPassed = false;
                                _response.Message = $"Code: {result.Errors.FirstOrDefault().Code}, \n Description: {result.Errors.FirstOrDefault().Description}";
                                return _response;
                            }
                            var path = $"\\Admins\\Admin{appUser.Id}";
                            if (file != null)
                            {
                                await _uploadFilesService.UploadFile(path, file, true);
                                appUser.PersonalImagePath = $"\\{path}\\{file.FileName}";
                            }

                            //Add admin Role
                            await _userManager.AddToRoleAsync(appUser, "Customer");

                            var adminUser = _mapper.Map<User>(appUser);
                            adminUser.AppUserId = appUser.Id;
                            adminUser.LMD = DateTime.Now;
                            adminUser.Status = (int)EnCustomerStatus.Active;

                            _userRepository.Add(adminUser);
                            await _unitOfWork.SaveAsync();

                            _response.IsPassed = true;
                            _response.Message = "Customer Created Successfully";
                            _response.Data = appUser.Email;
                            return _response;
                        }
                    }
                }


			}
			catch (Exception)
			{

				throw;
			}        }
    }
}
