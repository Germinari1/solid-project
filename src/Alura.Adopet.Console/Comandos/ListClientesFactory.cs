using Project.Adopet.Console.Servicos.Http;
using Project.Adopet.Console.Settings;

namespace Project.Adopet.Console.Comandos;
public class ListClientesFactory : ICommandFactory
{
    public bool canCreateType(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ListClients)) ?? false;
    }
    public ICommand? CreateCommand(string[] argumentos)
    {
        var clienteService = new ClientService(new APIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        return new ListClients(clienteService);
    }
}
