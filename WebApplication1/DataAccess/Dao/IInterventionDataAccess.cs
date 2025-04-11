using WebApplication1.DataAccess.Entity;
using WebApplication1.Services.Model;

namespace WebApplication1.DataAccess.Dao
{
    public interface IInterventionDataAccess
    {
        Task<List<InterventionEntity>> GetAllAsync(string? userId, bool isAdmin);
        Task<InterventionEntity?> GetByIdAsync(int id);
        Task<InterventionEntity> CreateAsync(InterventionCreateModel model);
        Task<List<InterventionEntity>> GetAllWithIncludesAsync(string? userId, bool isAdmin);

    }
}
