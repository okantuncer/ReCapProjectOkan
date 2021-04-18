using System;
namespace Core.Utilities.Results
{
    public interface IResult
    {
        // get demek sadece okunabilir demek..
        bool Success { get; }
        string Message { get; }
    }
}
