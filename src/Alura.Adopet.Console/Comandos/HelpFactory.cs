namespace Project.Adopet.Console.Comandos;
public class HelpFactory : ICommandFactory
{
    public bool canCreateType(Type? cmdType)
    {
        return cmdType?.IsAssignableTo(typeof(Help)) ?? false;
    }

    public ICommand? CreateCommand(string[] arguments)
    {
        var cmdToShow = arguments.Length == 2 ? arguments[1] : null;
        return new Help(cmdToShow);
    }
}
