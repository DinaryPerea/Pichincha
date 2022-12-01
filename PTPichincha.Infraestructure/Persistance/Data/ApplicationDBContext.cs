using Microsoft.EntityFrameworkCore;
using PTPichincha.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Infraestructure.Persistance.Data
{
    public  class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }

        //Entities for tables
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Person> Person { get; set; }   
    }
}
