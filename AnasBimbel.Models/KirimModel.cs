using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnasBimbel.Models
{
    public class KirimModel: EventArgs
    {
        public KirimModel(string name,string telephone,string email,string subject,string message)
        {
            Name = name;
            Telephone = telephone;
            Email = email;
            Subject = subject;
            Message = message;
        }

        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}