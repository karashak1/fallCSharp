namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DataAccess;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.ContactsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DataAccess.ContactsContext";
        }

        protected override void Seed(DataAccess.ContactsContext context)
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

            context.Contacts.AddOrUpdate(
                new Contact {
                    FirstName = "Kevin",
                    LastName = "Karashay",
                    Address = new Address { Street = "21 Street", City = "Saugerties", State = "NY", Zip = "12477" },
                    Id = 0,
                }
            );
            context.ContactMethods.AddOrUpdate(
                new ContactMethod { 
                    ContactId = 0,
                    type="Phone",
                    value="555-555-5555"
                }
            );
            context.Companies.AddOrUpdate(new DataAccess.Company { Name="Big Fun Toys", PhoneNumber="555-454-3434",
                Address = new Address{Street="34 Main St.", City="Kingston", State="NY", Zip="12401"}
            });
        }
    }
}
