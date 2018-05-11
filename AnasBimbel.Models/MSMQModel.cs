using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnasBimbel.Models
{
    public class MSMQModel<TObject>
    {
        public string QueueName { get; set; }
        public TObject QueueMessage { get; set; }
    }
}
