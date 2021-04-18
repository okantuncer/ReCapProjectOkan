using System;
namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message):this(success) //resultın tek parametreli constructorına succesi yolla. (this) bu clas demek, yani result..
        {
            Message = message;
            //Success = success; --- bunu silip aşağıdakini bırakıyorum. Çünkü DRY..
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
