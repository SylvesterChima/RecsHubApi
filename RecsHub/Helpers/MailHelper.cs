using Microsoft.Extensions.Configuration;
using RecsHub.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace RecsHub.Helpers
{
    public class MailHelper
    {
        private IConfiguration _config;
        EmailSettings emil;

        public MailHelper(IConfiguration config)
        {
            _config = config;
            emil = new EmailSettings();
            _config.Bind(nameof(EmailSettings), emil);
        }
        
        //public static void SendEmail(string to, string subject, string message)
        //{

        //    string email = EmailSettings.MailFromAddress;
        //    string password = EmailSettings.Password;
        //    string userName = EmailSettings.Username;

        //    var loginInfo = new NetworkCredential(userName, password);
        //    var msg = new System.Net.Mail.MailMessage();
        //    var smtpClient = new SmtpClient(EmailSettings.ServerName, EmailSettings.ServerPort);

        //    msg.From = new MailAddress(email);
        //    msg.To.Add(new MailAddress(to));
        //    msg.Subject = subject;
        //    msg.Body = message;
        //    msg.IsBodyHtml = true;
        //    smtpClient.EnableSsl = true;

        //    smtpClient.UseDefaultCredentials = false;
        //    smtpClient.Credentials = loginInfo;
        //    if (EmailSettings.WriteAsFile)
        //    {
        //        smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
        //        smtpClient.PickupDirectoryLocation = EmailSettings.FileLocation;
        //        smtpClient.EnableSsl = false;
        //    }


        //    smtpClient.Send(msg);

        //}

        //public static void SendEmail(string to, string subject, string message, Attachment attachment)
        //{

        //    string email = EmailSettings.MailFromAddress;
        //    string password = EmailSettings.Password;
        //    string userName = EmailSettings.Username;

        //    var loginInfo = new NetworkCredential(userName, password);
        //    var msg = new System.Net.Mail.MailMessage();
        //    var smtpClient = new SmtpClient(EmailSettings.ServerName, EmailSettings.ServerPort);

        //    msg.From = new MailAddress(email);
        //    msg.To.Add(new MailAddress(to));
        //    msg.Subject = subject;
        //    msg.Body = message;
        //    msg.IsBodyHtml = true;
        //    msg.Attachments.Add(attachment);
            
        //    smtpClient.EnableSsl = true;

        //    smtpClient.UseDefaultCredentials = false;
        //    smtpClient.Credentials = loginInfo;
        //    if (EmailSettings.WriteAsFile)
        //    {
        //        smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
        //        smtpClient.PickupDirectoryLocation = EmailSettings.FileLocation;
        //        smtpClient.EnableSsl = false;
        //    }


        //    smtpClient.Send(msg);

        //}

        //public static Task SendMailAsync(string to, string subject, string message)
        //{
        //    var loginInfo = new System.Net.NetworkCredential(EmailSettings.Username, EmailSettings.Password);
        //    var smtpClient = new SmtpClient(EmailSettings.ServerName, EmailSettings.ServerPort);
        //    smtpClient.EnableSsl = EmailSettings.UseSsl;
        //    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    smtpClient.UseDefaultCredentials = false;
        //    smtpClient.Credentials = loginInfo;

        //    var msg = new System.Net.Mail.MailMessage();
        //    msg.From = new MailAddress(EmailSettings.MailFromAddress);
        //    msg.To.Add(new MailAddress(to));
        //    //msg.Bcc.Add(EmailSettings.bcc);
        //    msg.Subject = subject;
        //    msg.Body = message;
        //    msg.IsBodyHtml = true;

        //    if (EmailSettings.WriteAsFile)
        //    {
        //        smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
        //        smtpClient.PickupDirectoryLocation = EmailSettings.FileLocation;
        //        smtpClient.EnableSsl = false;
        //    }

        //    var x = smtpClient.SendMailAsync(msg);


        //    return x;
        //}

        public bool sendMailWithAttachment(string destination, string body, string subject, string filePath)
        {
            try
            {
                var emails = destination.Split(',');
                MailMessage mail = new MailMessage();
                mail.To.Add(emails[0]);
                mail.From = new MailAddress(emil.MailSender, "Daily Sales");
                mail.Subject = subject;
                mail.Body = body;
                mail.Attachments.Add(new Attachment(filePath));
                mail.IsBodyHtml = true;
                if (emails.Count() > 1)
                {
                    foreach (var item in emails)
                    {
                        if (item.ToLower() != emails[0].ToLower())
                        {
                            mail.Bcc.Add(item);
                        }
                    }
                }
                var smtp = new SmtpClient
                {
                    Host = emil.SmptHost,
                    Port = emil.SmptPort,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(emil.SmptUsername, emil.SmtpPassword),
                    EnableSsl = emil.SmtpEnableSsl
                };
                smtp.Send(mail);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }




    //public class EmailSettings
    //{
    //    public static string MailFromAddress = ConfigurationManager.AppSettings["mailSender"];
    //    public static bool UseSsl = bool.Parse(ConfigurationManager.AppSettings["UseSsl"]);
    //    public static string Username = ConfigurationManager.AppSettings["UserName"];
    //    public static string Password = ConfigurationManager.AppSettings["mailPass"];
    //    public static string ServerName = ConfigurationManager.AppSettings["mailHost"];
    //    public static int ServerPort = int.Parse(ConfigurationManager.AppSettings["ServrPort"]);
    //    public static bool WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["WFile"]);
    //    public static string FileLocation = @"c:\MyTempEmails";
    //}




    //const String FROM = "SENDER@EXAMPLE.COM";   // Replace with your "From" address. This address must be verified.
    //      const String TO = "RECIPIENT@EXAMPLE.COM";  // Replace with a "To" address. If you have not yet requested
    //                                                  // production access, this address must be verified.

    //      const String SUBJECT = "Amazon SES test (SMTP interface accessed using C#)";
    //      const String BODY = "This email was sent through the Amazon SES SMTP interface by using C#.";

    //      // Supply your SMTP credentials below. Note that your SMTP credentials are different from your AWS credentials.
    //      const String SMTP_USERNAME = "YOUR_SMTP_USERNAME";  // Replace with your SMTP username. 
    //      const String SMTP_PASSWORD = "YOUR_SMTP_PASSWORD";  // Replace with your SMTP password.

    //      // Amazon SES SMTP host name.
    //      const String HOST = "email-smtp.us-east-1.amazonaws.com";

    //      // Port we will connect to on the Amazon SES SMTP endpoint. We are choosing port 587 because we will use
    //      // STARTTLS to encrypt the connection.
    //      const int PORT = 587;

    //      // Create an SMTP client with the specified host name and port.
    //      using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(HOST, PORT))
    //      {
    //          // Create a network credential with your SMTP user name and password.
    //          client.Credentials = new System.Net.NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

    //          // Use SSL when accessing Amazon SES. The SMTP session will begin on an unencrypted connection, and then 
    //          // the client will issue a STARTTLS command to upgrade to an encrypted connection using SSL.
    //          client.EnableSsl = true;

    //          // Send the email. 
    //          try
    //          {
    //              Console.WriteLine("Attempting to send an email through the Amazon SES SMTP interface...");
    //              client.Send(FROM, TO, SUBJECT, BODY);
    //              Console.WriteLine("Email sent!");
    //          }
    //          catch (Exception ex)
    //          {
    //              Console.WriteLine("The email was not sent.");
    //              Console.WriteLine("Error message: " + ex.Message);
    //          }
    //      }

}