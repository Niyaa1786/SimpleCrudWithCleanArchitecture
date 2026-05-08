namespace SimpleCrud.Api.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public object? Errors { get; set; }
        public DateTime TimeStamp { get; set; }

        public static ApiResponse<T> Ok(T data, string message = "Request successful")
        {
            return new ApiResponse<T>()
            {
                Success = true,
                Message = message,
                Data = data,
                Errors = null,
                TimeStamp = DateTime.Now
            };
        }

        public static ApiResponse<T> Error(string message, object ? errors = null)
        {
            return new ApiResponse<T>()
            {
                Success = false,
                Message = message,
                Data = default,
                Errors = errors,
                TimeStamp = DateTime.Now
            };
        }
    }
}
