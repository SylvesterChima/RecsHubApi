using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RecsHub.DTO;
using RecsHub.Models;
using RecsHub.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RecsHub.Helpers
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtSettings _jwt;
        public TokenService(UserManager<ApplicationUser> userManager, IOptions<JwtSettings> jwt, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _roleManager = roleManager;
        }

        public async Task<AuthResult> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new AuthResult
                {
                    Errors = new[] { "Invalid login attempt!" },
                    Success = false
                };  
            }
            var hasValidPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!hasValidPassword)
            {
                return new AuthResult
                {
                    Errors = new[] { "Invalid password or username!" },
                    Success = false
                };
            }
            return await GetAuth(user);
        }

        public async Task<ApplicationUser> RegisterAsync(string email, string password, string firstName, string lastName, string phone, string companyKey)
        {
            var imgUrl = @"\ImageFiles\defaultuser.png";

            var user = new ApplicationUser { UserName = email, Email = email, PhoneNumber = phone, FirstName = firstName, LastName = lastName, CompanyKey = companyKey, Profile = imgUrl, EmailConfirmed = true };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                
                var rst = await _roleManager.RoleExistsAsync("User");
                if (!rst)
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
                }
                await _userManager.AddToRoleAsync(user, "User");
            }
            return user;
        }

        private async Task<AuthResult> GetAuth(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwt.Secret);
            var claims = await GetValidClaims(user);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMonths(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthResult
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CompanyKey=user.CompanyKey,
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }

        private async Task<List<Claim>> GetValidClaims(ApplicationUser user)
        {
            IdentityOptions _options = new IdentityOptions();
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id),
            new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName)
        };
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            claims.AddRange(userClaims);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            return claims;
        }
    }
}
