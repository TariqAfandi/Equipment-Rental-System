using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace rental_System_db.Entities
{
    [Index("RentalTransactionId", Name = "IX_Documents_RentalTransactionId")]
    [Index("UserId", Name = "IX_Documents_UserId")]
    public partial class Document
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? RentalTransactionId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; } = null!;
        [StringLength(100)]
        public string FileType { get; set; } = null!;
        [StringLength(500)]
        public string FilePath { get; set; } = null!;
        public DateTime UploadDate { get; set; }
        [StringLength(255)]
        public string? Description { get; set; }

        [ForeignKey("RentalTransactionId")]
        [InverseProperty("Documents")]
        public virtual RentalTransaction? RentalTransaction { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Documents")]
        public virtual User User { get; set; } = null!;
    }
}
