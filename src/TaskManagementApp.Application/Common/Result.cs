namespace TaskManagementApp.Application.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string? Error { get; }
        public T? Value { get; }

        protected internal Result(bool isSuccess, string? error, T? value)
        {
            IsSuccess = isSuccess;
            Error = error;
            Value = value;
        }
    }

    public static class Result
    {
        public static Result<T> Success<T>(T value) => new Result<T>(true, null, value);
        public static Result<T> Failure<T>(string error) => new Result<T>(false, error, default);
    }
}
