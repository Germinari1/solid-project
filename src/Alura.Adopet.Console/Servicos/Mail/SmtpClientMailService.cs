
using Project.Adopet.Console.Servicos.Abstracoes;
using System.Net.Mail;

namespace Project.Adopet.Console.Servicos.Mail;
public class SmtpClientMailService : IMailService
{
    private readonly SmtpClient smtpClient;

    public SmtpClientMailService(SmtpClient smtpClient)
    {
        this.smtpClient = smtpClient;
    }

    public Task SendMailAsync(string to, string from, string title, string body)
    {
        MailMessage message = new()
        {
            From = new MailAddress(to),
            Subject = title,
            Body = body
        };
        message.To.Add(new MailAddress(from));
        smtpClient.Send(message);
        return Task.CompletedTask;
    }
}
