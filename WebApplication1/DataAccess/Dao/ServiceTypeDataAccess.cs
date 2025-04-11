using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DataAccess.Entity;
using WebApplication1.Services.Model;

namespace WebApplication1.DataAccess.Dao
{
    public class ServiceTypeDataAccess : IServiceTypeDataAccess
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ServiceTypeDataAccess(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ServiceTypeEntity>> GetAllAsync()
        {
            return await _context.ServiceTypes.ToListAsync();
        }

        public async Task<ServiceTypeEntity> CreateAsync(ServiceTypeCreateModel model)
        {
            var entity = _mapper.Map<ServiceTypeEntity>(model);
            _context.ServiceTypes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
