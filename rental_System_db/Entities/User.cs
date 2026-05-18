using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rental_System_db.Entities
{
    [Index("Email", Name = "IX_Users_Email", IsUnique = true)]
    public partial class User
    {
        public User()
        {
            Documents = new HashSet<Document>();
            Feedbacks = new HashSet<Feedback>();
            Logs = new HashSet<Log>();
            Notifications = new HashSet<Notification>();
            RentalRequestProcessedByUsers = new HashSet<RentalRequest>();
            RentalRequestUsers = new HashSet<RentalRequest>();
            RentalTransactions = new HashSet<RentalTransaction>();
            ReturnRecords = new HashSet<ReturnRecord>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [StringLength(100)]
        public string Email { get; set; } = null!;
        [StringLength(255)]
        public string Password { get; set; } = null!;
        [StringLength(20)]
        public string Role { get; set; } = null!;
        [StringLength(15)]
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Document> Documents { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Log> Logs { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Notification> Notifications { get; set; }
        [InverseProperty("ProcessedByUser")]
        public virtual ICollection<RentalRequest> RentalRequestProcessedByUsers { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<RentalRequest> RentalRequestUsers { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<RentalTransaction> RentalTransactions { get; set; }
        [InverseProperty("ProcessedByUser")]
        public virtual ICollection<ReturnRecord> ReturnRecords { get; set; }
    }
}
