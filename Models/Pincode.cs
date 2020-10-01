using System;
using System.Collections.Generic;

namespace localstorage_to_s3bucket.Models
{
    public partial class Pincode
    {
        public Pincode()
        {
            Address = new HashSet<Address>();
        }

        public int PinId { get; set; }
        public int PincodeNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
