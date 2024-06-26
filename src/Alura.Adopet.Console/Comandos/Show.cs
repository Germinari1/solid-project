using Project.Adopet.Console.Servicos.Arquivos;
using Project.Adopet.Console.Atributos;
using Project.Adopet.Console.Results;
using FluentResults;
using Project.Adopet.Console.Servicos.Abstracoes;
using Project.Adopet.Console.Modelos;

namespace Project.Adopet.Console.Comandos
{
    [DocCommandAttribute(cmd: "show",
       documentation: "- show <FILE>: displays on terminal the imported file.")]
    public class Show:ICommand
    {
        private readonly IFileReader<Pet> reader;

        public Show(IFileReader<Pet> reader)
        {
            this.reader = reader;
        }

        public Task<Result> ExecAsync()
        {
            try
            {
               return this.displayFileContent(); 
            }
            catch (Exception exception)
            {
               return Task.FromResult(Result.Fail(new Error("Could not display file!").CausedBy(exception)));
            }
        }

        private Task<Result> displayFileContent()
        {           
            var list = reader.performReading();       
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithPets(list, "File displayed with success!")));

        }
    }
}
