using Project.Adopet.Console.Servicos.Abstracoes;
using Moq;

namespace Project.Adopet.Testes.Builder;

internal static class fileReaderMockBuilder
{
    public static Mock<IFileReader<T>> GetMock<T>(List<T> list)
    {
        var fileReader = new Mock<IFileReader<T>>(MockBehavior.Default
            );

        fileReader.Setup(_ => _.performReading()).Returns(list);

        return fileReader;
    }
}
