using System;

namespace Contoso.Shop.Model.Shared
{
    public enum ResultCode
    {
        Unknown = 0,
        Ok = 200,
        BadRequest = 400,
        NotFound = 404
    }

    public class Result
    {
        private static readonly Result Success = new Result(true, string.Empty, ResultCode.Ok);

        protected Result(bool isSuccess, string error, ResultCode code = ResultCode.Unknown)
        {
            IsSuccess = isSuccess;
            Error = error;
            Code = code;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string Error { get; }
        public ResultCode Code { get; }

        public static Result Ok()
        {
            return Success;
        }

        public static Result<T> Ok<T>(T value, ResultCode code = ResultCode.Ok)
        {
            return new Result<T>(value, true, string.Empty);
        }


        public static Result Fail(string message, ResultCode code = ResultCode.BadRequest)
        {
            return new Result(false, message, code);
        }

        public static Result<T> Fail<T>(string message, ResultCode code = ResultCode.BadRequest)
        {
            return new Result<T>(default(T), false, message, code);
        }

        public Result<T> As<T>(T value = default(T))
        {
            return new Result<T>(value, IsSuccess, Error, Code);
        }
    }

    public class Result<T> : Result
    {
        private readonly T value;

        protected internal Result(T value, bool isSuccess, string error, ResultCode code = ResultCode.Unknown) : base(isSuccess, error, code)
        {
            this.value = value;
        }

        public T Value
        {
            get
            {
                if (IsFailure)
                {
                    throw new InvalidOperationException();
                }

                return value;
            }
        }
    }
}