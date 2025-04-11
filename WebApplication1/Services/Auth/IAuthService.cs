using WebApplication1.Services.Model;

namespace WebApplication1.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseModel?> RegisterAsync(RegisterModel model, string role = "technicien");
        Task<AuthResponseModel?> LoginAsync(LoginModel login);
        Task<AuthResponseModel?> RefreshTokenAsync(RefreshRequestModel refresh);
    }
}
