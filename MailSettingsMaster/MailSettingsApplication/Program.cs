using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSettingsApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string dateFormat = "yyyyMMdd hh:mm:ss.fff";
                Mail mail = new Mail();

                mail.Send(
                    "jdnark@gmail.com",
                    $"This is it {DateTime.UtcNow.ToString(dateFormat)}",
                    "I guess it would be nice if I could touch  your body because not everybody's got a body like you.");
            }

            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }
    }
}
