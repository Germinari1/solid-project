using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Servicos.Arquivos;

namespace Project.Adopet.Testes.Servicos;

public class fileReaderFactoryTest
{
    [Fact]
    public void getCsvReaderTest()
    {
        // arrange
        string filePath = "pets.csv";

        // act
        var reader = fileReaderFactory.CreatePetFrom(filePath);

        // assert
        Assert.IsType<PetsDoCsv>(reader);
    }

    [Fact]
    public void getJsonReaderTest()
    {
        // arrange
        string filePath = "pets.json";

        // act
        var reasder = fileReaderFactory.CreatePetFrom(filePath);

        // assert
        Assert.IsType<FileReaderJson<Pet>>(reasder);
    }

    [Fact]
    public void invalidExtensionTest()
    {
        // arrange
        string filePath = "pets.xsl";

        // act
        var reader = fileReaderFactory.CreatePetFrom(filePath);

        // assert
        Assert.Null(reader);
    }
}