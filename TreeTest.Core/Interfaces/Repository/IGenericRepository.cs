using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTest.Core.Models;

namespace TreeTest.Core.Interfaces.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        TEntity GetById(string id);
        bool Insert(IEnumerable<TEntity> entities);
    }
}
