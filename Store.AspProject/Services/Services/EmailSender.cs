using Microsoft.AspNetCore.Identity.UI.Services;
using Store.AspProject.Services.Interfces;
using System.Net.Mail;

namespace Store.AspProject.Services.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        public async Task SendEmail(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage()
            {
                Subject = subject,
                Body = body,
                From = new MailAddress("hamedpanahi03@gmail.com", "فروشگاه"),
                To = { to },
                IsBodyHtml = true

            };
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;

            SmtpServer.UseDefaultCredentials = false;

            SmtpServer.Credentials = new System.Net.NetworkCredential("hamedpanahi03@gmail.com", "johmqelqdhsrchrs");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            await Task.CompletedTask;
        }
    }
}
