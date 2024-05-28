using System;
using System.Threading.Tasks;

namespace Data.Common
{
    public static class RequestResult
    {
        public static RequestResult<TResult> Success<TResult>(TResult result) => new RequestResult<TResult>(result);
        public static RequestResult<TResult> Fail<TResult>(RequestError error) => new RequestResult<TResult>(error);
    }

    public class RequestResult<TResult> : IRequestResult
    {
        private readonly TResult result;

        public RequestResult(TResult result)
        {
            this.result = result;
        }

        public RequestResult(RequestError error)
        {
            Error = error ?? throw new ArgumentNullException(nameof(error));
        }

        public RequestError Error { get; }

        public bool IsSuccess => Error == null;
        public bool IsError => !IsSuccess;

        public TResult GetResult()
        {
            if (IsError)
            {
                throw new RequestErrorException(Error);
            }
            return result;
        }

        public Task<RequestResult<TResult>> GetTask() => Task.FromResult(this);
    }

    
}
