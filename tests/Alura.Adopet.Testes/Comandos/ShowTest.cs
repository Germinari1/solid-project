using Project.Adopet.Console.Comandos;
using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Results;
using Project.Adopet.Testes.Builder;

namespace Project.Adopet.Testes.Comandos;

public class ShowTest
{
    [Fact]
    public async Task successMsgTest()
    {
        //Arrange
        List<Pet> listaDePet = new();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                          "Lima", TipoPet.Cachorro);
        listaDePet.Add(pet);
        var leitor = fileReaderMockBuilder.GetMock(listaDePet);
        leitor.Setup(_ => _.performReading());

        var show = new Show(leitor.Object);

        //Act
        var reosult = await show.ExecAsync();

        //Assert
        Assert.NotNull(reosult);
        var success = (SuccessWithPets)reosult.Successes[0];
        Assert.Equal("File displayed with success!",
            success.Message);
    }


}
