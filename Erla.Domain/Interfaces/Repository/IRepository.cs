using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erla.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IAdd<TEntity>, ITransactions
    {

    }
}
