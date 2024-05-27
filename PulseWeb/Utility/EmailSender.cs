using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Drawing.Printing;

namespace PulseWeb.Utility
{
    // If you're using this code to work on your own project you have to place your sendgrid api key in appsettings.json
    // i.e
    // "ConnectionStrings": {
    //      "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=Pulse;Trusted_Connection=True;TrustServerCertificate=True;"
    //  },
    //  "SendGrid": {
    //      "SecretKey": "yourapikey"
    //  }
public class EmailSender : IEmailSender
    {
        public string SendGridSecret { get; set; }

        public EmailSender(IConfiguration _config)
        {
            SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // logic to send email
            var client = new SendGridClient(SendGridSecret);
            var from = new EmailAddress("no-reply@pulsetrackr.org", "Pulse");
            var to = new EmailAddress(email);
            var message = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

            return client.SendEmailAsync(message);
        }
    }
}
