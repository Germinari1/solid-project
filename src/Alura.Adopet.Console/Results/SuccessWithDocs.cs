using FluentResults;

namespace Project.Adopet.Console.Results;

public class SuccessWithDocs : Success
{
    public IEnumerable<string> Documentation { get; }
    public SuccessWithDocs(IEnumerable<string> doc)
    {
        Documentation = doc;
    }
}
