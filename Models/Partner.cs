using System;
using System.Collections.Generic;

namespace localstorage_to_s3bucket.Models
{
    public partial class Partner
    {
        public int Id { get; set; }
        public long MobileNo { get; set; }
        public int Verification { get; set; }
        public DateTime Datetime { get; set; }
    }
}
