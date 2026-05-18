using EquipmentRental.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EquipmentRental.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Equipment> Equipment { get; set; } = null!;
        public DbSet<RentalRequest> RentalRequests { get; set; } = null!;
        public DbSet<RentalTransaction> RentalTransactions { get; set; } = null!;
        public DbSet<ReturnRecord> ReturnRecords { get; set; } = null!;
        public DbSet<Feedback> Feedback { get; set; } = null!;
        public DbSet<Document> Documents { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;
        public DbSet<Log> Logs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Custom configurations

            // User
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Equipment
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Equipment)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // RentalRequest
            modelBuilder.Entity<RentalRequest>()
                .HasOne(r => r.User)
                .WithMany(u => u.RentalRequests)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RentalRequest>()
                .HasOne(r => r.Equipment)
                .WithMany(e => e.RentalRequests)
                .HasForeignKey(r => r.EquipmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // RentalTransaction
            modelBuilder.Entity<RentalTransaction>()
                .HasOne(t => t.RentalRequest)
                .WithOne(r => r.RentalTransaction)
                .HasForeignKey<RentalTransaction>(t => t.RentalRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RentalTransaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.RentalTransactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RentalTransaction>()
                .HasOne(t => t.Equipment)
                .WithMany(e => e.RentalTransactions)
                .HasForeignKey(t => t.EquipmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // ReturnRecord
            modelBuilder.Entity<ReturnRecord>()
                .HasOne(r => r.RentalTransaction)
                .WithOne(t => t.ReturnRecord)
                .HasForeignKey<ReturnRecord>(r => r.RentalTransactionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Feedback
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.User)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Equipment)
                .WithMany(e => e.Feedbacks)
                .HasForeignKey(f => f.EquipmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Document
            modelBuilder.Entity<Document>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Notification
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Log
            modelBuilder.Entity<Log>()
                .HasOne(l => l.User)
                .WithMany(u => u.Logs)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Data - Admin User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "System Administrator",
                    Email = "admin@equipmentrental.com",
                    Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", // admin
                    Role = "Administrator",
                    CreatedAt = DateTime.Now,
                    IsActive = true
                }
            );

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Power Tools",
                    Description = "Electric and battery-powered tools for construction and DIY projects",
                    CreatedAt = DateTime.Now,
                    IsActive = true
                },
                new Category
                {
                    Id = 2,
                    Name = "Camera Equipment",
                    Description = "Professional cameras and accessories for photography and videography",
                    CreatedAt = DateTime.Now,
                    IsActive = true
                },
                new Category
                {
                    Id = 3,
                    Name = "Construction Equipment",
                    Description = "Heavy machinery and equipment for construction projects",
                    CreatedAt = DateTime.Now,
                    IsActive = true
                },
                new Category
                {
                    Id = 4,
                    Name = "Event Supplies",
                    Description = "Chairs, tables, tents, and other supplies for events and parties",
                    CreatedAt = DateTime.Now,
                    IsActive = true
                }
            );

            // Seed Sample Equipment
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment
                {
                    Id = 1,
                    Name = "Electric Drill",
                    Description = "Powerful electric drill with variable speed settings",
                    CategoryId = 1,
                    RentalPrice = 25.00m,
                    AvailabilityStatus = "Available",
                    ConditionStatus = "Good",
                    DepositAmount = 50.00m,
                    CreatedAt = DateTime.Now
                },
                new Equipment
                {
                    Id = 2,
                    Name = "DSLR Camera",
                    Description = "Professional DSLR camera with 24.2MP sensor",
                    CategoryId = 2,
                    RentalPrice = 75.00m,
                    AvailabilityStatus = "Available",
                    ConditionStatus = "New",
                    DepositAmount = 200.00m,
                    CreatedAt = DateTime.Now
                },
                new Equipment
                {
                    Id = 3,
                    Name = "Concrete Mixer",
                    Description = "Electric concrete mixer with 63L capacity",
                    CategoryId = 3,
                    RentalPrice = 120.00m,
                    AvailabilityStatus = "Available",
                    ConditionStatus = "Good",
                    DepositAmount = 300.00m,
                    CreatedAt = DateTime.Now
                },
                new Equipment
                {
                    Id = 4,
                    Name = "Folding Tables (set of 5)",
                    Description = "Sturdy folding tables for events, measuring 6ft x 2.5ft each",
                    CategoryId = 4,
                    RentalPrice = 50.00m,
                    AvailabilityStatus = "Available",
                    ConditionStatus = "Good",
                    DepositAmount = 100.00m,
                    CreatedAt = DateTime.Now
                }
            );
        }
    }
}