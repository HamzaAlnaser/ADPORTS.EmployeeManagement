using ADPORTS.EmployeeManagement.Core.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ADPORTS.EmployeeManagement.Core.Common
{
    public class ServiceResult
    {
        public ServiceResult()
        {
        }

        public ServiceResult(ResultCode status)
        {
            Status = status;
        }

        public ResultCode Status { get; set; }

        public List<Error> Errors { get; set; }

        public bool IsSucceed
        {
            get
            {
                return Status == ResultCode.Ok || Status == ResultCode.NoContent || Status == ResultCode.Created;
            }
        }

        public bool HasErrors
        {
            get
            {
                return Errors != null && Errors.Count > 0;
            }
        }

        public void AddErrors(params string[] codes)
        {
            if (Errors == null)
            {
                Errors = new List<Error>();
            }
            List<Error> errors = codes.Select(c => new Error(c)).ToList();

            Errors.AddRange(errors);
        }

        public void AddErrorWithExtraMessage(string extraMessage, params string[] codes)
        {
            if (Errors == null)
            {
                Errors = new List<Error>();
            }
            List<Error> errors = codes.Select(c => new Error(c, extraMessage)).ToList();

            Errors.AddRange(errors);
        }

        public void AddErrorWithParams(string code, params object[] parameters)
        {
            if (Errors == null)
            {
                Errors = new List<Error>();
            }

            Error error = new Error(code, parameters);
            Errors.Add(error);
        }

        public void AddErrors(List<Error> errors)
        {
            if (errors != null && errors.Count > 0)
            {
                if (Errors == null)
                {
                    Errors = new List<Error>();
                }
                Errors.AddRange(errors);
            }
        }

        public void AddError(Error error)
        {
            if (error != null)
            {
                if (Errors == null)
                {
                    Errors = new List<Error>();
                }
                Errors.Add(error);
            }
        }

    }

    public class ServiceResult<T> : ServiceResult
    {
        public ServiceResult() : base()
        {
        }

        public ServiceResult(ResultCode status) : base(status)
        {
        }

        public T Data { get; set; }

        public static implicit operator ServiceResult<T>(int v)
        {
            throw new NotImplementedException();
        }

    }
}