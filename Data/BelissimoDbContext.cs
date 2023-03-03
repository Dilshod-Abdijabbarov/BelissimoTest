using Domian.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DatabaseContext
{
    public class BelissimoDbContext : DbContext
    {

        public BelissimoDbContext(DbContextOptions<BelissimoDbContext> options) : base(options)
        {

        }
        

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodOrder> FoodOrders { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
