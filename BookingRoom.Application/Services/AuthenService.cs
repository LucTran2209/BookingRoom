using AutoMapper;
using BookingRoom.Application.Abstraction;
using BookingRoom.Application.Abstraction.ServiceInterfaces;
using BookingRoom.Application.Common.Constants;
using BookingRoom.Application.Common.Result;
using BookingRoom.Application.DependencyInjection.Options;
using BookingRoom.Application.Dtos.AuthenServiceDto;
using BookingRoom.Domain.Abstractions;
using BookingRoom.Domain.Entities;
using BookingRoom.Persistence.RepositoryInterface;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookingRoom.Application.Services
{
    public class AuthenService : BaseService, IAuthenService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly JwtConfig _jwtConfig;
        private readonly GoogleSettings _googleSettings;

        public AuthenService(IUnitOfWork unitOfWork, IMapper mapper,
                             IConfiguration configuration,
                             IUserRepository userRepository,
                             IRoleRepository roleRepository) : base(unitOfWork, mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _jwtConfig = configuration.GetSection(nameof(JwtConfig)).Get<JwtConfig>() ?? new JwtConfig();
            _googleSettings = configuration.GetSection(nameof(GoogleSettings)).Get<GoogleSettings>() ?? new GoogleSettings();
        }

        /// <summary>
        /// Register a new account
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        public async Task<ServiceResult> RegisterAsync(RegisterAsyncInputDto inputDto)
        {
            try
            {
                // Declarations Service Result
                ServiceResult result = new ServiceResult()
                {
                    Data = null,
                    StatusCode = HttpCodeConstant.Success,
                    DevMsg = "",
                    UserMsg = "",
                };

                bool IsSuccess = false;

                User user = _mapper.Map<User>(inputDto);
                user.Id = new Guid();
                user.CreatedDate = DateTime.Now;

                IsSuccess = _userRepository.Insert(user);

                if (IsSuccess) await _unitOfWork.SaveChangeAsync();

                return result;

            }
            catch (Exception ex)
            {
                return new ServiceResult()
                {
                    Data = null,
                    StatusCode = HttpCodeConstant.BadRequest,
                    DevMsg = ex.Message,
                    UserMsg = "",
                };
                throw;
            }
        }

        public Task<ServiceResult> LoginAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ExternalLoginByGoogleAccountAsync
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        public async Task<ServiceResult> ExternalLoginByGoogleAccountAsync(ExternalLoginByGoogleAccountAsyncInputDto inputDto)
        {
            try
            {
                // Declarations Service Result
                ServiceResult result = new ServiceResult()
                {
                    Data = null,
                    StatusCode = HttpCodeConstant.Success,
                    DevMsg = "",
                    UserMsg = "",
                };

                User user = new User();

                var payload = await VerifyGoogleToken(inputDto.IdToken ?? string.Empty);
                if (payload == null)
                {
                    result.StatusCode = HttpCodeConstant.BadRequest;
                    return result;
                }

                var info = new UserLoginInfo(inputDto.Provider ?? string.Empty, payload.Subject, "");
                user = await _userRepository.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    // Add new user
                    var newUser = new User
                    {
                        Id = new Guid(),
                        FirstName = payload.GivenName,
                        LastName = payload.FamilyName,
                        PhoneNumber = string.Empty,
                        Email = payload.Email,
                        UserName = payload.Name,
                        PasswordHash = GenerateRandomString(6),
                        DateOfBirth = DateTime.UtcNow,
                        Gender = true,
                        IsActive = true,
                        CreatedDate = DateTimeOffset.UtcNow,
                    };

                    bool IsSuccess = _userRepository.Insert(newUser);
                    if (IsSuccess) await _unitOfWork.SaveChangeAsync();
                    result.Data = await GenerateToken(newUser);
                    result.StatusCode = HttpCodeConstant.Success;
                }
                else
                {
                    result.Data = await GenerateToken(user);
                    result.StatusCode = HttpCodeConstant.Success;
                }

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Verify Google Token
        /// </summary>
        /// <param name="idToken"></param>
        /// <returns></returns>
        internal async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string idToken)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _googleSettings.ClientId ?? string.Empty }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
                return payload;
            }
            catch (Exception)
            {
                //log an exception
                throw new Exception();
            }
        }


        /// <summary>
        /// Generate Token Contains User's Infomation
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        internal async Task<string> GenerateToken(User user)
        {
            var userRoles = await _roleRepository.GetRolesByUserIdAsync(user.Id);

            var authClaims = new List<Claim>
            {
                new Claim(nameof(user.Id), user.Id.ToString()),                
                new Claim(nameof(user.FirstName), $"{user.FirstName} {user.LastName}" ),
                new Claim(nameof(user.PhoneNumber), user.PhoneNumber ),
                new Claim(nameof(user.DateOfBirth), user.DateOfBirth.ToString()),              
                new Claim(nameof(user.Gender), user.Gender ? "Male" : "FeMale"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret ?? string.Empty));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: _jwtConfig.ValidIssuer ?? string.Empty,
                audience: _jwtConfig.ValidAudience ?? string.Empty,
                authClaims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        internal string GenerateRandomString(int length)
        {
            const string chars = HelperConstant.RandomString;
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
