using Project.Adopet.Console.Atributos;
using Project.Adopet.Console.Comandos;
using System.Reflection;

namespace Project.Adopet.Console.Extensions;
public static class CommandsExtensions
{
    public static Type? getCmdType(this Assembly assembly,string cmd)
    {
        return assembly
            .GetTypes() // lista de tipos
                        // filtrar apenas os tipos concretos que são comandos
            .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(ICommand))) // ICommand command = t                                                                             
            .FirstOrDefault(t => t.GetCustomAttributes<DocCommandAttribute>()
            .Any(d => d.Cmd.Equals(cmd))); // recuperar apenas aquele que atende à instrução "cmd"
    }

    public static IEnumerable<ICommandFactory?> GetFactories(this Assembly assembly)
    {
        return assembly
            .GetTypes()
            // filtre os tipos concretos que implementam ICommandFactory
            .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(ICommandFactory)))
            // criar instâncias de cada fábrica (não é o ideal)
            .Select(f => Activator.CreateInstance(f) as ICommandFactory);
    }


}
