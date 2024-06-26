using Project.Adopet.Console.Comandos;

namespace Project.Adopet.Testes.Comandos;

public class HelpTest
{
    [Fact]
    public async Task invalidCommandTest()
    {
        //Arrange
        var cmd = "Inválido";
        var help = new Help(cmd);
        //Act
        var result = await help.ExecAsync();
        //Assert
        Assert.NotNull(result);
        Assert.True(result.IsFailed);
    }

    [Theory]
    [InlineData("help")]
    [InlineData("show")]
    [InlineData("list")]
    [InlineData("import")]
    public async Task validCommandTest(string command)
    {

        //Arrange   
        var help = new Help(command);
        //Act
        var result = await help.ExecAsync();
        //Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
    }


}
