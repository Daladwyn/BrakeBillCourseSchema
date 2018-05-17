using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BrakeBillCourseSchema.Models
{
    public class BrakeBillDbContext: DbContext
    {
        public BrakeBillDbContext() : base("BrakeBillDbConnection")
        {

        }
        //public DbSet<Customer> Customers { get; set; }
    }
}