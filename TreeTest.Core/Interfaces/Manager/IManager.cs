using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTest.Core.Interfaces.Manager
{
    public interface IManager<TEntity, in TKey> : IDisposable
    {
        Task<TEntity> GetAsync(TKey id);
        Task AddAsync(TEntity item);
    }
}
