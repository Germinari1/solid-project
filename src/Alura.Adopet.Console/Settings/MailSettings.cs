namespace Project.Adopet.Console.Settings;
public class MailSettings
{
    public const string EmailSection = "AdopetEmailConfiguration";
    public string? Server { get; set; }
    public int Port { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}
