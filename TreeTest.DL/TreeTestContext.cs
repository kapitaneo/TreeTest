using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTest.Core.Models;

namespace TreeTest.DL
{
    public class TreeTestContext: DbContext
    {
        public TreeTestContext() : base("DefaultConnection")
        { }
        public DbSet<Tree> Trees { get; set; }

        public void Seed(TreeTestContext context)
        {
            
               context.Trees.AddOrUpdate(new Tree[] {
                    new Tree{Id=Guid.NewGuid().ToString(), Name="Creating Digital Images", Path="Creating Digital Images"},
                    new Tree{Id=Guid.NewGuid().ToString(), Name="Graphic Products"},
                    new Tree{Id=Guid.NewGuid().ToString(), Name="Evidence"},
                    new Tree{Id=Guid.NewGuid().ToString(), Name="Resources"},
                    new Tree{Id=Guid.NewGuid().ToString(), Name="Process" },
                    new Tree{Id=Guid.NewGuid().ToString(), Name="Final Product" },
                    new Tree{Id=Guid.NewGuid().ToString(), Name="Secondary Sources" },
                    new Tree{Id=Guid.NewGuid().ToString(), Name="Primary Sources"},
               });
                     context.SaveChanges();
                    context.Trees.AddOrUpdate(x => x.Name, new Tree[] {
                    new Tree{ Name="Graphic Products", ParentId=context.Trees.FirstOrDefault(x=>x.Name=="Creating Digital Images").Id, Path="Creating Digital Images/Graphic Products"},
                    new Tree{ Name="Evidence", Path="Creating Digital Images/Evidence", ParentId=context.Trees.FirstOrDefault(x=>x.Name=="Creating Digital Images").Id },
                    new Tree{ Name="Resources", ParentId=context.Trees.FirstOrDefault(x=>x.Name=="Creating Digital Images").Id, Path="Creating Digital Images/Resources" },
                    new Tree{ Name="Process", ParentId=context.Trees.FirstOrDefault(x=>x.Name=="Graphic Products").Id , Path="Creating Digital Images/Graphic Products/Process"},
                    new Tree{ Name="Final Product", ParentId=context.Trees.FirstOrDefault(x=>x.Name=="Graphic Products").Id, Path="Creating Digital Images/Graphic Products/Final Product" },
                    new Tree{ Name="Secondary Sources",  ParentId=context.Trees.FirstOrDefault(x=>x.Name=="Resources").Id, Path="Creating Digital Images/Resources/Secondary Sources"},
                    new Tree{ Name="Primary Sources", ParentId=context.Trees.FirstOrDefault(x=>x.Name=="Resources").Id, Path="Creating Digital Images/Resources/Primary Sources"},
                });
            context.SaveChanges();
        }

        
        public class CreateInitializer : DropCreateDatabaseAlways<TreeTestContext>
        {
            protected override void Seed(TreeTestContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }
    }
}
