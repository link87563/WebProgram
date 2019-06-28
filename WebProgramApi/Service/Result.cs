using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProgramApi.Interface;

namespace WebProgramApi.Service
{
    public class Result : IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public static class ResultExtension
    {
        public static Result Success(this Result helper)
        {
            return helper.Success("");
        }

        public static Result Success(this Result helper, string message)
        {
            helper.Success = true;
            helper.Message = message;
            return helper;
        }
    }
}
