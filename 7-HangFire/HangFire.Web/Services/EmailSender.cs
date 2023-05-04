using SendGrid;
using SendGrid.Helpers.Mail;

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
            EmailAddress from = new EmailAddress("capacitorkondansator@gmail.con", "Example User");
            var subject = "www.mysite.com Bilgilendirme";
            EmailAddress to = new EmailAddress("asansortakip@gmail.com", "Example User");
            //string plainTextContent = "";
            string htmlContent = $"<strong>{message}</strong>";
            SendGridMessage message2 = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            await client.SendEmailAsync(message2);
        }
    }
}
