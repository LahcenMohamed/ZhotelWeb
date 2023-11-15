using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHotelWeb.Models;

namespace ZhotelWeb.Repositories
{
    public class ZHotelDbContext : IdentityDbContext
    {
        public ZHotelDbContext()
        {
            
        }
        public ZHotelDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=ZHotelWebDB;integrated security=True;Encrypt=False;MultipleActiveResultSets=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
    }
}
