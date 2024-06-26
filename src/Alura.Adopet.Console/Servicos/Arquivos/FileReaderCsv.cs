using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Servicos.Abstracoes;

namespace Project.Adopet.Console.Servicos.Arquivos;

public abstract class FileReaderCsv<T>: IFileReader<T>
{
    private string filePath;
    public FileReaderCsv(string filePath)
    {
        this.filePath = filePath;
    }

    public virtual IEnumerable<T> performReading()
    {
        if (string.IsNullOrEmpty(filePath))
        {
            return null;
        }
        List<T> list = new List<T>();
        using StreamReader sr = new StreamReader(filePath);
        while (!sr.EndOfStream)
        {
            string? line = sr.ReadLine();
            if (line is not null)
            {
                var obj = createLineFromCsv(line);
                list.Add(obj);
            }
        }
        return list;
    }

    public abstract T createLineFromCsv(string linha);
}
