using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace HangFire.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Sender(string userId, string message)
        {
            //bu userId'e sahip kullanıcıyı bul ve email adresini bul

            string apiKey = _configuration.GetSection("APIs")["SendGridApi"];
            SendGridClient client = new SendGridClient(apiKey);
            EmailAddress from = new EmailAddress("capacitorkondansator@gmail.com", "Example User");
            var subject = "www.mysite.com Bilgilendirme";
            EmailAddress to = new EmailAddress("asansortakip@gmail.com", "Example User");
            //string plainTextContent = "";
            string htmlContent = $"<strong>{message}</strong>";
            SendGridMessage message2 = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            await client.SendEmailAsync(message2);
        }

        public async Task SendEmail(string email,string message)
        {
            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
            smtp.Port = int.Parse(_configuration["Mail:Port"]);
            smtp.EnableSsl = true;
            smtp.Host = _configuration["Mail:Host"];

            MailMessage mail = new();
            mail.To.Add(email);
            mail.Subject = "www.mysite.com Bilgilendirme";
            mail.Body = $"<strong>{message}</strong>";
            mail.From = new(_configuration["Mail:Username"], "Hangfire", Encoding.UTF8);
            await smtp.SendMailAsync(mail);
        }
    }
}
