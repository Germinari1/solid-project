using Project.Adopet.Console.Comandos;
using Project.Adopet.Console.UI;
using FluentResults;

ICommand? command = CommandsFactory.CreateCommand(args);
if (command is not null)
{
    var resultado = await command.ExecAsync();
    ConsoleUI.displayResult(resultado);
}
else
{
    ConsoleUI.displayResult(Result.Fail("Invalid command."));
}         
