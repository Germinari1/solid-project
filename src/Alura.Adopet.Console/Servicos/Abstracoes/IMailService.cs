namespace Project.Adopet.Console.Servicos.Abstracoes;
public interface IMailService
{
    Task SendMailAsync(string from, string to,
        string title, string body);
}
