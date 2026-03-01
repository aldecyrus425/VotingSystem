using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        public Task BeginTransactionAsync();
        public Task CommitAsync();
        public Task RollbackAsync();
    }
}
