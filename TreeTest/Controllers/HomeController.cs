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
        [Route("{action = index}")]
        public ActionResult Index()
        {
            var mainTree = repos.GetTreeList().FirstOrDefault(x => x.ParentId == null);

            TreeListModel Model = new TreeListModel() { Name = mainTree.Name, ListTrees = repos.GetTreeList().ToList().FindAll(x => x.ParentId == mainTree.Id).Select(y => new TreeModel(y)).ToList() };

            return View(Model);
        }
        [HttpPost]
        [Route("{path}")]
        public ActionResult NextNode(string path)
        {
            var mainTree = repos.GetTreeList().FirstOrDefault(x => x.Path == path);
            TreeListModel Model = new TreeListModel() { Name = mainTree.Name, ListTrees = repos.GetTreeList().ToList().FindAll(x => x.ParentId == mainTree.Id).Select(y => new TreeModel(y)).ToList() };

            return View("Index", Model);
        }
    }
}