using Project.Adopet.Console.Servicos.Arquivos;
using Project.Adopet.Console.Servicos.Http;
using Project.Adopet.Console.Settings;

namespace Project.Adopet.Console.Comandos;
public class ImportClientsFactory : ICommandFactory
{
    public bool canCreateType(Type? cmdType)
    {
        return cmdType?.IsAssignableTo(typeof(ImportClients)) ?? false;
    }

    public ICommand? CreateCommand(string[] arguments)
    {
        var service = new ClientService(new APIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        var fileReaderClients = fileReaderFactory.CreateClienteFrom(arguments[1]);
        if (fileReaderClients is null) { return null; }
        return new ImportClients(service, fileReaderClients);
    }
}
