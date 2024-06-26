using Project.Adopet.Console.Comandos;
using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Servicos.Http;
using Project.Adopet.TestesIntegracao.Builder;

namespace Project.Adopet.TestesIntegracao;

public class ImportIntegrationTest
{

    [Fact]
    public async void QuandoAPIEstaNoArDeveRetornarListaDePet()
    {
        //Arrange
        var listaDePet = new List<Pet>();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
              "Lima", TipoPet.Cachorro); //"456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
        listaDePet.Add(pet);
        var leitorDeArquivo = fileReaderMockBuilder.GetMock(listaDePet);       
          var httpClientPet = new PetService(new APIClientFactory("https://localhost:7136").CreateClient("adopet"));
        var import = new Import(httpClientPet,leitorDeArquivo.Object);
         
        //Act
        await import.ExecAsync();
        
        //Assert
        var listaPet = await httpClientPet.ListAsync();
        Assert.NotNull(listaPet);
    }
}
