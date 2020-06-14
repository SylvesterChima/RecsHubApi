using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string password { get; set; }
        public string ReturnUrl { get; set; }
        public string From { get; set; }
        public string State { get; set; }
    }
}
