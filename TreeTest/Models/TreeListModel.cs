using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreeTest.Models
{
    public class TreeListModel
    {
        public string Name { get; set; }
        public IEnumerable<TreeListModel> ListTrees { get; set; }

    }
}