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
    public class VoteRepository : IVotesRepository
    {
        private readonly ApplicationDBContext _context;

        public VoteRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Votes> addVoteAsync(Votes votes)
        {
            await _context.Votes.AddAsync(votes);
            await _context.SaveChangesAsync();

            return votes;
        }

        public async Task<IEnumerable<Votes>> getAllVotesAsync()
        {
            return await _context.Votes.ToListAsync();
        }


        public async Task<int> getVoteCountByCandidateAsync(int candidateID)
        {
            return await _context.Votes.Where(v => v.CandidateId == candidateID).CountAsync();
        }


        public async Task<IEnumerable<Votes>> getVotesByUserIdAsync(int voterID)
        {
            return await _context.Votes.Where(v => v.VoterId == voterID).ToListAsync();
        }

        public async Task<bool> hasAlreadyVotedAsync(int ElectionId, int PositionID, int VoterId)
        {
            return await _context.Votes.AnyAsync( v => v.ElectionId == ElectionId && v.PositionId == PositionID && v.VoteId == VoterId);
        }

        public async Task saveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
