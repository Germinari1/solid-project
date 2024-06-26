namespace Project.Adopet.Console.Atributos;

[AttributeUsage(AttributeTargets.Class)]
public sealed class DocCommandAttribute : Attribute
{
    public DocCommandAttribute(string cmd, string documentation)
    {
        Cmd = cmd;
        Documentation = documentation;
    }

    public string Cmd { get; }
    public string Documentation { get; }
}
