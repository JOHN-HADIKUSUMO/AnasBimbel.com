using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using AnasBimbel.Interfaces;

namespace AnasBimbel.Database
{
    public class DataContext:DbContext,IDataContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
        }
    }
}
