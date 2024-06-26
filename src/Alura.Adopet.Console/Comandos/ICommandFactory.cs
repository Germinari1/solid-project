namespace Project.Adopet.Console.Comandos;
public interface ICommandFactory
{
    bool canCreateType(Type? cmdType);
    ICommand? CreateCommand(string[] arguments);
}
