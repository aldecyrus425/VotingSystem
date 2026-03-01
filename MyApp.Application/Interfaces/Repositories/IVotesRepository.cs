using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repositories
{
    public interface IVotesRepository
    {
        public Task<IEnumerable<Votes>> getAllVotesAsync();

        public Task<IEnumerable<Votes>> getVotesByUserIdAsync(int voterID);
        public Task<int> getVoteCountByCandidateAsync(int candidateID);

        public Task<Votes> addVoteAsync(Votes votes);

        public Task saveChangesAsync();

    }
}
