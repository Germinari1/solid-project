using Project.Adopet.Console.Servicos.Arquivos;

namespace Project.Adopet.Testes.Servicos;
public class CsvClientTest : IDisposable
{
    private readonly string filePath;

    public CsvClientTest()
    {
        //Setup
        string line = "456b24f4-19e2-0192-845d-4a80e8854a41;Mariana;mari@email.com;1121221";

        string randomName = $"{Guid.NewGuid()}.csv";

        File.WriteAllText(randomName, line);
        filePath = Path.GetFullPath(randomName);
    }

    [Fact]
    public void returnClientListTest()
    {
        //Arrange            
        //Act
        var list = new ClientsFromCSV(filePath).performReading()!;
        //Assert
        Assert.NotNull(list);
        Assert.Single(list);
    }

    public void Dispose()
    {
        File.Delete(filePath);
    }
}