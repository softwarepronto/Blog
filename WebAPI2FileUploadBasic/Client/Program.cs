using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Client
{
    class Program
    {
        private const string _fileToUpload = "FileToUpload.txt";

        private const string _fileUploadName = "datafile";

        private const string _uploadEndPoint = @"http://localhost:4323/API/Files";

        static void Main(string[] args)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (MultipartFormDataContent content = new MultipartFormDataContent())
                {
                    using (FileStream stream = File.Open(_fileToUpload, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamContent streamConent = new StreamContent(stream))
                        {
                            Task taskUpload;

                            content.Add(streamConent, _fileUploadName, _fileToUpload);
                            taskUpload = httpClient.PostAsync(_uploadEndPoint, content);                            
                            taskUpload.Wait();
                            if (taskUpload.Status == TaskStatus.RanToCompletion)
                            {
                                Console.WriteLine("File uploaded");
                            }

                            else
                            {
                                Console.WriteLine("File uploaded");
                            }
                        }
                    }
                }
            }
        }
    }
}
