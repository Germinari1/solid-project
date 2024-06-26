using FluentResults;

namespace Project.Adopet.Console.Comandos
{
    public interface ICommand
    {
        Task<Result> ExecAsync();
    }
}
