namespace Store.AspProject.Services.Interfces
{
    public interface IEmailSenderService
    {

         Task SendEmail(string to,string subject,string body);
    }
}
