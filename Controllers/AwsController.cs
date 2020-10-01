using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using localstorage_to_s3bucket.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace localstorage_to_s3bucket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwsController : ControllerBase
    {
        private readonly IOptions<Settings> _awsimage;

        public AwsController(IOptions<Settings> awsimage)
        {
            _awsimage = awsimage;
        }

        //https://aarviexp.s3.us-east-2.amazonaws.com/41681704-1175-437b-b123-a470f803763a.jpg
        //Upload Bunch of files from Local Storage to AWS
        [HttpGet("UploadFilesToAws")]
        public async Task<IActionResult> Upload()
        {
            //Directory Location
            System.IO.DirectoryInfo di2 = new System.IO.DirectoryInfo(@"D:\exp");
            //Fetch all files from Directories into List Form
            System.IO.FileInfo[] fileNames = di2.GetFiles("*.*");

            //Upload Each file into AWS
            foreach (System.IO.FileInfo fi2 in fileNames)
            {
                Console.WriteLine("{0}", fi2);

                // connecting to the client
                var client = new AmazonS3Client(_awsimage.Value.AWSAccessKeyId, _awsimage.Value.AWSSecretKey, Amazon.RegionEndpoint.USEast2);
                var file = fi2;   //Image from [FromForm]

                // get the file and convert it to the byte[]
                byte[] fileBytes = new Byte[file.Length];
                file.OpenRead().Read(fileBytes, 0, Int32.Parse(file.Length.ToString()));

                // create unique file name for prevent the mess
                var fileName = Guid.NewGuid() + System.IO.Path.GetExtension(file.Name);
                PutObjectResponse response = null;
                using (var stream = new MemoryStream(fileBytes))
                {
                    PutObjectRequest request = new PutObjectRequest
                    {
                        BucketName = _awsimage.Value.bucketname,
                        Key = fileName, // Only File Name
                     // Key = "UserProfile/" + fileName,  //Directory Name + File Name
                        InputStream = stream,
                        //ContentType = file.ContentType,  //Here i bypass this line bcz error(No needed)
                        CannedACL = S3CannedACL.PublicRead
                    };
                    response = await client.PutObjectAsync(request);
                };
                Console.WriteLine(new { result = response });

            }
            return Ok();

        }
    }
}
