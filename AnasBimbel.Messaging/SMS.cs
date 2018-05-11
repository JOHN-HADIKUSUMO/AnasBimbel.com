using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.IO;
using Newtonsoft.Json;
using AnasBimbel.Models;
using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace AnasBimbel.Messaging
{
    public class SMS
    {
        private SMSSettings settings;
        private SMSSecurity security;
        private SMSMessage message;

        public SMSSettings Settings
        {
            get
            {
                return settings;
            }

            set
            {
                settings = value;
            }
        }

        public SMSSecurity Security
        {
            get
            {
                return security;
            }

            set
            {
                security = value;
            }
        }

        public SMSMessage Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public SMS()
        {
            settings = new SMSSettings();
            security = new SMSSecurity();
            message = new SMSMessage();
    }

        public SMS(SMSSettings _settings,SMSSecurity _security,SMSMessage _message)
        {
            settings = _settings;
            security = _security;
            message = _message;
        }

        public bool Send()
        {
            bool status = true;
            try
            {
                AmazonSimpleNotificationServiceClient smsClient = new AmazonSimpleNotificationServiceClient(security.AccessKeyId, security.SecretKeyId, security.Region);
                PublishRequest request = new PublishRequest();
                PublishResponse response = new PublishResponse();
                Dictionary<string, MessageAttributeValue> attributes = new Dictionary<string, MessageAttributeValue>();
                attributes.Add("AWS.SNS.SMS.SenderID", new MessageAttributeValue() { DataType = "String", StringValue = settings.SenderId });
                attributes.Add("AWS.SNS.SMS.SMSType", new MessageAttributeValue() { DataType = "String", StringValue = settings.SMSType });
                attributes.Add("AWS.SNS.SMS.MaxPrice", new MessageAttributeValue() { DataType = "String", StringValue = settings.MaxPrice.ToString() });
                request.MessageAttributes = attributes;
                request.PhoneNumber = message.MobileNo;
                request.Message = message.Message;
                response = smsClient.Publish(request);
            }
            catch(Exception ex)
            {
                status = false;
            }

            return status;
        }
    }
}
