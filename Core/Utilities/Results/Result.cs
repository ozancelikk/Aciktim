using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public Result(bool success)
        {
            this.Success = success;
        }
        public Result(string message, bool success) : this(success)
        {
            this.Message = message;
        }

    }
}
