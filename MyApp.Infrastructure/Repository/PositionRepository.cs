using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interfaces.Repositories;
using MyApp.Domain.Entities;
using MyApp.Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repository
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDBContext _context;

        public PositionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Positions> addPositionAsync(Positions position)
        {
            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync();

            return position;
        }

        public async Task<bool> deletePositionAsync(int id)
        {
            var position = await _context.Positions.FirstOrDefaultAsync(p => p.PositionId == id);
            if(position == null)
            {
                return false;
            }

            _context.Positions.Remove(position);

            return true;
        }

        public async Task<IEnumerable<Positions>> getAllPositionAsync()
        {
            var response = await _context.Positions
                .AsNoTracking()
                .Include(p => p.Elections)
                .ToListAsync();

            return response;
        }

        public async Task<Positions?> getPositionByIDAsync(int id)
        {
            var response = await _context.Positions
                .Include(p => p.Elections)
                .FirstOrDefaultAsync(p => p.PositionId == id);

            if (response == null)
            {
                return null;
            }

            return response;
        }

        public async Task saveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
