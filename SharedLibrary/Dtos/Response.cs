using System.Text.Json.Serialization;

namespace SharedLibrary.Dtos
{
    public class Response<T> where T : class
    {
        public int StatusCode { get; private set; }
        public T Data { get; set; }
        public ErrorDto Error { get; set; }

        [JsonIgnore]
        public bool IsSuccess { get; set; }

        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, Data = data, IsSuccess = true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, Data = default, IsSuccess = true };
        }

        public static Response<T> Fail(ErrorDto error, int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, Error = error, IsSuccess = false };
        }

        public static Response<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            return new Response<T> { StatusCode = statusCode, Error = new ErrorDto(errorMessage, isShow), IsSuccess = false };
        }
    }
}