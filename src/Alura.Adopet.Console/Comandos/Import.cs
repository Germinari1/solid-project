using Project.Adopet.Console.Atributos;
using FluentResults;
using Project.Adopet.Console.Results;
using Project.Adopet.Console.Servicos.Abstracoes;
using Project.Adopet.Console.Modelos;

namespace Project.Adopet.Console.Comandos
{
    [DocCommandAttribute(cmd: "import",
        documentation: "- import <FILE>: import a file of items.")]
    public class Import:ICommand,IAfterExec
    {
        private readonly IApiService<Pet> clientPet;

        private readonly IFileReader<Pet> reader;

        public Import(IApiService<Pet> clientPet, IFileReader<Pet> reader)
        {
            this.clientPet = clientPet;
            this.reader = reader;
        }

        public event Action<Result>? afterExec;

        public async Task<Result> ExecAsync()
        {
            return await this.importFilePetAsync();
        }

        private async Task<Result> importFilePetAsync()
        {
            try
            {
                var petList = reader.performReading();
                foreach (var pet in petList)
                {                       
                   await clientPet.CreateAsync(pet);               
                }
                var result = Result.Ok().WithSuccess(new SuccessWithPets(petList,"Operation successful"));
                afterExec?.Invoke(result);
                return result;
            }
            catch (Exception exception)
            {

                return Result.Fail(new Error("Operation failed").CausedBy(exception));
            }
            
            
            
            
        }
    }
}
