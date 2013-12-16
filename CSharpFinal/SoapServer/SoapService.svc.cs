using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.Entity;

namespace SoapServer {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SoapService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SoapService.svc or SoapService.svc.cs at the Solution Explorer and start debugging.
    public class SoapService : ISoapService {

        private ContactsContext db;

        SoapService() {
            db = new ContactsContext();
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
        }

        public string DoWork() {
            return "Hello World";
        }

        public IEnumerable<Contact> GetContacts() {
            var contacts = db.Contacts.Include(c => c.Address); 
            return contacts;
        }

        public IEnumerable<Company> GetCompanies() {
            //db.Configuration.ProxyCreationEnabled = false;
            //db.Configuration.LazyLoadingEnabled = false;
            return db.Companies.Include(c=> c.Address).ToList();
        }

        public IEnumerable<Address> GetAddresses() {
            //db.Configuration.ProxyCreationEnabled = false;
            //db.Configuration.LazyLoadingEnabled = false;
            return db.Addresses.ToList();
        }

        public IEnumerable<ContactMethod> GetContactMethods(int id) {
            //db.Configuration.ProxyCreationEnabled = false;
            //db.Configuration.LazyLoadingEnabled = false;
            var methods = db.ContactMethods.Where(x => x.ContactId == id);
            return methods.ToList();
        }

        public void AddContact(Contact contact) {
                db.Contacts.Add(contact);
        }


        public void Save() {
            db.SaveChanges();
        }
    }
}
