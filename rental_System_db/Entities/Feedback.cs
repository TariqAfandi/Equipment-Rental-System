using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rental_System_db.Entities
{
    [Table("Feedback")]
    [Index("EquipmentId", Name = "IX_Feedback_EquipmentId")]
    [Index("RentalTransactionId", Name = "IX_Feedback_RentalTransactionId")]
    [Index("UserId", Name = "IX_Feedback_UserId")]
    public partial class Feedback
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EquipmentId { get; set; }
        public int? RentalTransactionId { get; set; }
        public DateTime FeedbackDate { get; set; }
        public int Rating { get; set; }
        [StringLength(1000)]
        public string? Comment { get; set; }
        public bool IsVisible { get; set; }

        [ForeignKey("EquipmentId")]
        [InverseProperty("Feedbacks")]
        public virtual Equipment Equipment { get; set; } = null!;
        [ForeignKey("RentalTransactionId")]
        [InverseProperty("Feedbacks")]
        public virtual RentalTransaction? RentalTransaction { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Feedbacks")]
        public virtual User User { get; set; } = null!;
    }
}
