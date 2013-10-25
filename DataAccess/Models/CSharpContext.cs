using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DataAccess.Models
{
    public partial class CSharpContext : DbContext
    {
        static CSharpContext()
        {
            Database.SetInitializer<CSharpContext>(null);
        }

        public CSharpContext()
            : base("Name=CSharpContext")
        {
        }

        public DbSet<ContactMethod> ContactMethods { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Address> Addresses { get; set; }


    }
}
