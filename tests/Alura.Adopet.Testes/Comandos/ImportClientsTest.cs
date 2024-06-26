using Project.Adopet.Console.Comandos;
using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Results;
using Project.Adopet.Testes.Builder;

namespace Project.Adopet.Testes.Comandos;

public class ImportClientsTest
{
    [Fact]
    public async Task validFileWithClientsTest()
    {
        //Arrange
        List<Client> clientsList = new();
        var client = new Client(
            id: new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
            name: "Jeni Entity",
            email: "jeni@example.org"
        );
        clientsList.Add(client);

        var fileReader = fileReaderMockBuilder.GetMock(clientsList);

        var mockService = ApiServiceMockBuilder.GetMock<Client>();

        var import = new ImportClients(mockService.Object, fileReader.Object);

        //Act
        var result = await import.ExecAsync();

        //Assert
        Assert.True(result.IsSuccess);
        var success = (SuccessWithClients)result.Successes[0];
        Assert.Equal("Jeni Entity", success.Data.First().Name);
    }
}