using System;

namespace ADPORTS.EmployeeManagement.Core.Common.Exceptions
{
    public class Error
    {
        private string _message;
        public string Code { get; set; }

        public object[] Parameters { get; set; }

        public ErrorException Exception { get; set; }


        public Error(string code, string message)
        {
            Code = code;
            _message = message;
        }

        public Error(string code)
        {
            Code = code;
        }

        public Error(string code, object[] parameters)
        {
            Code = code;
            Parameters = parameters;
        }

        public Error(string code, Exception ex)
        {
            Code = code;

            //TODO: must be configurable
            Exception = new ErrorException { Message = ex.Message, StackTrace = ex.StackTrace };
        }

    }

    public class ErrorException
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public string ReferenceId { get; set; }
    }
}