namespace ElrondConsoleLibrary
{
    public class ApiResponse<T>
    {
        public T Result { get; set; }

        public bool IsError { get; set; }

        public string Message { get; set; }
        public string Url { get; set; }
        public string ResultJson { get; set; }
        public string Data { get; set; }
        public string ResultRawJson { get; set; }
    }
}
