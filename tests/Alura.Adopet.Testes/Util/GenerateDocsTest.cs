using Project.Adopet.Console.Atributos;
using Project.Adopet.Console.Util;
using System.Reflection;

namespace Project.Adopet.Testes.Util;

public class GenerateDocsTest
{
    [Fact]
    public void getDictCommands()
    {
        //Arrange
        Assembly assemblyWithCmdType = Assembly.GetAssembly(typeof(DocCommandAttribute))!;

        //Act
        Dictionary<string, DocCommandAttribute> dict =
              SystemDocumentation.ToDictionary(assemblyWithCmdType);

        //Assert            
        Assert.NotNull(dict);
        Assert.NotEmpty(dict);
        Assert.Equal(6, dict.Count);

    }
}
