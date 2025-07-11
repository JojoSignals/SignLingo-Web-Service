
using System.Net;
using System.Net.Mail;
using Domain.Shared.Services;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.Shared.Services.EmailSenderSevice;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration configuration;

    public EmailSender(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task SendEmailAsync(string receptor, string subject, string body)
    {
        var email = configuration.GetValue<string>("EMAIL_CONFIGURATION:EMAIL");
        var password = configuration.GetValue<string>("EMAIL_CONFIGURATION:PASSWORD");
        var host = configuration.GetValue<string>("EMAIL_CONFIGURATION:HOTS");
        var port = configuration.GetValue<int>("EMAIL_CONFIGURATION:PORT");

        var smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        
        smtpClient.Credentials = new NetworkCredential("diego44434@gmail.com", "kipf kzdp agxn dxzn");
        
        var message = new MailMessage(email!, receptor, subject, body);
        
        await smtpClient.SendMailAsync(message);
    }
}