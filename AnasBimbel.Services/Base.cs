using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using AnasBimbel.Database;
using AnasBimbel.Interfaces;

namespace AnasBimbel.Services
{
    public abstract class Base
    {
        protected DataContext datacontext;
        public Base(IDataContext datacontext)
        {
            this.datacontext = (DataContext)datacontext;
        }
    }
}
