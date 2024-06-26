using Project.Adopet.Console.Atributos;
using Project.Adopet.Console.Util;
using Project.Adopet.Console.Results;
using FluentResults;
using System.Reflection;

namespace Project.Adopet.Console.Comandos
{
    [DocCommandAttribute(cmd: "help",
     documentation: "- help: displays help information (instructions). \n" +
        "- help <COMMAND_NAME>: get descriptions for a specific command.")]
    public class Help:ICommand
    {
        private Dictionary<string, DocCommandAttribute> docs;
        private string? command;
        public Help(string? cmd)
        {
            docs = SystemDocumentation.ToDictionary(Assembly.GetExecutingAssembly());
            this.command = cmd;
        }

        public Task<Result> ExecAsync()
        {
            try
            {
                  return Task.FromResult(Result.Ok()
                    .WithSuccess(new SuccessWithDocs(this.generateDoc())));
            }
            catch (Exception exception)
            {
                return Task.FromResult(Result.Fail(new Error("Error in displaying the documentation.").CausedBy(exception)));
            }
        }

        private IEnumerable<string> generateDoc()
        {
            List<string> result = new List<string>();
            // se não passou mais nenhum argumento mostra help de todos os comandos
            if (this.command is null)
            {
                foreach (var doc in docs.Values)
                {
                    result.Add(doc.Documentation);
                }
            }
            // exibe o help daquele command específico
            else
            {  
                if (docs.ContainsKey(this.command))
                {
                    var comando = docs[this.command];
                    result.Add(comando.Documentation);
                }
                else
                {
                    result.Add("Command not found");
                    throw new ArgumentException();
                }

            }
            return result;
        }
    }
}
