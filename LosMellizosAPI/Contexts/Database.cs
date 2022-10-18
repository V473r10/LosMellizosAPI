using LosMellizosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LosMellizosAPI.Contexts
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options) { }

        public DbSet<Order>? Orders { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<CustomerClass>? CustomerClasses { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Category>? Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Category> initCategories = new()
            {
                new Category { Id = 1, Name = "Mantequillas de mani", Description = "Completamente natural. Sin azucar.", Active = true },
            };

            List<Product> initProducts = new()
            {
                new Product { Id = Guid.NewGuid(), Name = "Mantequilla de mani clasica", Description = "Puro mani", Price = 250, Stock = 10, CategoryId = 1, Active = true },
                new Product { Id = Guid.NewGuid(), Name = "Mantequilla de mani con cacao amargo", Description = "Puro mani con cacao amargo", Price = 250, Stock = 10, CategoryId = 1, Active = true },
                new Product { Id = Guid.NewGuid(), Name = "Mantequilla de mani con dulce de leche", Description = "Puro mani con dulce de leche", Price = 250, Stock = 10, CategoryId = 1, Active = true },
                new Product { Id = Guid.NewGuid(), Name = "Mantequilla de mani con stevia", Description = "Puro mani endulzado con stevia", Price = 250, Stock = 10, CategoryId = 1, Active = true },
                new Product { Id = Guid.NewGuid(), Name = "Mantequilla de mani con proteina", Description = "Puro mani con proteina", Price = 290, Stock = 10, CategoryId = 1, Active = true },
            };

            List<User> initUsers = new()
            {
                new User { Id = 1, Name = "Facundo Valerio", Email = "fvalerio@losmellizos.com", Phone = "098000000", UserName = "valerio", Password = "v473r10", Role = "Dev", Active = true },
                new User { Id = 2, Name = "Rafael Henriquez", Email = "rhenriquez@losmellizos.com", Phone = "099000000", UserName = "rafa", Password = "user", Role = "Admin", Active = true },
            };

            List<CustomerClass> customerClasses = new()
            {
                new CustomerClass { Id = 1, Name = "Bronze", Threshold = 1000, Discount = 5 },
                new CustomerClass { Id = 2, Name = "Silver", Threshold = 1500, Discount = 10 },
                new CustomerClass { Id = 3, Name = "Gold", Threshold = 2500, Discount = 20 }

            };

            modelBuilder.Entity<Customer>(customer =>
            {
                customer.ToTable("Customers");
                customer.HasKey(c => c.Id);
                customer.Property(c => c.Id).ValueGeneratedOnAdd();
                customer.Property(c => c.FirstName).IsRequired();
                customer.Property(c => c.LastName).IsRequired();
                customer.Property(c => c.UserName).IsRequired();
                customer.Property(c => c.Email).IsRequired();
                customer.Property(c => c.Password).IsRequired();
                customer.Property(c => c.Address).IsRequired();
                customer.Property(c => c.City).IsRequired();
                customer.Property(c => c.State).IsRequired();
                customer.Property(c => c.Phone).IsRequired();
                customer.Property(c => c.Class).IsRequired();
                customer.HasOne(c => c.CustomerClass).WithMany(c => c.Customers).HasForeignKey(c => c.Class);
            });

            modelBuilder.Entity<CustomerClass>(customerClass =>
            {
                customerClass.ToTable("CustomerClasses");
                customerClass.HasKey(c => c.Id);
                customerClass.Property(c => c.Id).ValueGeneratedOnAdd();
                customerClass.Property(c => c.Name).IsRequired();
                customerClass.Property(c => c.Threshold).IsRequired();
                customerClass.Property(c => c.Discount).IsRequired();

                customerClass.HasData(customerClasses);
            });

            modelBuilder.Entity<Order>(order =>
            {
                order.ToTable("Orders");
                order.HasKey(o => o.Id);
                order.Property(o => o.Id).ValueGeneratedOnAdd();
                order.Property(o => o.CustomerId).IsRequired();
                order.Property(o => o.Address).IsRequired();
                order.Property(o => o.ListPrice).IsRequired();
                order.Property(o => o.Discount).IsRequired();
                order.Property(o => o.TotalPrice).IsRequired();
                order.Property(o => o.CreateDate).IsRequired();
                order.Property(o => o.UpdateDate).IsRequired();
                order.Property(o => o.DeliveryDate).IsRequired();
                order.Property(o => o.Status).IsRequired();
                order.HasOne(o => o.Customer).WithMany(o => o.Orders).HasForeignKey(o => o.CustomerId);
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.ToTable("Products");
                product.HasKey(p => p.Id);
                product.Property(p => p.Id).ValueGeneratedOnAdd();
                product.Property(p => p.CategoryId).IsRequired();
                product.Property(p => p.Name).IsRequired();
                product.Property(p => p.Description).IsRequired();
                product.Property(p => p.Price).IsRequired();
                product.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId);

                product.HasData(initProducts);

            });

            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Categories");
                category.HasKey(c => c.Id);
                category.Property(c => c.Id).ValueGeneratedOnAdd();
                category.Property(c => c.Name).IsRequired();

                category.HasData(initCategories);
            });

            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("Users");
                user.HasKey(u => u.Id);
                user.Property(u => u.Id).ValueGeneratedOnAdd();
                user.Property(u => u.Name).IsRequired();
                user.Property(u => u.UserName).IsRequired();
                user.Property(u => u.Email).IsRequired();
                user.Property(u => u.Phone).IsRequired();
                user.Property(u => u.Password).IsRequired();
                user.Property(u => u.Role).IsRequired();

                user.HasData(initUsers);
            });

        }
    }
}
