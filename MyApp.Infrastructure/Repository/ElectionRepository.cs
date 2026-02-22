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
    public class ElectionRepository : IElectionRepository
    {
        private readonly ApplicationDBContext _context;

        public ElectionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Elections> addElectionAsync(Elections election)
        {
            await _context.Elections.AddAsync(election);
            await _context.SaveChangesAsync();

            return election;
        }

        public async Task<bool> deleteElectionAsync(int id)
        {
            var election = await _context.Elections.FirstOrDefaultAsync(e => e.ElectionId == id);
            if (election == null) return false;

            _context.Elections.Remove(election);

            return true;
        }

        public async Task<IEnumerable<Elections>> getAllElectionsAsync()
        {
            var election = await _context.Elections
                .AsNoTracking()
                .Include(election => election.User)
                .ToListAsync();

            return election;
        }

        public Task<Elections?> getElectionByIDAsync(int id)
        {
            var election = _context.Elections
                .Include(election => election.User)
                .FirstOrDefaultAsync();

            if (election == null)
                return null;

            return election;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
