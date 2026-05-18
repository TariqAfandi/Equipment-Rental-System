using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.Data.Entities
{
    public class Category
    {
        public Category()
        {
            Name = string.Empty;
            Description = null;
            Equipment = new HashSet<Equipment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}