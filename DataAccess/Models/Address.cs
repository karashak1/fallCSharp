using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models {
    public class Address {
        public int Id { get; set; }
        public String StreetAddress { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public virtual Contact Contact { get; set; }
        public int ContactId { get; set; }
    }
}
