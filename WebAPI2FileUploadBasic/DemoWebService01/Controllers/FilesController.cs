using System;
using System.IO;
using System.Net;
using System.Web;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Hosting;
using System.Collections.Generic;

namespace DemoWebService01.Controllers
{
    public class FilesController : ApiController
    {
        public string Post()
        {
            int numberOfFilesUploaded = 0;
            string folder = HostingEnvironment.MapPath("~/Files/");
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;

            for (int index = 0; index < files.Count; index++)
            {
                string key = files.GetKey(index);
                HttpPostedFile postedFile = files[index];

                if (postedFile.ContentLength > 0)
                {
                    string destinationFilename = Path.Combine(folder, Path.GetFileName(postedFile.FileName));

                    if (!File.Exists(destinationFilename))
                    {
                        postedFile.SaveAs(destinationFilename);
                        numberOfFilesUploaded = numberOfFilesUploaded + 1;
                    }
                }
            }

            if (numberOfFilesUploaded > 0)
            {
                return numberOfFilesUploaded + " Files Uploaded Successfully";
            }

            else
            {
                return "Upload Failed";
            }
        }
    }
}
