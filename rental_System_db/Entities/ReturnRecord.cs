using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rental_System_db.Entities
{
    [Index("ProcessedByUserId", Name = "IX_ReturnRecords_ProcessedByUserId")]
    [Index("RentalTransactionId", Name = "IX_ReturnRecords_RentalTransactionId", IsUnique = true)]
    public partial class ReturnRecord
    {
        [Key]
        public int Id { get; set; }
        public int RentalTransactionId { get; set; }
        public DateTime ReturnDate { get; set; }
        [StringLength(20)]
        public string ReturnCondition { get; set; } = null!;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? LateFee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DamageFee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? RefundAmount { get; set; }
        public int ProcessedByUserId { get; set; }
        [StringLength(500)]
        public string? Notes { get; set; }

        [ForeignKey("ProcessedByUserId")]
        [InverseProperty("ReturnRecords")]
        public virtual User ProcessedByUser { get; set; } = null!;
        [ForeignKey("RentalTransactionId")]
        [InverseProperty("ReturnRecord")]
        public virtual RentalTransaction RentalTransaction { get; set; } = null!;
    }
}
