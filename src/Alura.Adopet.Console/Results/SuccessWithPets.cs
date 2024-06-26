using Project.Adopet.Console.Modelos;
using FluentResults;

namespace Project.Adopet.Console.Results;

public class SuccessWithPets : Success
{
    public IEnumerable<Pet> Data { get; }
    public SuccessWithPets(IEnumerable<Pet> data, string mensagem) : base(mensagem)
    {
        Data = data;
    }
}
