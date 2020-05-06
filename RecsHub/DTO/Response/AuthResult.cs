using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.DTO
{
    public class AuthResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyKey { get; set; }
        public string Token { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
