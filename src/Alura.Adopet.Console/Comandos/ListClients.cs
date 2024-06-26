using Project.Adopet.Console.Atributos;
using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Results;
using Project.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Project.Adopet.Console.Comandos;

[DocCommand(cmd: "list-clients", 
    documentation: "- list-clients:" +
    " displays the clients registered in database.")]
public class ListClients : ICommand
{
    private readonly IApiService<Client> service;

    public ListClients(IApiService<Client> service)
    {
        this.service = service;
    }
    public async Task<Result> ExecAsync()
    {
        try
        {
            IEnumerable<Client>? clients = await service.ListAsync();
            return Result.Ok().WithSuccess(new SuccessWithClients(clients, "Client listing succesfull."));
        }
        catch (Exception exception)
        {

            return Result.Fail(new Error("Listing failed.").CausedBy(exception));
        }
    }
}
