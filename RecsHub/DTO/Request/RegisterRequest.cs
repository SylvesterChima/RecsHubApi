using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.DTO.Request
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string CompanyKey { get; set; }
    }
}
