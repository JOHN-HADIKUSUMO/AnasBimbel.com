using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace AnasBimbel.WinServices
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(serviceConfig => 
            {
                serviceConfig.Service<ReadMessaging>(serviceInstance => {
                    serviceInstance.ConstructUsing(()=> new ReadMessaging());
                serviceInstance.WhenStarted(execute => execute.Start());
                    serviceInstance.WhenStopped(execute => execute.Stop());
                });
                serviceConfig.SetServiceName("AnasBimbelEmailServices");
                serviceConfig.SetDisplayName("AnasBimbel Email Services");
                serviceConfig.SetDescription("To send customer email to fanganas@gmail.com");
                serviceConfig.StartAutomaticallyDelayed();
            });
        }
    }
}
