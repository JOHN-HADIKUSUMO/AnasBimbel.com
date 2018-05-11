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
    public class SMSMessage
    {
        private string mobileNo;
        private string message;
        public string MobileNo
        {
            get
            {
                if (string.IsNullOrEmpty(mobileNo))
                {
                    mobileNo = ConfigurationManager.AppSettings["SNS_RECIPIENT"].ToString();
                }
                return mobileNo;
            }
            set
            {
                mobileNo = value;
            }
        }
        public string Message
        {
            get
            {
                if (string.IsNullOrEmpty(message))
                {
                    message = ConfigurationManager.AppSettings["SNS_DEFAULT_MESSAGE"].ToString();
                }
                return message;
            }
            set
            {
                message = value;
            }
        }
    }
}
