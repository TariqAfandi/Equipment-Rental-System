using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.Data.Entities
{
    public class User
    {
        public User()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Role = string.Empty;
            PhoneNumber = null;
            RentalRequests = new HashSet<RentalRequest>();
            RentalTransactions = new HashSet<RentalTransaction>();
            Feedbacks = new HashSet<Feedback>();
            Notifications = new HashSet<Notification>();
            Logs = new HashSet<Log>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; } // Administrator, RentalManager, Customer

        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ICollection<RentalRequest> RentalRequests { get; set; }
        public virtual ICollection<RentalTransaction> RentalTransactions { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}