using Project.Adopet.Console.Comandos;
using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Results;
using Project.Adopet.Testes.Builder;
using Moq;

namespace Project.Adopet.Testes.Comandos;

public class ImportTest
{
    [Fact]
    public async void invalidEmptyListTest()
    {
        //Arrange
        List<Pet> petList = new();
        var fileReader = fileReaderMockBuilder.GetMock(petList);

        var httpClientPet = ApiServiceMockBuilder.GetMock<Pet>();

        var import = new Import(httpClientPet.Object, fileReader.Object);

        //Act
        await import.ExecAsync();

        //Assert
        httpClientPet.Verify(_ => _.CreateAsync(It.IsAny<Pet>()), Times.Never);
    }

    [Fact]
    public async Task nonExistingFileTest()
    {
        //Arrange
        List<Pet> petLis = new();
        var reasder = fileReaderMockBuilder.GetMock(petLis);
        reasder.Setup(_ => _.performReading()).Throws<FileNotFoundException>();

        var httpClientPet = ApiServiceMockBuilder.GetMock<Pet>();

        var import = new Import(httpClientPet.Object, reasder.Object);

        //Act
        var result = await import.ExecAsync();

        //Assert
        Assert.True(result.IsFailed);
    }

    [Fact]
    public async Task validImportTest()
    {
        //Arrange
        List<Pet> listaDePet = new();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                          "Lima", TipoPet.Cachorro);
        listaDePet.Add(pet);
        var leitorDeArquivo = fileReaderMockBuilder.GetMock(listaDePet);

        var httpClientPet = ApiServiceMockBuilder.GetMock<Pet>();

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

        //Act
        var resultado = await import.ExecAsync();

        //Assert
        Assert.True(resultado.IsSuccess);
        var sucesso = (SuccessWithPets)resultado.Successes[0];
        Assert.Equal("Lima", sucesso.Data.First().Nome);
    }



}
