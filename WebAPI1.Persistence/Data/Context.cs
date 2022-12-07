using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI1.Application.Interfaces;
using WebAPI1.Domain.Models;

namespace WebAPI1.Persistence.Data
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentsList> ComponentsLists { get; set; }
        public DbSet<ServicesList> ServicesLists { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TypeComponent> TypeComponents { get; set; }
        public DbSet<ComputerOrder> ComputerOrders { get; set; }
        public DbSet<ComputerService> ComputerServices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
