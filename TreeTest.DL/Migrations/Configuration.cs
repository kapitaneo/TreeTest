namespace TreeTest.DL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TreeTest.Core.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TreeTest.DL.TreeTestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TreeTest.DL.TreeTestContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //if (!context.Trees.Any())
            //{
                context.Trees.AddOrUpdate(new Tree [] {
                    new Tree{Id=Guid.NewGuid().ToString(), Name="Creating Digital Images", Path="Creating Digital Images/"},
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
                    new Tree{ Name="Graphic Products", ParentId=context.Trees.FirstOrDefault(x=>x.Name=="Creating Digital Images").Id, Path="Creating Digital Images/Graphic Products/"},
                    new Tree{ Name="Evidence", Path="Creating Digital Images/Evidence", ParentId=context.Trees.FirstOrDefault(x=>x.Name=="Creating Digital Images").Id },
                    new Tree{ Name="Resources", ParentId=context.Trees.FirstOrDefault(x=>x.Name=="Creating Digital Images").Id, Path="Creating Digital Images/Resources/" },
                    new Tree{ Name="Process", ParentId=context.Trees.FirstOrDefault(x=>x.Name=="Graphic Products").Id , Path="Creating Digital Images/Graphic Products/Process/"},
                    new Tree{ Name="Final Product", ParentId=context.Trees.FirstOrDefault(x=>x.Name=="Graphic Products").Id, Path="Creating Digital Images/Graphic Products/Final Product/" },
                    new Tree{ Name="Secondary Sources",  ParentId=context.Trees.FirstOrDefault(x=>x.Name=="Resources").Id, Path="Creating Digital Images/Resources/Secondary Sources/"},
                    new Tree{ Name="Primary Sources", ParentId=context.Trees.FirstOrDefault(x=>x.Name=="Resources").Id, Path="Creating Digital Images/Resources/Primary Sources/"},
                });
            //}
            context.SaveChanges();
        }
    }
}
