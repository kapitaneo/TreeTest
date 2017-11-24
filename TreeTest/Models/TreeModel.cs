using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreeTest.Core.Models;

namespace TreeTest.Models
{
    public class TreeModel
    {
        public TreeModel(Tree newtree)
        {
            Id = newtree.Id;
            ParentId = newtree.ParentId;
            Name = newtree.Name;
            Path = newtree.Path;
        }
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

    }
}