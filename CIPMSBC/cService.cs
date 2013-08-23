using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace CIPMSBC
{
    public class cService
    {
        public static void SendMail(String ToAddress,String CC,String FromName,String FromAddress,String ReplyTo,String Subject,String Body)
        {
            string strMailAuthentication = ConfigurationManager.AppSettings["MailAuthentication"].ToUpper();
            string strUsername = ConfigurationManager.AppSettings["UserName"].ToString();
            string strPassword = ConfigurationManager.AppSettings["Password"].ToString();
            try
            {
                SmtpClient oSmtpClient = new SmtpClient();

                MailMessage oMailMessage = new MailMessage();

                MailAddress oToAddress = new MailAddress(ToAddress);
                
                MailAddress oReplyAddress = new MailAddress(ReplyTo);
                MailAddress oFromAddress = new MailAddress(FromAddress, FromName);

                oMailMessage.To.Add(oToAddress);
                oMailMessage.ReplyTo = oReplyAddress;
                oMailMessage.From = oFromAddress;               

                if (!String.IsNullOrEmpty(CC))
                {
                    MailAddress oCC = new MailAddress(CC);
                    oMailMessage.CC.Add(oCC);
                }

                oMailMessage.Subject = Subject;
                oMailMessage.IsBodyHtml = true;

                oMailMessage.Body = Body;
                oSmtpClient.Host = ConfigurationManager.AppSettings["HostEmailServer"].ToString();
                oSmtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["HostEmailPort"].ToString());
                
                oSmtpClient.UseDefaultCredentials = false;

                if (strMailAuthentication.Equals("Y"))
                {
                    /* Email with Authentication */
                    oSmtpClient.Credentials = new NetworkCredential(strUsername, strPassword);
                    //oSmtpClient.EnableSsl = true;
                    oSmtpClient.UseDefaultCredentials = false;
                }

                oSmtpClient.Send(oMailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void LogError(String ErrMessage, String ErrSource)
        {
        }
    }
}
