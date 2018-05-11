using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using AnasBimbel.Models;
using AnasBimbel.Messaging;

namespace AnasBimble.Controllers.API
{
    [RoutePrefix("API/EMAIL")]
    public class EmailController : ApiController
    {
        [Route("KIRIM")]
        public async Task<bool> Kirim(KirimModel model)
        {
            bool result = await Task.Run<bool>(() => {
                MSMQModel<KirimModel> newmodel = new MSMQModel<KirimModel>();
                newmodel.QueueMessage = model;
                newmodel.QueueName = ConfigurationManager.AppSettings["Queue_Name"].ToString();
                MSMQ<KirimModel> msmq = new MSMQ<KirimModel>();
                msmq.WriteQueueMessage(newmodel);

                SMSMessage message = new SMSMessage();
                message.Message = message.Message.Replace("{PENGIRIM}", model.Name).Replace("{NEWLINE}",Environment.NewLine + Environment.NewLine);

                SMS sms = new SMS();
                sms.Message = message;
                sms.Send();
                return true;
            });
            return result;
        }
    }
}
