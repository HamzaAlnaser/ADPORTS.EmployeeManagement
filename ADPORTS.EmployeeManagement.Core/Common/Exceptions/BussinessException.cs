using System;
using System.Collections.Generic;

namespace ADPORTS.EmployeeManagement.Core.Common.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        public virtual ResultCode StatusCode { get; } = ResultCode.BadRequest;

        public BusinessException(string code)
        {
            if (Errors == null)
            {
                Errors = new List<Error>();
            }

            Errors.Add(new Error(code, this));
        }

        public BusinessException(List<Error> errors)
        {
            Errors = errors;
        }

        public virtual List<Error> Errors { get; set; }
    }
}