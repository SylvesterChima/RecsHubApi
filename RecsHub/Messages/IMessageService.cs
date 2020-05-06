using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RecsHub.Messages
{
    public interface IMessageService
    {
        Task SendEmailAsync(string fromDisplayName, string fromEmailAddress, string toName, string toEmailAddress,
            string subject, string message, params Attachment[] attachments);

        Task SendEmailToSupportAsync(string subject, string message);
        Task SendExceptionEmailAsync(Exception e, HttpContext context);
    }
}
