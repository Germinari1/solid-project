using Project.Adopet.Console.Servicos.Abstracoes;
using System.Text.Json;

namespace Project.Adopet.Console.Servicos.Arquivos;
public class FileReaderJson<T>: IFileReader<T>
{
    private string filePath;
    public FileReaderJson(string filePath)
    {
        this.filePath = filePath;
    }
    
    public IEnumerable<T> performReading()
    {
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return JsonSerializer.Deserialize<IEnumerable<T>>(stream)??Enumerable.Empty<T>();
    }
}
