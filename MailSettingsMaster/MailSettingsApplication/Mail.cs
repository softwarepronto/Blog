using System.Net.Mail; // add reference to System.Net

namespace MailSettingsApplication
{
    public class Mail
    {
        public void Send(string recipient, string subject, string message)
        {
            SmtpClient client = new SmtpClient();
            MailMessage mail = new MailMessage();

            mail.To.Add(recipient);
            mail.Subject = subject;
            mail.Body = message;
            client.Send(mail);
        }
    }
}
