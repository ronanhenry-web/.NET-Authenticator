using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Entity.Identity;
using WebApplication1.DataAccess.Entity;
using WebApplication1.Middleware;
using WebApplication1.Services.Model;

namespace WebApplication1.DataAccess.Dao
{
    public class InterventionDataAccess : IInterventionDataAccess
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public InterventionDataAccess(AppDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<InterventionEntity>> GetAllAsync(string? userId, bool isAdmin)
        {
            var query = _context.Interventions
                .Include(i => i.Technicians)
                .Include(i => i.Client)
                .Include(i => i.ServiceType)
                .AsQueryable();

            if (!isAdmin && userId != null)
            {
                query = query.Where(i => i.Technicians.Any(t => t.Id == userId));
            }

            return await query.ToListAsync();
        }

        public async Task<InterventionEntity?> GetByIdAsync(int id)
        {
            return await _context.Interventions
                .Include(i => i.Technicians)
                .Include(i => i.Client)
                .Include(i => i.ServiceType)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<InterventionEntity> CreateAsync(InterventionCreateModel model)
        {
            var client = await _userManager.FindByIdAsync(model.ClientId)
                         ?? throw new AppException("USER_NOT_FOUND");

            if (!await _userManager.IsInRoleAsync(client, "client"))
                throw new AppException("USER_NOT_FOUND");

            var technicians = await _context.Users
                .Where(u => model.TechnicianIds.Contains(u.Id))
                .ToListAsync();

            foreach (var tech in technicians)
            {
                if (!await _userManager.IsInRoleAsync(tech, "technicien"))
                    throw new AppException("USER_NOT_FOUND");
            }

            var intervention = _mapper.Map<InterventionEntity>(model);
            intervention.Client = client;
            intervention.Technicians = technicians;

            _context.Interventions.Add(intervention);
            await _context.SaveChangesAsync();

            return intervention;
        }

        public async Task<List<InterventionEntity>> GetAllWithIncludesAsync(string? userId, bool isAdmin)
        {
            var query = _context.Interventions
                .Include(i => i.Technicians)
                .Include(i => i.Client)
                .Include(i => i.ServiceType)
                .AsQueryable();

            if (!isAdmin && userId != null)
            {
                query = query.Where(i => i.Technicians.Any(t => t.Id == userId));
            }

            return await query.ToListAsync();
        }

    }
}
