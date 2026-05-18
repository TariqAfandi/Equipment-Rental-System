using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentRental.Data.Entities
{
    public class RentalRequest
    {
        public RentalRequest()
        {
            Status = "Pending";
            Notes = null;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int EquipmentId { get; set; }

        [Required]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime RentalStartDate { get; set; }

        [Required]
        public DateTime RentalEndDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } // Pending, Approved, Rejected, Completed, Cancelled

        [StringLength(500)]
        public string? Notes { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalCost { get; set; }

        public int? ProcessedByUserId { get; set; }

        public DateTime? ProcessedDate { get; set; }

        // Navigation properties
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

        [ForeignKey("EquipmentId")]
        public virtual Equipment? Equipment { get; set; }

        [ForeignKey("ProcessedByUserId")]
        public virtual User? ProcessedByUser { get; set; }

        public virtual RentalTransaction? RentalTransaction { get; set; }
    }
}