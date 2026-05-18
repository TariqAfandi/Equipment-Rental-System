using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rental_System_db.Entities
{
    [Index("EquipmentId", Name = "IX_RentalTransactions_EquipmentId")]
    [Index("RentalRequestId", Name = "IX_RentalTransactions_RentalRequestId", IsUnique = true)]
    [Index("UserId", Name = "IX_RentalTransactions_UserId")]
    public partial class RentalTransaction
    {
        public RentalTransaction()
        {
            Documents = new HashSet<Document>();
            Feedbacks = new HashSet<Feedback>();
        }

        [Key]
        public int Id { get; set; }
        public int RentalRequestId { get; set; }
        public int UserId { get; set; }
        public int EquipmentId { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RentalFee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DepositAmount { get; set; }
        [StringLength(20)]
        public string PaymentStatus { get; set; } = null!;
        [StringLength(20)]
        public string Status { get; set; } = null!;
        [StringLength(500)]
        public string? Notes { get; set; }

        [ForeignKey("EquipmentId")]
        [InverseProperty("RentalTransactions")]
        public virtual Equipment Equipment { get; set; } = null!;
        [ForeignKey("RentalRequestId")]
        [InverseProperty("RentalTransaction")]
        public virtual RentalRequest RentalRequest { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("RentalTransactions")]
        public virtual User User { get; set; } = null!;
        [InverseProperty("RentalTransaction")]
        public virtual ReturnRecord? ReturnRecord { get; set; }
        [InverseProperty("RentalTransaction")]
        public virtual ICollection<Document> Documents { get; set; }
        [InverseProperty("RentalTransaction")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
