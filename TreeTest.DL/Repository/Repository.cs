using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTest.Core.Interfaces.Repository;
using TreeTest.Core.Models;

namespace TreeTest.DL.Repository
{
    public class Repository : IRepository<Tree>
    {
        private TreeTestContext db;

        public Repository()
        {
            this.db = new TreeTestContext();
        }

        public IEnumerable<Tree> GetTreeList()
        {
            return db.Trees;
        }
        public Tree GetById(string id)
        {
            return db.Trees.Find(id);
        }



        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
