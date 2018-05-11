using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.IO;
using Newtonsoft.Json;
using AnasBimbel.Models;
using Topshelf;
using log4net;

namespace AnasBimbel.Messaging
{
    public class MSMQ<TObject>
    {
        private static ILog log = LogManager.GetLogger("AnasBimbel.Messaging.MSMQ");
        public event EventHandler<TObject> ReadEventHandler;
        public MSMQ()
        {
            log.Info("Constructor is called");
        }

        public string WriteQueueMessage(MSMQModel<KirimModel> model)
        {
            MessageQueue messageQueue;
            string queueId = string.Empty;
            string queueName = model.QueueName; /* Example @".\Private\satuindonesia" */
            string queueMessage = JsonConvert.SerializeObject(model.QueueMessage);
            if (!MessageQueue.Exists(queueName))
            {
                messageQueue = MessageQueue.Create(queueName, true);
            }
            else
            {
                messageQueue = new MessageQueue(queueName);
            }
            Message message = new Message(queueMessage);
            messageQueue.Send(message, MessageQueueTransactionType.Single);
            queueId = message.Id;
            messageQueue.Close();
            return queueId;
        }


        public void ReadQueueMessage(MSMQModel<TObject> model)
        {
            log.Info("ReadQueueMessage starts here");
            try
            {
                MessageQueue messageQueue;
                string queueName = model.QueueName;
                string queueId = string.Empty;
                if (!MessageQueue.Exists(queueName))
                {
                    messageQueue = MessageQueue.Create(queueName, true);
                }
                else
                {
                    messageQueue = new MessageQueue(queueName);
                }

                messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });
                messageQueue.ReceiveCompleted += MessageQueue_ReceiveCompleted;
                messageQueue.BeginReceive();
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
            }

            log.Info("ReadQueueMessage stops here");
        }

        private void MessageQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            log.Info("MessageQueue_ReceiveCompleted starts here");
            MessageQueue messageQueue = (MessageQueue)sender;
            Message message = messageQueue.EndReceive(e.AsyncResult);
            TObject item = JsonConvert.DeserializeObject<TObject>((string)message.Body);
            EventHandler<TObject> handler = ReadEventHandler;
            if(handler != null)
            {
                handler.Invoke(this, item);
            }
            messageQueue.BeginReceive();
            log.Info("MessageQueue_ReceiveCompleted stops here");
            return;
        }
    }
}
