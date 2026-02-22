using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repositories
{
    public interface IElectionRepository
    {
        public Task<IEnumerable<Elections>> getAllElectionsAsync();
        public Task<Elections?> getElectionByIDAsync(int id);
        public Task<Elections> addElectionAsync(Elections election);
        public Task<bool> deleteElectionAsync(int id);
        public Task SaveChangesAsync();
    }
}
