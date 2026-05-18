using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.Web.Models.ViewModels
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Equipment is required")]
        [Display(Name = "Equipment")]
        public int EquipmentId { get; set; }

        // Display info
        public string EquipmentName { get; set; }

        // Optional transaction reference
        [Display(Name = "Rental Transaction")]
        public int? RentalTransactionId { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        [Display(Name = "Rating (1-5)")]
        public int Rating { get; set; }

        [Display(Name = "Comment")]
        [StringLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters")]
        public string Comment { get; set; }
    }
}