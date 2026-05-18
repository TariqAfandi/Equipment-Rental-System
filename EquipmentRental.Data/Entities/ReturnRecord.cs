using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentRental.Data.Entities
{
    public class ReturnRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RentalTransactionId { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(20)]
        public string ReturnCondition { get; set; } = "Good"; // Good, Damaged, Lost

        [Column(TypeName = "decimal(18,2)")]
        public decimal? LateFee { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DamageFee { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? RefundAmount { get; set; } = 0;

        [Required]
        public int ProcessedByUserId { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        // Navigation properties
        [ForeignKey("RentalTransactionId")]
        public virtual RentalTransaction RentalTransaction { get; set; }

        [ForeignKey("ProcessedByUserId")]
        public virtual User ProcessedByUser { get; set; }
    }
}