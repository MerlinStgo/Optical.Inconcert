namespace Optical.Inconcert.Application.Wrapper
{
    public class ResponseBase<T> where T : class
    {
        public bool Success { get; set; }
        public String Message { get; set; }
        public T? Data { get; set; }

        public ResponseBase()
        {
            Success = false;
            Message = string.Empty;
            Data = null;
        }
    }
}
