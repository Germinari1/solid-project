using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Servicos.Arquivos;

namespace Project.Adopet.Testes.Servicos;

public class fileReaderJsonTest : IDisposable
{
    private string filePath;
    public fileReaderJsonTest()
    {
        //Setup
        string content = @"
            [
              {
                ""Id"": ""68286fbf-f6f4-4924-adab-0637511813e0"",
                ""Name"": ""Mancha"",
                ""Tipo"": 1
              },
              {
                ""Id"": ""68286fbf-f6f4-4924-adab-0637511672e0"",
                ""Name"": ""Alvo"",
                ""Tipo"": 1
              },
              {
                ""Id"": ""68286fbf-f6f4-1234-adab-0637511672e0"",
                ""Name"": ""Pinta"",
                ""Tipo"": 1
              }
            ]
        ";

        string nomeRandomico = $"{Guid.NewGuid()}.json";

        File.WriteAllText(nomeRandomico, content);
        filePath = Path.GetFullPath(nomeRandomico);
    }

    [Fact]
    public void getValidListTest()
    {
        //Arrange            
        //Act
        var petList = new FileReaderJson<Pet>(filePath).performReading()!;
        //Assert
        Assert.NotNull(petList);
        Assert.IsType<List<Pet>?>(petList);
    }

    public void Dispose()
    {
        //ClearDown
        File.Delete(filePath);
    }
}