namespace Restaurant.PL.ViewModels
{
    public class ErrorViewModel
    {
        private string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}