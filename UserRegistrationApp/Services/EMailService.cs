using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

public class EMailService
{
    private readonly IConfiguration _config;

    public EMailService(IConfiguration config)
    {
        _config = config;
    }

    public void SendEmail(string toEmail, string subject, string body)
    {
        var smtpSettings = _config.GetSection("Smtp");

        
        var smtpClient = new SmtpClient(smtpSettings["Host"])
        {
            Port = int.Parse(smtpSettings["Port"]),
            Credentials = new NetworkCredential(smtpSettings["UserName"], smtpSettings["Password"]),
            EnableSsl = bool.Parse(smtpSettings["EnableSSL"]) 
        };

        
        var mailMessage = new MailMessage
        {
            From = new MailAddress(smtpSettings["UserName"]), 
            Subject = subject,
            Body = body,
            IsBodyHtml = true 
        };

        mailMessage.To.Add(toEmail); 

      
        smtpClient.Send(mailMessage);
    }
}
