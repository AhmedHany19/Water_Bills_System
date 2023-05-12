using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)     
        {
            base.OnModelCreating(builder);
            builder.Entity<Invoice>().HasOne(a => a.Subscription).WithMany(a => a.Invoices).HasForeignKey(a => a.Subscribetion_Id).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Invoice>().HasOne(a => a.Subscriber).WithMany(a => a.Invoices).HasForeignKey(a => a.Subscriber_Id).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Invoice>().HasOne(a => a.Real_Estate_Type).WithMany(a => a.Invoices).HasForeignKey(a => a.Real_State_Id).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Subscription>().HasOne(a => a.Subscriber).WithMany(a => a.Subscriptions).HasForeignKey(a => a.Subscriber_Id).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Subscription>().HasOne(a => a.Real_Estate_Type).WithMany(a => a.Subscriptions).HasForeignKey(a => a.Real_State_Id).OnDelete(DeleteBehavior.NoAction);


        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Real_Estate_Type> real_Estate_Types { get; set; }
        public DbSet<Default_Slice_Value> Default_Slice_Values { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

    }
}
