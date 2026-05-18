using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace EquipmentRental.Data.Entities
{
    public class RentalTransaction
    {
        public RentalTransaction()
        {
            Documents = new HashSet<Document>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int RentalRequestId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int EquipmentId { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime ActualStartDate { get; set; }

        [Required]
        public DateTime ExpectedReturnDate { get; set; }

        public DateTime? ActualReturnDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RentalFee { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DepositAmount { get; set; }

        [Required]
        [StringLength(20)]
        public string PaymentStatus { get; set; } = "Pending"; // Pending, Paid, Refunded, Overdue

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Active"; // Active, Completed, Overdue, Cancelled

        [StringLength(500)]
        public string? Notes { get; set; }

        // Navigation properties
        [ForeignKey("RentalRequestId")]
        public virtual RentalRequest RentalRequest { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipment { get; set; }

        public virtual ReturnRecord? ReturnRecord { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}