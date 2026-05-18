using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentRental.Data.Entities
{
    public class Equipment
    {
        public Equipment()
        {
            Name = string.Empty;
            Description = null;
            AvailabilityStatus = "Available";
            ConditionStatus = "Good";
            ImageUrl = null;
            RentalRequests = new HashSet<RentalRequest>();
            RentalTransactions = new HashSet<RentalTransaction>();
            Feedbacks = new HashSet<Feedback>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal RentalPrice { get; set; }

        [Required]
        [StringLength(20)]
        public string AvailabilityStatus { get; set; } // Available, Unavailable, UnderMaintenance

        [Required]
        [StringLength(20)]
        public string ConditionStatus { get; set; } // New, Good, Fair, Damaged

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DepositAmount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? LastMaintenanceDate { get; set; }

        // Navigation properties
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        public virtual ICollection<RentalRequest> RentalRequests { get; set; }
        public virtual ICollection<RentalTransaction> RentalTransactions { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}