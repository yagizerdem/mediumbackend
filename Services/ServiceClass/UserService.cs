using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Entity;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utility.CustomExceptions;

namespace Services.ServiceClass
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        readonly SignInManager<AppUser> _signInManager;
        private readonly JWT _jwt;
        public UserService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            _signInManager = signInManager;
        }

        public async Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model)
        {
            try
            {
                AuthenticationModel authenticationModel;
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    //return new AuthenticationModel { IsAuthenticated = false, Message = $"No Accounts Registered with {model.Email}." };
                    throw new Exception($"No Accounts Registered with {model.Email}.");
                }

                if (await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);

                    authenticationModel = new AuthenticationModel
                    {
                        IsAuthenticated = true,
                        Message = jwtSecurityToken.ToString(),
                        UserName = user.UserName,
                        Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                    };
                    var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                    authenticationModel.Roles = rolesList.ToList();
                    return authenticationModel;
                }
                else
                {
                    //authenticationModel = new AuthenticationModel()
                    //{
                    //    IsAuthenticated = false,
                    //    Message = $"Incorrect Credentials for user {user.Email}."
                    //};
                    throw new Exception($"Incorrect Credentials for user {user.Email}.");
                }
            }
            catch (Exception ex)
            {
                throw new AuthenticationException(ex.Message);
            }


        }

        public async Task<string> RegisterAsync(RegisterModel model)
        {
            //ApplicationUser sınıfının instancesini alarak içerisini gelen modeldeki bilgilere göre doldurduk. Bu işlemi yapmamızın sebebi userManager sınıfı bizden parametre olarak bu modeli beklemektedir.
            try
            {
                var user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };


                var userWithSameEmail = await _userManager.FindByEmailAsync(model.Email);
                if (userWithSameEmail == null)
                {
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (!result.Succeeded)
                    {
                        var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                        throw new Exception(errors);
                    }

                    return $"User Registered {user.UserName}";
                }
                else
                {
                    throw new Exception($"Email {user.Email} is already registered.");
                }
            }
            catch (Exception ex)
            {
                throw new RegisterException(ex.Message);
            }
        }

        private async Task<JwtSecurityToken> CreateJwtToken(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

    }
}
