using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherChecker.Core.Common
{
    public class BaseResult<T>
    {
        public BaseResult(T result){ Result = result; }

        public BaseResult(string message)
        {
            Message = message;
        }
        public T? Result { get; }
        public string? Message { get; }

        public bool Success => Result != null && string.IsNullOrEmpty(Message);
    }

    public class BaseResult
    {
        public BaseResult(){}

        public BaseResult(string message)
        {
            Message = message;
        }
        public string? Message { get; }

        public bool Success => string.IsNullOrEmpty(Message);
    }
}
