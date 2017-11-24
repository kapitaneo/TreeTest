using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreeTest.Core.Interfaces.Repository;
using TreeTest.Core.Models;
using TreeTest.DL.Repository;
using TreeTest.Models;

namespace TreeTest.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Tree> repos;

        public HomeController()
        {
            repos = new Repository();
        }

        // GET: Home
        public ActionResult Index()
        {
            var mainTree = repos.GetTreeList().FirstOrDefault(x=>x.ParentId==null);

            TreeListModel listtree = new TreeListModel() { ListTrees=repos.GetTreeList().Where(x=>x.ParentId==mainTree.Id).ToList().Select(y=> new TreeModel(y)) };
            return View();
        }
    }
}