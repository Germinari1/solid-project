namespace Project.Adopet.Console.Servicos.Abstracoes;
public interface IFileReader<T>
{
    IEnumerable<T> performReading();
}
