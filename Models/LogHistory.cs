using System;
using System.Collections.Generic;

namespace localstorage_to_s3bucket.Models
{
    public partial class LogHistory
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public DateTime LoginDatetime { get; set; }

        public virtual User User { get; set; }
    }
}
