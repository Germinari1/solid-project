using Project.Adopet.Console.Modelos;

namespace Project.Adopet.Console.Servicos.Arquivos;
public class ClientsFromCSV : FileReaderCsv<Client>
{
    public ClientsFromCSV(string filePath) : base(filePath)
    {
    }

    public override Client createLineFromCsv(string line)
    {
        string[] properties = line.Split(';');

        return new Client(
             id: Guid.Parse(properties[0]),
             name: properties[1],
             email: properties[2]
            );
    }
}
