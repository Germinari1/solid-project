using FluentResults;

namespace Project.Adopet.Console.Comandos;
public interface IAfterExec
{
    event Action<Result>? afterExec;
}
