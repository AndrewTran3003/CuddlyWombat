using CuddlyWombat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Data
{
    public class CuddlyWombatContext:DbContext
    {
        public CuddlyWombatContext(DbContextOptions<CuddlyWombatContext> options)
            :base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<ItemJMenu> ItemJMenus { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderJItem> OrderItems { get; set; }
        public DbSet <OrderJMenu> OrderMenus { get; set; }
        
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentJOrder> PaymentOrder { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<PaymentJReceipt> PaymentReceipt { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Menu>().ToTable("Menus");
            modelBuilder.Entity<ItemJMenu>().ToTable("ItemMenu");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderJItem>().ToTable("OrderItems");
            modelBuilder.Entity<OrderJMenu>().ToTable("OrderMenus");
            modelBuilder.Entity<Payment>().ToTable("Payment");
            modelBuilder.Entity<PaymentJOrder>().ToTable("PaymentOrder");
            modelBuilder.Entity<Receipt>().ToTable("Receipts");
            modelBuilder.Entity<PaymentJReceipt>().ToTable("PaymentReceipt");
        }


    }
}
