using DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SoapServer {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISoapService" in both code and config file together.
    [ServiceContract]
    public interface ISoapService {
        [OperationContract]
        string DoWork();

        [OperationContract]
        IEnumerable<Contact> GetContacts();

        [OperationContract]
        IEnumerable<Company> GetCompanies();

        [OperationContract]
        IEnumerable<Address> GetAddresses();

        [OperationContract]
        IEnumerable<ContactMethod> GetContactMethods(int id);

        [OperationContract]
        void AddContact(Contact contact);

        [OperationContract]
        void Save();
    }
}
