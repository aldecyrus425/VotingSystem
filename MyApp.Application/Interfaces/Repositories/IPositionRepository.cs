using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repositories
{
    public interface IPositionRepository
    {
        public Task<IEnumerable<Positions>> getAllPositionAsync();
        public Task<Positions?> getPositionByIDAsync(int id);
        public Task<Positions> addPositionAsync(Positions position);
        public Task<bool> deletePositionAsync(int id);
        public Task saveChangesAsync();
    }
}
