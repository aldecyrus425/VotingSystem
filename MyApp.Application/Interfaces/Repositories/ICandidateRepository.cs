using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repositories
{
    public interface ICandidateRepository
    {
        public Task<IEnumerable<Candidates>> getAllCandidatesAsync();
        public Task<Candidates?> getCandidateByIDAsync(int id);
        public Task<Candidates> addCandidateAsync(Candidates candidate);
        public Task<bool> deleteCandidateAsync(int id);
        public Task SaveChangesAsync();
    }
}
