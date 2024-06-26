using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Servicos.Arquivos;
using Moq;

namespace Project.Adopet.TestesIntegracao.Builder;

internal static class fileReaderMockBuilder
{
    public static Mock<FileReaderCsv<Pet>> GetMock(List<Pet> petList)
    {
        var reader = new Mock<FileReaderCsv<Pet>>(MockBehavior.Default,
            It.IsAny<string>());

        reader.Setup(_ => _.performReading()).Returns(petList);

        return reader;
    }
}
