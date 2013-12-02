using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FinalDataLayer
{

    public class Address {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }

    public class Company {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<Contact> Employees { get; set; }
    }

    public class Contact {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<ContactMethod> ContactMethods { get; set; }
        //public  MyProperty { get; set; }
    }

    public class ContactMethod {
        public int Id { get; set; }
        public string value { get; set; }
        public string type { get; set; }
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }

    public class ContactsContext : DbContext {

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactMethod> ContactMethods { get; set; }
    }
}
