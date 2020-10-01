using System;
using System.Collections.Generic;

namespace localstorage_to_s3bucket.Models
{
    public partial class User
    {
        public User()
        {
            Address = new HashSet<Address>();
            LogHistory = new HashSet<LogHistory>();
        }

        public int UserId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public long? MobileNo { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Gender { get; set; }
        public string ProfilePhoto { get; set; }
        public DateTime? CreationDatetime { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<LogHistory> LogHistory { get; set; }
    }
}
