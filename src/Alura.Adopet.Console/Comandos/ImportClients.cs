using Project.Adopet.Console.Atributos;
using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Results;
using Project.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Project.Adopet.Console.Comandos;

[DocCommandAttribute(cmd: "import-clients",
       documentation: "- import-clients <FILE>: imports file of clients.")]
public class ImportClients : ICommand
{
    private IApiService<Client> apiService;
    private IFileReader<Client> leitorDeArquivo;

    public ImportClients(IApiService<Client> apiService, IFileReader<Client> leitor)
    {
        this.apiService = apiService;
        this.leitorDeArquivo = leitor;
    }

    public async Task<Result> ExecAsync()
    {
        try
        {
            var lista = leitorDeArquivo.performReading();
            foreach (var cliente in lista)
            {
                await apiService.CreateAsync(cliente);
            }
            return Result.Ok().WithSuccess(new SuccessWithClients(lista, "Succesfully imported"));
        }
        catch (Exception exception)
        {
            return Result.Fail(new Error("Import failed").CausedBy(exception));
        }
    }
}
