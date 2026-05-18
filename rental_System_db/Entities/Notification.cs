using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rental_System_db.Entities
{
    [Index("UserId", Name = "IX_Notifications_UserId")]
    public partial class Notification
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [StringLength(100)]
        public string Title { get; set; } = null!;
        [StringLength(1000)]
        public string Message { get; set; } = null!;
        [StringLength(20)]
        public string Type { get; set; } = null!;
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ReadAt { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Notifications")]
        public virtual User User { get; set; } = null!;
    }
}
