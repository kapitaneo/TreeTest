using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TreeTest.DL;
using static TreeTest.DL.TreeTestContext;

namespace TreeTest.App_Start
{
    public static class TreeTestDbInitializationHandler
    {
        public static void Initialize()
        {
            Database.SetInitializer(new CreateInitializer()); //if u want to use your initializer
            using (var db = new TreeTestContext())
            {
                {
                    db.Database.Initialize(true);
                }
            }
        }
    }
}