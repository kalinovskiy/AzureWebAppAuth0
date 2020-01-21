namespace WebApplication.Models
{
    public class IndexViewModel
    {
        public string AccessToken { get; set; }

        public string TestData { get; set; }

        public bool IsAuth => !string.IsNullOrEmpty(AccessToken);
    }
}
