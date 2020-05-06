using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using MimeKit;

namespace RecsHub.Messages
{
    public class MessageService: IMessageService
    {
        private IHostEnvironment _env;

        public MessageService(IHostEnvironment env)
        {
            _env = env;
        }

        public async Task SendEmailAsync(string fromDisplayName, string fromEmailAddress, string toName, string toEmailAddress,
            string subject, string message, params Attachment[] attachments)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(fromDisplayName, fromEmailAddress));
            email.To.Add(new MailboxAddress(toName, toEmailAddress));
            email.Subject = subject;

            var body = new BodyBuilder
            {
                HtmlBody = message,
            };
            foreach (var attachment in attachments)
            {
                using (var stream = await attachment.ContentToStreamAsync())
                {
                    body.Attachments.Add(attachment.FileName, stream);
                }
            }

            email.Body = body.ToMessageBody();

            //email.Body = new TextPart(TextFormat.Html)
            //{
            //    Text = message
            //};

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Start of provider specific settings
                await client.ConnectAsync("smtp.gmail.com", 587, false).ConfigureAwait(false);
                await client.AuthenticateAsync("sylvesterchima11@gmail.com", "youagainhere12").ConfigureAwait(false);
                // End of provider specific settings

                await client.SendAsync(email).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }

        public async Task SendEmailToSupportAsync(string subject, string message)
        {
            await SendEmailAsync("Export Error Log", "sylvesterchima11@gmail.com", "Support", "sylvesterchima11@outlook.com", subject, message);
        }

        public async Task SendExceptionEmailAsync(Exception e, HttpContext context)
        {
            //var message = _viewRenderer.Render("Features/Messaging/Email/ExceptionEmail", new ExceptionModel(e, context));
            var dt = new ExceptionModel(e,context);
            var body = File.ReadAllText(Path.Combine(_env.ContentRootPath,"wwwroot\\exception.html"));


            StringBuilder sbHeader = new StringBuilder();
            sbHeader.Append("<tr>");
            foreach (var header in dt.Headers)
            {
                sbHeader.Append($"<td>{header.Key}</td><td>{header.Value}</td>");
            }
            sbHeader.Append("</tr>");

            StringBuilder sbExceptionData = new StringBuilder();
            sbHeader.Append("<tr>");
            foreach (DictionaryEntry data in dt.ExceptionData)
            {
                sbExceptionData.Append($"<td>{data.Key}</td><td>{data.Value}</td>");
            }
            sbExceptionData.Append("</tr>");

            StringBuilder sbFrames = new StringBuilder();
            foreach (var frame in dt.Frames)
            {
                var method = frame.GetMethod();

                var fullName = method.DeclaringType != null ? $"{method.DeclaringType.FullName}.{method.Name}" : method.Name;
                sbFrames.Append($"<div style=\"font-weight: bold;\">{fullName}</div><div style=\"padding-left: 20px; font-size: small;\">{frame}</div>");
            }

            StringBuilder sb = new StringBuilder(body);

            sb.Replace("{Time}", dt.Time);
            sb.Replace("{Message}", dt.Message);
            sb.Replace("{sbFrames}", sbFrames.ToString());
            sb.Replace("{StackTrace}", dt.StackTrace);
            sb.Replace("{Type}", dt.Type);
            sb.Replace("{HelpLink}", dt.HelpLink);
            sb.Replace("{HResult};", dt.HResult.ToString());
            sb.Replace("{InnerException}", dt.InnerException);
            sb.Replace("{Source}", dt.Source);
            sb.Replace("{TargetSite}", dt.TargetSite);
            sb.Replace("{Url}", dt.Url);
            sb.Replace("{UserName}", context.User.Identity.Name);
            sb.Replace("{sbHeader}", sbHeader.ToString());
            sb.Replace("{sbExceptionData};", sbExceptionData.ToString());

            await SendEmailToSupportAsync("Exception",sb.ToString());
        }
    }
}
