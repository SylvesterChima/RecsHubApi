using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RecsHub.DTO;
using RecsHub.Helpers;
using RecsHub.Models;
using RecsHub.Options;

namespace RecsHub.Controllers
{
    public class AlexaController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwt;
        private readonly ITokenService _token;
        public AlexaController(UserManager<ApplicationUser> userManager, IOptions<JwtSettings> jwt, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, ITokenService token)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _token = token;
        }

        public IActionResult Error(string msg)
        {
            ViewBag.Error = msg;
            return View();
        }
        public IActionResult login(string ReturnUrl = null, string frm = null, string state = "")
        {
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.From = frm;
            ViewBag.State = state;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(LoginModel model)
        {
            ViewBag.ReturnUrl = model.ReturnUrl;
            //var result = await _signInManager.PasswordSignInAsync(model.Email, model.password, true, lockoutOnFailure: false);
            try
            {
                var rst = await _token.LoginAsync(model.Email, model.password);
                if (rst.Success)
                {
                    if (model.From.ToUpper() == "ALEXA")
                    {
                        return RedirectToAction("Token", new { usr = rst.Email, state = model.State });
                    }
                }
                else
                {
                    ViewBag.Msg = "Invalid login attempt!";
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { msg = ex.Message });
            }
            return View();
        }

        public async Task<IActionResult> Token(string usr = null, string state = "")
        {
            try
            {
                if (string.IsNullOrEmpty(usr))
                {
                    state = System.Net.WebUtility.UrlEncode(Request.Query["state"]);
                    return RedirectToAction("login", new { frm = "ALEXA", state });
                }
                var user = await _userManager.FindByEmailAsync(usr);
                var auth = await GetAuth(user);

                var amazonlink = "https://layla.amazon.com/spa/skill/account-linking-status.html?vendorId=M2N7OWX9Y30JJP";
                var accessToken = auth.Token; //((JObject)jsonResponse)["access_token"].ToString();

                var redirUrl = amazonlink + "#state=" + state.ToString() + "&access_token=" + System.Net.WebUtility.UrlEncode(accessToken) + "&token_type=Bearer";

                //amazon will make use of that bearer token
                return new RedirectResult(redirUrl);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { msg = ex.Message });
            }
        }


        private async Task<AuthResult> GetAuth(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwt.Secret);
            var claims = await GetValidClaims(user);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMonths(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthResult
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CompanyKey = user.CompanyKey,
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
            new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName),
            new Claim("firstname", user.FirstName),
            new Claim("lastname", user.LastName)
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