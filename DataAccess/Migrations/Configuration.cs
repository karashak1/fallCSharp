namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DataAccess.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Models.CSharpContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.Models.CSharpContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            context.Keywords.AddOrUpdate(
                new Keyword { Name = "Root", Parent_Id = 1 },
                new Keyword { Name = "Person Types", Parent_Id = 1 },
                new Keyword { Name = "Admin", Parent_Id = 2 }
            );

            for (int i = 0; i < 1000; i++) {
                 context.Contacts.AddOrUpdate(
                                new Contact { FirstName = "Mickey", LastName = "Duck", KeywordsId = 3 },
                                new Contact { FirstName = "Donald", LastName = "Mouse", KeywordsId = 3 }
                             );
            }

           
             
        }
    }
}
