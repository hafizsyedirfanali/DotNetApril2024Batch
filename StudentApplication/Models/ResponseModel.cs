namespace StudentApplication.Models
{
    public class ResponseModel
    {
        public bool IsSucceeded { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ErrorCode { get; set; }
    }

    public class ResponseModel<T>
    {
        public bool IsSucceeded { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ErrorCode { get; set; }
        public T? Value { get; set; }
    }
}