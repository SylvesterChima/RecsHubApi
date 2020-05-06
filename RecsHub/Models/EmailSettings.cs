using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.Models
{
    public class EmailSettings
    {

        public string MailSender { get; set; }
        public string SmptHost { get; set; }
        public int SmptPort { get; set; }
        public string SmptUsername { get; set; }
        public string SmtpPassword { get; set; }
        public bool SmtpEnableSsl { get; set; }
    }
}
