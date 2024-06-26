using Project.Adopet.Console.Servicos.Http;
using Project.Adopet.Console.Settings;

namespace Project.Adopet.Console.Comandos;
public class ListFactory : ICommandFactory
{
    public bool canCreateType(Type? cmdType)
    {
        return cmdType?.IsAssignableTo(typeof(List)) ?? false;
    }

    public ICommand? CreateCommand(string[] arguments)
    {
        var httpClientPetList = new PetService(new APIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        return new List(httpClientPetList);
    }
}
