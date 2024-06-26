using Project.Adopet.Console.Modelos;
using FluentResults;

namespace Project.Adopet.Console.Results;

public class SuccessWithClients : Success
{
    public SuccessWithClients(IEnumerable<Client> data, string message) : base(message)
    {
        Data = data;
    }

    public IEnumerable<Client> Data { get; }
}