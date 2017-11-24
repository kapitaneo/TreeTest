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

            TreeListModel Model = new TreeListModel() {Name= mainTree.Name, ListTrees =repos.GetTreeList().ToList().FindAll(x => x.ParentId == mainTree.Id).Select(y=>new TreeModel(y)).ToList() };

            return View(Model);
        }

        public ActionResult NextNode(string id, string name)
        {
            TreeListModel Model = new TreeListModel() { Name = name, ListTrees = repos.GetTreeList().ToList().FindAll(x => x.ParentId == id).Select(y => new TreeModel(y)).ToList() };

            return View("Index", Model);
        }
    }
}