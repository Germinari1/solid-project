using Project.Adopet.Console.Servicos.Arquivos;

namespace Project.Adopet.Console.Comandos;
public class ShowFactory : ICommandFactory
{
    public bool canCreateType(Type? cmdType)
    {
        return cmdType?.IsAssignableTo(typeof(Show)) ?? false;
    }

    public ICommand? CreateCommand(string[] arguments)
    {
        var fileReaderShow = fileReaderFactory.CreatePetFrom(arguments[1]);
        if (fileReaderShow is null) { return null; }
        return new Show(fileReaderShow);
    }
}
