namespace Project.Adopet.Console.Modelos;

public class Client
{
    public Client(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string? CPF { get; set; }

    public override string? ToString()
    {
        return $"{Id} - {Name} - {Email}";
    }
}