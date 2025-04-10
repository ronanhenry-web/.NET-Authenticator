namespace WebApplication1.Services.Model
{
    public class RefreshRequestModel
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
