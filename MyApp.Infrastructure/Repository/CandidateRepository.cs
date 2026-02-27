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
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDBContext _context;

        public CandidateRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Candidates> addCandidateAsync(Candidates candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();

            return candidate;
        }

        public async Task<bool> deleteCandidateAsync(int id)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(c => c.CandidateId == id);
            if (candidate == null) return false;

            _context.Candidates.Remove(candidate);

            return true;
        }

        public async Task<IEnumerable<Candidates>> getAllCandidatesAsync()
        {
            var candidate = await _context.Candidates
                .Include(c => c.Positions)
                .AsNoTracking()
                .ToListAsync();

            return candidate;

        }

        public async Task<Candidates?> getCandidateByIDAsync(int id)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(c => c.CandidateId == id);
            if(candidate == null) return null;

            return candidate;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
