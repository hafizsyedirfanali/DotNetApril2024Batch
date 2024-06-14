namespace StudentApplication.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string errorCode, string errorMessage)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
    }
}
