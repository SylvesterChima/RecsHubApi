using RecsHub.DTO;
using RecsHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.Helpers
{
    public interface ITokenService
    {
        Task<ApplicationUser> RegisterAsync(string email, string password, string firstName, string lastName, string phone, string companyKey);
        Task<AuthResult> LoginAsync(string email, string password);
    }
}
