using System;
namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)  //burada base demek Result demek

        {


        }


        public SuccessResult() : base(true)
        {

        }
    }


}
