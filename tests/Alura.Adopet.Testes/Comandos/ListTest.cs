using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Results;
using Project.Adopet.Testes.Builder;

namespace Project.Adopet.Testes.Comandos;

public class ListTest
{
    [Fact]
    public async Task cmdListTest()
    {
        //Arrange
        List<Pet>? listaDePet = new();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                          "Lima", TipoPet.Cachorro);
        listaDePet.Add(pet);

        var httpClientPet = ApiServiceMockBuilder.GetMockList(listaDePet);

        //Act
        var retorn_val = await new Console.Comandos.List(httpClientPet.Object)
            .ExecAsync();

        //Assert
        var result = (SuccessWithPets)retorn_val.Successes[0];
        Assert.Single(result.Data);
    }


}
