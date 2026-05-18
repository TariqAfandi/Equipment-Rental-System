using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rental_System_db.Entities
{
    [Index("UserId", Name = "IX_Logs_UserId")]
    public partial class Log
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        [StringLength(50)]
        public string Action { get; set; } = null!;
        [StringLength(1000)]
        public string Details { get; set; } = null!;
        public DateTime Timestamp { get; set; }
        [StringLength(50)]
        public string? IpAddress { get; set; }
        [StringLength(50)]
        public string? Source { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Logs")]
        public virtual User? User { get; set; }
    }
}
