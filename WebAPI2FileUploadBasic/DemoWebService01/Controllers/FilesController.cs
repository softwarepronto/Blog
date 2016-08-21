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
        private const string _fileUploadName = "datafile";

        public int Post()
        {
            string serverFolder = HostingEnvironment.MapPath("~/Uploads/");
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            HttpPostedFile postedFile = files[_fileUploadName];

            if (postedFile == null)
            {
                return 0;
            }

            string destinationFilename = Path.Combine(serverFolder, Path.GetFileName(postedFile.FileName));

            if (File.Exists(destinationFilename))
            {
                return 0;
            }

            postedFile.SaveAs(destinationFilename);

            return 1;
        }
    }
}
