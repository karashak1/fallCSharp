//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public Order()
        {
            this.Items = new HashSet<Item>();
        }
    
        public int Id { get; set; }
        public System.DateTime create_at { get; set; }
        public System.DateTime updated_at { get; set; }
        public int CustomerId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
