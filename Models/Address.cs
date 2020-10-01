using System;
using System.Collections.Generic;

namespace localstorage_to_s3bucket.Models
{
    public partial class Address
    {
        public int AddId { get; set; }
        public int UserId { get; set; }
        public string HouseNo { get; set; }
        public string Society { get; set; }
        public string Landmark { get; set; }
        public int PinId { get; set; }
        public string AddressName { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }

        public virtual Pincode Pin { get; set; }
        public virtual User User { get; set; }
    }
}
