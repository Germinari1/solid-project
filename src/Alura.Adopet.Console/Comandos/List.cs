using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Atributos;
using Project.Adopet.Console.Results;
using FluentResults;
using Project.Adopet.Console.Servicos.Abstracoes;

namespace Project.Adopet.Console.Comandos
{
    [DocCommandAttribute(cmd: "list",
      documentation: "- list: lists items stored in database.")]
    public class List: ICommand
    {
        private readonly IApiService<Pet> clientPet;

        public List(IApiService<Pet> clientPet)
        {
            this.clientPet = clientPet;
        }

        public Task<Result> ExecAsync()
        {
            return this.listDataAsync();
        }

        private async Task<Result> listDataAsync()
        {
            try
            {
                IEnumerable<Pet>? pets = await clientPet.ListAsync();               
                return Result.Ok().WithSuccess(new SuccessWithPets(pets,"Listing successful"));
            }
            catch (Exception exception)
            {

                return Result.Fail(new Error("Failure in listing operation").CausedBy(exception));
            }

        }

    }
}
