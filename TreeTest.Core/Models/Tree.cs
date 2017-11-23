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
        public string Path { get; set; }
        public string ParentId { get; set; }

    }
}
