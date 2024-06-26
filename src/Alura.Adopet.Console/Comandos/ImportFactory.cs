using Project.Adopet.Console.Servicos.Arquivos;
using Project.Adopet.Console.Servicos.Http;
using Project.Adopet.Console.Servicos.Mail;
using Project.Adopet.Console.Settings;

namespace Project.Adopet.Console.Comandos;
public class ImportFactory: ICommandFactory
{
    public bool canCreateType(Type cmdType)
    {
        return cmdType?.IsAssignableTo(typeof(Import)) ?? false;
    }

    public ICommand? CreateCommand(string[] arguments)
    {
        var httpClientPet = new PetService(new APIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        var fileReader = fileReaderFactory.CreatePetFrom(arguments[1]);
        if (fileReader is null) { return null; }
        var import = new Import(httpClientPet, fileReader);
        import.afterExec += EmailSender.Send;
        return import;
    }
}
