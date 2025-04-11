using WebApplication1.Services.Model;

namespace WebApplication1.Services.Intervention
{
    public interface IInterventionService
    {
        Task<List<InterventionReadModel>> GetAllAsync(string? userId, bool isAdmin);
        Task<InterventionReadModel?> GetByIdAsync(int id);
        Task<InterventionReadModel> CreateAsync(InterventionCreateModel model);
    }
}
