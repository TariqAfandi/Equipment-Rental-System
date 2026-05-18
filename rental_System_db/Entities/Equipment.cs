using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rental_System_db.Entities
{
    [Index("CategoryId", Name = "IX_Equipment_CategoryId")]
    public partial class Equipment
    {
        public Equipment()
        {
            Feedbacks = new HashSet<Feedback>();
            RentalRequests = new HashSet<RentalRequest>();
            RentalTransactions = new HashSet<RentalTransaction>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [StringLength(1000)]
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RentalPrice { get; set; }
        [StringLength(20)]
        public string AvailabilityStatus { get; set; } = null!;
        [StringLength(20)]
        public string ConditionStatus { get; set; } = null!;
        [StringLength(255)]
        public string? ImageUrl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DepositAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastMaintenanceDate { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Equipment")]
        public virtual Category Category { get; set; } = null!;
        [InverseProperty("Equipment")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        [InverseProperty("Equipment")]
        public virtual ICollection<RentalRequest> RentalRequests { get; set; }
        [InverseProperty("Equipment")]
        public virtual ICollection<RentalTransaction> RentalTransactions { get; set; }
    }
}
