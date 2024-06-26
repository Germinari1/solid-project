using Project.Adopet.Console.Servicos.Http;
using Project.Adopet.Console.Servicos.Arquivos;
using System.Reflection;
using Project.Adopet.Console.Extensions;

namespace Project.Adopet.Console.Comandos;

public static class CommandsFactory
{
    public static ICommand? CreateCommand(string[] arguments)
    {
        if ((arguments is null) || (arguments.Length == 0))
        {
            return null;           
        }
        var cmd = arguments[0];
        Type? returnedType = Assembly.GetExecutingAssembly().getCmdType(cmd);

        var factoryList = Assembly.GetExecutingAssembly().GetFactories();

        var factory = factoryList.FirstOrDefault(f => f!.canCreateType(returnedType));

        if (factory is null) return null;

        return factory.CreateCommand(arguments);

    }
}
