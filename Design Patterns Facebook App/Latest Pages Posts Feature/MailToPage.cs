using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Design_Patterns_Facebook_App
{
    public class MailToPage
    {
        public static readonly string sr_PageOwnerMail = "dpappofficialmail@gmail.com";

        public void SendMail(string i_PageOwnerEmail, int i_NumberOfComplains)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("dpappofficialmail@gmail.com", "AppPassword"),
                    EnableSsl = true
                };
                client.Send(sr_PageOwnerMail, i_PageOwnerEmail, "PagesPosts_YoutubePosts App Message, "
                    ,"Hello sir. This mail represent an offical complaint sent from " + i_NumberOfComplains  + " users of our application who FIND YOUR PAGE POST Insulting." +
                    "Please reply this mail and explain your motives." +
                    "Thank You.");
                Console.ReadLine();
            }
            catch (SmtpException ex)
            {
                throw new ApplicationException("SmtpException has occured: " + ex.Message);
            }
        }
    }
}