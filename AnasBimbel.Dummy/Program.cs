using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using AnasBimbel.Models;
using AnasBimbel.Messaging;

namespace AnasBimbel.Dummy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<KirimModel> list = new List<KirimModel>() {
                new KirimModel("John Hadikusumo","0431343034","john.hadikusumo@gmail.com","Registration","Your registration is complete"),
                new KirimModel("Masdi Chandra","042724022","mchandra@gmail.com","Forget Password","Your password has been resetted"),
                new KirimModel("Diana Mangunsong","047032995","dianam@yahoo.com","Registration","Your registration is complete"),
                new KirimModel("Robert Raharjo","048820104","robera@gmail.com","Registration","Your registration is complete"),
                new KirimModel("Kathy Sondak","049211525","kathysondak@gmail.com","Registration","Your registration is complete"),
                new KirimModel("Lilian Wu","046455532","lilian.wu@gmail.com","Registration","Your registration is complete"),
                new KirimModel("Freddy Mc Mahon","04230078","freddy@gmail.com","Registration","Your registration is complete"),
                new KirimModel("Ram Ram Don","0431343034","ramramdon@gmail.com","Registration","Your registration is complete"),
                new KirimModel("Suratj Pakir","044673079","suratjpakir@gmail.com","Forget Password","Your password has been resetted"),
                new KirimModel("Simon Ryu","04620039","simonryu@gmail.com","Registration","Your registration is complete"),
                new KirimModel("Rhea Tobari","048832044","rheasim@gmail.com","Registration","Your registration is complete")
        };
            for (int i = 0; i < list.Count; i++)
            {
                MSMQModel<KirimModel> model = new MSMQModel<KirimModel>();
                model.QueueName = ConfigurationManager.AppSettings["Queue_Name"].ToString();
                model.QueueMessage = list[i];
                MSMQ<KirimModel> msmq = new MSMQ<KirimModel>();
                string id = msmq.WriteQueueMessage(model);
                Console.WriteLine("Id => " + id);
            }
            Console.ReadLine();
        }
    }
}
