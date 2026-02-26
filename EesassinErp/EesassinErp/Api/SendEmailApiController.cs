using BAL;
using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http; 
using System.Web.Script.Serialization;

namespace EesassinErp.Controllers
{
    public class SendEmailApiController : ApiController
    {
        // GET: SendEmail
      
        [HttpPost]
        public async Task<string> SendEmail(DocumentBAL obj)
        {
           
         try
            {
                string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.FireEmail(obj)));

                dynamic jsonDe = JsonConvert.DeserializeObject(result); 
                string SMTPUser = jsonDe[0].EmailId;
                string SMTPPassword = jsonDe[0].Password;
                int SmtpPort = jsonDe[0].Port ;
            string SmtpServer = jsonDe[0].SmtpServer;
                string EmailName = jsonDe[0].EmailName;
                string ToEmail = jsonDe[0].ToEmail;
            
                string Subject = jsonDe[0].Subject;
                string Msg = jsonDe[0].Msg;
              
              
                MailMessage EmailMsg = new MailMessage();
            EmailMsg.From = new MailAddress(SMTPUser, EmailName);
            EmailMsg.To.Add(new MailAddress(ToEmail));

                if (jsonDe[0].ReplyToList != "-1")
                {
                    string ReplyToList = jsonDe[0].ReplyToList;
                    EmailMsg.CC.Add(ReplyToList);
                }

               

            EmailMsg.Subject = Subject;

            EmailMsg.Body = Msg;

            EmailMsg.IsBodyHtml = true;
            EmailMsg.Priority = MailPriority.Normal;

            System.Net.Mail.SmtpClient SMTP = new System.Net.Mail.SmtpClient();
            SMTP.Host = SmtpServer;
            SMTP.Port = SmtpPort;
            SMTP.EnableSsl = true;
            SMTP.Timeout = 100000;


            SMTP.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            SMTP.UseDefaultCredentials = false;
            SMTP.Credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPassword);

            SMTP.Send(EmailMsg);

                return result;

            }

            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }

}