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

        //public ActionResult Index()
        //{
        //    var mainTree = repos.GetTreeList().FirstOrDefault(x => x.ParentId == null);

        //    TreeListModel Model = new TreeListModel() { Name = mainTree.Name, ListTrees = repos.GetTreeList().ToList().FindAll(x => x.ParentId == mainTree.Id).Select(y => new TreeModel(y)).ToList() };

        //    return View(Model);
        //}

        //[Route("{*path}")]
        public ActionResult Index(string path)
        {
            TreeListModel Model;
            if (string.IsNullOrWhiteSpace(path))
            {
                var mainTree = repos.GetTreeList().FirstOrDefault(x => x.ParentId == null);

                Model = new TreeListModel() { Name = mainTree.Name, ListTrees = repos.GetTreeList().ToList().FindAll(x => x.ParentId == mainTree.Id).Select(y => new TreeModel(y)).ToList() };
            }
            else
            {
                var mainTree = repos.GetTreeList().FirstOrDefault(x => x.Path == path);
                Model = new TreeListModel() { Name = mainTree.Name, ListTrees = repos.GetTreeList().ToList().FindAll(x => x.ParentId == mainTree.Id).Select(y => new TreeModel(y)).ToList() };
            }

            return View("Index", Model);
        }
    }
}