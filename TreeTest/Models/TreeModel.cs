using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeTest.Models
{
    public class TreeModel
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

    }
}