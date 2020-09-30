using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Persistence.Contexts;
using EasyNutrition.API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyNutrition.API
{
    public class ExperienceRepository : BaseRepository, IExperienceRepository
    {
        public ExperienceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Experience>> ListAsync()
        {
            return await _context.Experience.ToListAsync();
        }

    }

}