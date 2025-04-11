using WebApplication1.Services.Model;

namespace WebApplication1.Services.ServiceType
{
    public interface IServiceTypeService
    {
        Task<List<ServiceTypeReadModel>> GetAllAsync();
        Task<ServiceTypeReadModel> CreateAsync(ServiceTypeCreateModel model);
    }
}
