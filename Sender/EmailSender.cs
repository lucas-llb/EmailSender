using System.Net;
using System.Net.Mail;

namespace EmailSender.Sender;

public static class EmailSender
{
    public static void Send(string originEmail, string originPassword, string receiveEmail)
    {
        var emailMessage = new MailMessage();
        try
        {
            // change to smtp.gmail.com if your origin email is gmail
            var client = new SmtpClient("smtp.office365.com", 587)
            {
                EnableSsl = true,
                Timeout = 100000,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(originEmail, originPassword)
            };

            emailMessage.From = new MailAddress(originEmail, "Test Email");
            emailMessage.Body = "Testing email sender";
            emailMessage.Subject = "Email Test";
            emailMessage.IsBodyHtml = true;
            emailMessage.Priority = MailPriority.Normal;
            emailMessage.To.Add(receiveEmail);

            client.Send(emailMessage);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }
}
