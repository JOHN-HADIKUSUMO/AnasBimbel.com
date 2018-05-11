using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace AnasBimbel.Models
{
    public class SMSSettings
    {
        private string senderId;
        private string smsType;
        private decimal maxPrice; /* in USD */

        public string SenderId
        {
            get
            {
                if (string.IsNullOrEmpty(senderId))
                {
                    senderId = ConfigurationManager.AppSettings["SNS_SENDER_ID"].ToString();
                }
                return senderId;
            }
            set
            {
                senderId = value;
            }
        }
        public string SMSType
        {
            get
            {
                if (string.IsNullOrEmpty(smsType))
                {
                    smsType = ConfigurationManager.AppSettings["SNS_SMS_TYPE"].ToString();
                }
                return smsType;
            }
            set
            {
                smsType = value;
            }
        }

        public decimal MaxPrice
        {
            get
            {
                if (maxPrice <= 0)
                {
                    maxPrice = decimal.Parse(ConfigurationManager.AppSettings["SNS_MAX_PRICE"].ToString());
                }
                return maxPrice;
            }
            set
            {
                maxPrice = value;
            }
        }
    }
}
