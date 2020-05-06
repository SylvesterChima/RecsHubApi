using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.DTO.Response
{
    public class RegisterResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyKey { get; set; }
        public string Profile { get; set; }
    }
}
