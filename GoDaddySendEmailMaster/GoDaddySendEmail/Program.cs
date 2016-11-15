using System;
using System.Net.Mail;

namespace GoDaddySendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Send(
                        "KeyserSoeze@galacticnachos.com",
                        "VerbalKint@galacticnachos.com",
                        "any subject",
                        "any body");
                    smtpClient.Dispose();
                }
            }

            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }
    }
}
