using Project.Adopet.Console.Comandos;

namespace Project.Adopet.Testes.Comandos;

public class CommandFactoryTest
{
    [Fact]
    public void checkTypeGivenParameterTest()
    {
        //Arrange
        string[] args = { "import", "lista.csv" };
        //Act
        var cmd = CommandsFactory.CreateCommand(args);
        //Assert
        Assert.IsType<Import>(cmd);
    }

    [Fact]
    public void checkTypeGivenParameterListTest()
    {
        //Arrange
        string[] args = { "list", "lista.csv" };
        //Act
        var cmd = CommandsFactory.CreateCommand(args);
        //Assert
        Assert.IsType<List>(cmd);
    }

    [Fact]
    public void checkTypeGivenInvalidParameterTest()
    {
        //Arrange
        string[] args = { "invalid", "lista.csv" };
        //Act
        var cmd = CommandsFactory.CreateCommand(args);
        //Assert
        Assert.Null(cmd);
    }

    [Fact]
    public void returnNullTest()
    {
        //Arrange           
        //Act
        var cmd = CommandsFactory.CreateCommand(null);
        //Assert
        Assert.Null(cmd);
    }

    [Fact]
    public void nullArrayAsParamTest()
    {
        //Arrange
        string[] args = { };
        //Act
        var cmd = CommandsFactory.CreateCommand(args);
        //Assert
        Assert.Null(cmd);
    }



}
