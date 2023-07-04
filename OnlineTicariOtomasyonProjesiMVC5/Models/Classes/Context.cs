using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnlineTicariOtomasyonProjesiMVC5.Models.Classes
{
    public class Context: DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Current> Currents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<InvoicePencil> InvoicePencils { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SaleTransaction> SaleTransactions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }

        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<CargoTracking> CargoTrackings { get; set; }
        public DbSet<CargoDetails> CargoDetails { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}