using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecsHub.DTO.Request;
using RecsHub.DTO.Response;
using RecsHub.Helpers;
using RecsHub.Models;

namespace RecsHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<AccountController>
    {
        private readonly ITokenService _token;

        public AccountController(ITokenService token)
        {
            _token = token;
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            try
            {
                var rst = await _token.LoginAsync(login.Email, login.Password);
                return Ok(rst);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex.Message);
            }

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest register)
        {
            try
            {
                var rst = await _token.RegisterAsync(register.Email, register.Password, register.FirstName, register.LastName, register.Phone, register.CompanyKey);
                return Ok(_mapper.Map<RegisterResponse>(rst));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex.Message);
            }

        }
    }
}
