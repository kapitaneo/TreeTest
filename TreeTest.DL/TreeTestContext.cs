using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTest.Core.Models;

namespace TreeTest.DL
{
    public class TreeTestContext: DbContext
    {
        public TreeTestContext() : base("DefaultConnection")
        { }
        public DbSet<Tree> Trees { get; set; }
    }
}
