using WebApplication1.DataAccess.Entity;
using WebApplication1.Services.Model;

namespace WebApplication1.DataAccess.Dao
{
    public interface IServiceTypeDataAccess
    {
        Task<List<ServiceTypeEntity>> GetAllAsync();
        Task<ServiceTypeEntity> CreateAsync(ServiceTypeCreateModel model);
    }
}
