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
    public class SMSSecurity
    {
        private string accessKeyId;
        private string secretKeyId;
        private Amazon.RegionEndpoint region;

        public string AccessKeyId {
            get
            {
                if(string.IsNullOrEmpty(accessKeyId))
                {
                    accessKeyId = ConfigurationManager.AppSettings["SNS_ACCESS_KEY"].ToString();
                }
                return accessKeyId;
            }
            set
            {
                accessKeyId = value;
            }
        }
        public string SecretKeyId
        {
            get
            {
                if (string.IsNullOrEmpty(secretKeyId))
                {
                    secretKeyId = ConfigurationManager.AppSettings["SNS_SECRET_KEY"].ToString();
                }
                return secretKeyId;
            }
            set
            {
                secretKeyId = value;
            }
        }

        public Amazon.RegionEndpoint Region
        {
            get
            {
                if (region == null)
                {
                    region = Amazon.RegionEndpoint.GetBySystemName(ConfigurationManager.AppSettings["SNS_REGION"].ToString());
                }
                return region;
            }
            set
            {
                region = value;
            }
        }
    }
}
