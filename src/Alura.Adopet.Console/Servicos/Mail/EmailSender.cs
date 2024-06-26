using Project.Adopet.Console.Results;
using Project.Adopet.Console.Servicos.Abstracoes;
using Project.Adopet.Console.Settings;
using FluentResults;
using System.Net;
using System.Net.Mail;

namespace Project.Adopet.Console.Servicos.Mail;
public static class EmailSender
{
    private static IMailService createMailService()
    {
        MailSettings settings = Configurations.MailSetting;
        SmtpClient smtp = new()
        {
            Host = settings.Server,
            Port = settings.Port,
            Credentials = new NetworkCredential(settings.Username, settings.Password),
            EnableSsl = true,
            UseDefaultCredentials = false
        };
        return new SmtpClientMailService(smtp);
    }

    public static void Send(Result result)
    {
        ISuccess? success = result.Successes.FirstOrDefault();
        if (success is null) return;
        if(success is SuccessWithPets sucesso)
        {
            var emailService = createMailService();
            emailService.SendMailAsync(
                from: "no-reply@adopet.com.br",
                title: $"[Adopet] {sucesso.Message}",
                body: $"{sucesso.Data.Count()} items were imported.",
                to: "system.adopet@gmail.com"
                );
        }
    }
}
