using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentRental.Data.Entities
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        public int? UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Action { get; set; }

        [Required]
        [StringLength(1000)]
        public string Details { get; set; }

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string? IpAddress { get; set; }

        [StringLength(50)]
        public string? Source { get; set; } // Web or Desktop app

        // Navigation properties
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}