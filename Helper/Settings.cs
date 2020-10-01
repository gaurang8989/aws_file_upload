using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace localstorage_to_s3bucket.Helper
{
    public class Settings
    {
        //RegisterImage Bucket Info
        public string AWSAccessKeyId { get; set; }
        public string AWSSecretKey { get; set; }
        public string bucketname { get; set; }
        //End of RegisterImage Bucket Info
    }
}
