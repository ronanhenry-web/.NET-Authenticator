using AutoMapper;
using WebApplication1.DataAccess.Dao;
using WebApplication1.Services.Model;

namespace WebApplication1.Services.ServiceType
{
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly IServiceTypeDataAccess _dao;
        private readonly IMapper _mapper;

        public ServiceTypeService(IServiceTypeDataAccess dao, IMapper mapper)
        {
            _dao = dao;
            _mapper = mapper;
        }

        public async Task<List<ServiceTypeReadModel>> GetAllAsync()
        {
            var entities = await _dao.GetAllAsync();
            return _mapper.Map<List<ServiceTypeReadModel>>(entities);
        }

        public async Task<ServiceTypeReadModel> CreateAsync(ServiceTypeCreateModel model)
        {
            var entity = await _dao.CreateAsync(model);
            return _mapper.Map<ServiceTypeReadModel>(entity);
        }
    }
}
