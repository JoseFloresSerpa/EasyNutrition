using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Persistence.Contexts;
using EasyNutrition.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Persistence.Repositories
{
    public class AvailableScheduleRepository : BaseRepository, IAvailableScheduleRepository
    {

        public AvailableScheduleRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<AvailableSchedule>> ListByUserIdAsync(int userId)
        {
            return await _context.AvailableSchedules
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task AddAsync(AvailableSchedule availableSchedule)
        {
            await _context.AvailableSchedules.AddAsync(availableSchedule);
        }

        public async Task<AvailableSchedule> FindById(int userId)
        {
            return await _context.AvailableSchedules.FindAsync(userId);
        }

        public void Remove(AvailableSchedule availableSchedule)
        {
            _context.AvailableSchedules.Remove(availableSchedule);
        }

        public void Update(AvailableSchedule availableSchedule)
        {
            _context.AvailableSchedules.Update(availableSchedule);
        }
    }
}
