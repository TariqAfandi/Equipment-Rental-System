using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rental_System_db.Entities
{
    [Index("EquipmentId", Name = "IX_RentalRequests_EquipmentId")]
    [Index("ProcessedByUserId", Name = "IX_RentalRequests_ProcessedByUserId")]
    [Index("UserId", Name = "IX_RentalRequests_UserId")]
    public partial class RentalRequest
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EquipmentId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        [StringLength(20)]
        public string Status { get; set; } = null!;
        [StringLength(500)]
        public string? Notes { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalCost { get; set; }
        public int? ProcessedByUserId { get; set; }
        public DateTime? ProcessedDate { get; set; }

        [ForeignKey("EquipmentId")]
        [InverseProperty("RentalRequests")]
        public virtual Equipment Equipment { get; set; } = null!;
        [ForeignKey("ProcessedByUserId")]
        [InverseProperty("RentalRequestProcessedByUsers")]
        public virtual User? ProcessedByUser { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("RentalRequestUsers")]
        public virtual User User { get; set; } = null!;
        [InverseProperty("RentalRequest")]
        public virtual RentalTransaction? RentalTransaction { get; set; }
    }
}
