using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Servicos.Arquivos;

namespace Project.Adopet.Testes.Servicos;

public class FileReaderTest : IDisposable
{
    private string filePath;
    public FileReaderTest()
    {
        //Setup
        string line = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

        string randomName = $"{Guid.NewGuid()}.csv";

        File.WriteAllText(randomName, line);
        filePath = Path.GetFullPath(randomName);
    }

    [Fact]
    public void validFileTest()
    {
        //Arrange            
        //Act
        var petList = new PetsDoCsv(filePath).performReading()!;
        //Assert
        Assert.NotNull(petList);
        Assert.Single(petList);
        Assert.IsType<List<Pet>?>(petList);
    }

    [Fact]
    public void nonExistingFile()
    {
        //Arrange            
        //Act
        var petList = new PetsDoCsv("").performReading();
        //Assert
        Assert.Null(petList);
    }

    [Fact]
    public void nullFileTest()
    {
        //Arrange            
        //Act
        var petList = new PetsDoCsv(null).performReading();
        //Assert
        Assert.Null(petList);
    }

    public void Dispose()
    {
        //ClearDown
        File.Delete(filePath);
    }
}