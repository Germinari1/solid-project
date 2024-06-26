using Project.Adopet.Console.Atributos;
using System.Reflection;

namespace Project.Adopet.Console.Util;

public class SystemDocumentation
{
    public static Dictionary<string, DocCommandAttribute> ToDictionary(Assembly assemblyComOTipoDocComando)
    {
        return assemblyComOTipoDocComando.GetTypes()
         .Where(t => t.GetCustomAttributes<DocCommandAttribute>().Any())
         .Select(t => t.GetCustomAttribute<DocCommandAttribute>()!)
         .ToDictionary(d => d.Cmd);
    }
}
