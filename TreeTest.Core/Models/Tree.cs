using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTest.Core.Models
{
    public class Tree : BaseEntity
    {
        public string Name { get; set; }

        public Tree()
        {
            NodeLinks = new List<Tree>();
        }
        public IEnumerable<Tree> NodeLinks { get; set; }
    }
}
