using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public partial class Keyword
    {
        public Keyword()
        {
            this.ContactMethods = new ObservableCollection<ContactMethod>();
            this.Contacts = new ObservableCollection<Contact>();
            this.Children = new ObservableCollection<Keyword>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Parent_Id { get; set; }
        public virtual ICollection<ContactMethod> ContactMethods { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Keyword> Children { get; set; }
        [ForeignKey("Parent_Id")]
        public virtual Keyword Parent { get; set; }
    }
}
