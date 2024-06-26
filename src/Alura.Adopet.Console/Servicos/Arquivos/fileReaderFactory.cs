using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Servicos.Abstracoes;

namespace Project.Adopet.Console.Servicos.Arquivos;
public static class fileReaderFactory
{
    public static IFileReader<Pet>? CreatePetFrom(string filePath)
    {
        var extension = Path.GetExtension(filePath);
        switch (extension)
        {
            case ".csv":
                return new PetsDoCsv(filePath);
            case ".json":
                return new FileReaderJson<Pet>(filePath);
            default: return null;
        }
    }

    public static IFileReader<Client>? CreateClienteFrom(string filePath)
    {
        var extension = Path.GetExtension(filePath);
        switch (extension)
        {
            case ".csv":
                return new ClientsFromCSV(filePath);
            case ".json":
                return new FileReaderJson<Client>(filePath);
            default: return null;
        }
    }
}
