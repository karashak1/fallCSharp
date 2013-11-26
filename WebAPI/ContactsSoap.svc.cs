using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebAPI {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ContactsSoap" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ContactsSoap.svc or ContactsSoap.svc.cs at the Solution Explorer and start debugging.
    public class ContactsSoap : IContactsSoap {
        public string DoWork() {
            return "Hello World!";
        }

        
        public IEnumerable<Contact> GetContacts(int page) {
            var db = new CSharpContext();
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            return db.Contacts.OrderBy(x=> x.LastName).Skip(page).Take(10).ToList();
        }
    }
}
