using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using AnasBimbel.Models;
using AnasBimbel.Messaging;
using log4net;

namespace AnasBimbel.WinServices
{
    public class ReadMessaging
    {
        private Timer timer = new Timer(System.Convert.ToInt32(ConfigurationManager.AppSettings["Timer_Elapse_Time"]));
        private static ILog log = LogManager.GetLogger("AnasBimbel.WinServices.ReadMessaging");
        private MSMQ<KirimModel> messaging;
        private MSMQModel<KirimModel> model;
        public bool Start()
        {
            log.Info("Start starts here");
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            log.Info("Start stops here");
            return true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            log.Info("Timer_Elapsed starts here");
            model = new MSMQModel<KirimModel>();
            model.QueueName = ConfigurationManager.AppSettings["Queue_Name"].ToString();
            messaging = new MSMQ<KirimModel>();
            messaging.ReadEventHandler += Messaging_ReadEventHandler;
            messaging.ReadQueueMessage(model);
            log.Info("Timer_Elapsed stops here");
        }

        private string GetTemplage(KirimModel model)
        {
            StringBuilder template = new StringBuilder();
            template.Append(@"<table width=""800"" border=""0"" cellpadding=""0"" cellspacing=""0"">");
            template.Append(@"<tr>");
            template.Append(@"<td width=""110"">Nama</td>");
            template.Append(@"<td width=""20"">&nbsp;:&nbsp;</td>");
            template.Append(@"<td>");
            template.Append(@"<b>" + model.Name + "</b>");
            template.Append(@"</td>");
            template.Append(@"</tr>");
            template.Append(@"<tr>");
            template.Append(@"<td width=""110"">Email</td>");
            template.Append(@"<td width=""20"">&nbsp;:&nbsp;</td>");
            template.Append(@"<td>");
            template.Append(@"<b>" + model.Email+ "</b>");
            template.Append(@"</td>");
            template.Append(@"</tr>");
            template.Append(@"<tr>");
            template.Append(@"<td width=""110"">Telephone</td>");
            template.Append(@"<td width=""20"">&nbsp;:&nbsp;</td>");
            template.Append(@"<td>");
            template.Append(@"<b>" + model.Telephone + "</b>");
            template.Append(@"</td>");
            template.Append(@"</tr>");
            template.Append(@"<tr>");
            template.Append(@"<td width=""110"" valign=""top"">Pesan</td>");
            template.Append(@"<td width=""20"" valign=""top"">&nbsp;:&nbsp;</td>");
            template.Append(@"<td>");
            template.Append(@"<b>" + model.Message + "</b>");
            template.Append(@"</td>");
            template.Append(@"</tr>");
            template.Append(@"<tr><td colspan=""3"" height=""40"">&nbsp;&nbsp;</td></tr>");
            template.Append(@"<tr>");
            template.Append(@"<td colspan=""3"" align=""center"">");
            template.Append(@"<a href=""mailto:" + model.Email + @"?subject=" + model.Subject + @""" target=""_self"" style=""width:200px;padding:10px;border:2px solid #d9d9d9;"">BALAS</a>");
            template.Append(@"</td>");
            template.Append(@"</tr>");
            template.Append(@"</table>");
            return template.ToString();
        }

        private void Messaging_ReadEventHandler(object sender, EventArgs e)
        {
            log.Info("Messaging_ReadEventHandler starts here");
            try
            {
                KirimModel model = (KirimModel)e;
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(new MailAddress(ConfigurationManager.AppSettings["Mail_To"].ToString(), ConfigurationManager.AppSettings["Mail_To_DisplayName"].ToString()));
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["Mail_From"].ToString(), ConfigurationManager.AppSettings["Mail_From_DisplayName"].ToString());
                mailMessage.Subject = "Anda Mendapat Pesan Dari " + model.Name + " - www.anasbimbel.com";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = GetTemplage(model);

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = ConfigurationManager.AppSettings["SMTP_Host"].ToString();
                smtpClient.Port = Int32.Parse(ConfigurationManager.AppSettings["SMTP_Port"].ToString());
                smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SMTP_Username"].ToString(), ConfigurationManager.AppSettings["SMTP_Password"].ToString());
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.DeliveryFormat = SmtpDeliveryFormat.International;
                smtpClient.Send(mailMessage);

                log.Info("Kirim Pesan Dari " + model.Email);
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
            }

            log.Info("Messaging_ReadEventHandler stops here");
        }

        public bool Stop()
        {
            log.Info("Stops starts here");
            model = new MSMQModel<KirimModel>();
            timer.Stop();
            log.Info("Stops stops here");
            return true;
        }
    }
}
