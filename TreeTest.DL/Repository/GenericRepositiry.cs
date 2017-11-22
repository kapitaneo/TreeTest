using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTest.Core.Interfaces.Repository;
using TreeTest.Core.Models;

namespace TreeTest.DL.Repository
{
    class GenericRepositiry<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        TreeTestContext _context;
        IDbSet<TEntity> _entities;

        public GenericRepositiry(TreeTestContext context)
        {
            _context = context;
        }

        protected virtual IDbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    this._entities = _context.Set<TEntity>();
                }
                return _entities;
            }
        }

        public TEntity GetById(string id)
        {
            return this.Entities.Find(id);
        }

        public bool Insert(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(entity => this.Entities.Add(entity));
            try
            {
                this._context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
