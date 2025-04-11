using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Data.Entity.Identity;
using WebApplication1.DataAccess.Dao;
using WebApplication1.Services.Model;

namespace WebApplication1.Services.Intervention
{
    public class InterventionService : IInterventionService
    {
        private readonly IInterventionDataAccess _dao;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public InterventionService(IInterventionDataAccess dao, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _dao = dao;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<InterventionReadModel>> GetAllAsync(string? userId, bool isAdmin)
        {
            var interventions = await _dao.GetAllWithIncludesAsync(userId, isAdmin);
            return _mapper.Map<List<InterventionReadModel>>(interventions);
        }

        public async Task<InterventionReadModel?> GetByIdAsync(int id)
        {
            var entity = await _dao.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<InterventionReadModel>(entity);
        }

        public async Task<InterventionReadModel> CreateAsync(InterventionCreateModel model)
        {
            var entity = await _dao.CreateAsync(model);
            return _mapper.Map<InterventionReadModel>(entity);
        }
    }
}
