using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;


namespace EM.Components.Business
{
    public class EmailHelper
    {
        public static void Send(MailMessage msg)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            try
            {
                //smtp.Send(msg);
                Console.WriteLine(msg.Subject + " - " + msg.To[0].ToString());
                
            }
            catch
            {
                // do nothing
            }
        }
    }
}
