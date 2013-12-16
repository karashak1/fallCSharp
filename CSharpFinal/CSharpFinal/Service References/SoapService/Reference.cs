﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSharpFinal.SoapService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SoapService.ISoapService")]
    public interface ISoapService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/DoWork", ReplyAction="http://tempuri.org/ISoapService/DoWorkResponse")]
        string DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/DoWork", ReplyAction="http://tempuri.org/ISoapService/DoWorkResponse")]
        System.Threading.Tasks.Task<string> DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/GetContacts", ReplyAction="http://tempuri.org/ISoapService/GetContactsResponse")]
        DataAccess.Contact[] GetContacts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/GetContacts", ReplyAction="http://tempuri.org/ISoapService/GetContactsResponse")]
        System.Threading.Tasks.Task<DataAccess.Contact[]> GetContactsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/GetCompanies", ReplyAction="http://tempuri.org/ISoapService/GetCompaniesResponse")]
        DataAccess.Company[] GetCompanies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/GetCompanies", ReplyAction="http://tempuri.org/ISoapService/GetCompaniesResponse")]
        System.Threading.Tasks.Task<DataAccess.Company[]> GetCompaniesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/GetAddresses", ReplyAction="http://tempuri.org/ISoapService/GetAddressesResponse")]
        DataAccess.Address[] GetAddresses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/GetAddresses", ReplyAction="http://tempuri.org/ISoapService/GetAddressesResponse")]
        System.Threading.Tasks.Task<DataAccess.Address[]> GetAddressesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/GetContactMethods", ReplyAction="http://tempuri.org/ISoapService/GetContactMethodsResponse")]
        DataAccess.ContactMethod[] GetContactMethods(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/GetContactMethods", ReplyAction="http://tempuri.org/ISoapService/GetContactMethodsResponse")]
        System.Threading.Tasks.Task<DataAccess.ContactMethod[]> GetContactMethodsAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/AddContact", ReplyAction="http://tempuri.org/ISoapService/AddContactResponse")]
        void AddContact(DataAccess.Contact contact);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/AddContact", ReplyAction="http://tempuri.org/ISoapService/AddContactResponse")]
        System.Threading.Tasks.Task AddContactAsync(DataAccess.Contact contact);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/Save", ReplyAction="http://tempuri.org/ISoapService/SaveResponse")]
        void Save();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISoapService/Save", ReplyAction="http://tempuri.org/ISoapService/SaveResponse")]
        System.Threading.Tasks.Task SaveAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISoapServiceChannel : CSharpFinal.SoapService.ISoapService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SoapServiceClient : System.ServiceModel.ClientBase<CSharpFinal.SoapService.ISoapService>, CSharpFinal.SoapService.ISoapService {
        
        public SoapServiceClient() {
        }
        
        public SoapServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SoapServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SoapServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SoapServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string DoWork() {
            return base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task<string> DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public DataAccess.Contact[] GetContacts() {
            return base.Channel.GetContacts();
        }
        
        public System.Threading.Tasks.Task<DataAccess.Contact[]> GetContactsAsync() {
            return base.Channel.GetContactsAsync();
        }
        
        public DataAccess.Company[] GetCompanies() {
            return base.Channel.GetCompanies();
        }
        
        public System.Threading.Tasks.Task<DataAccess.Company[]> GetCompaniesAsync() {
            return base.Channel.GetCompaniesAsync();
        }
        
        public DataAccess.Address[] GetAddresses() {
            return base.Channel.GetAddresses();
        }
        
        public System.Threading.Tasks.Task<DataAccess.Address[]> GetAddressesAsync() {
            return base.Channel.GetAddressesAsync();
        }
        
        public DataAccess.ContactMethod[] GetContactMethods(int id) {
            return base.Channel.GetContactMethods(id);
        }
        
        public System.Threading.Tasks.Task<DataAccess.ContactMethod[]> GetContactMethodsAsync(int id) {
            return base.Channel.GetContactMethodsAsync(id);
        }
        
        public void AddContact(DataAccess.Contact contact) {
            base.Channel.AddContact(contact);
        }
        
        public System.Threading.Tasks.Task AddContactAsync(DataAccess.Contact contact) {
            return base.Channel.AddContactAsync(contact);
        }
        
        public void Save() {
            base.Channel.Save();
        }
        
        public System.Threading.Tasks.Task SaveAsync() {
            return base.Channel.SaveAsync();
        }
    }
}