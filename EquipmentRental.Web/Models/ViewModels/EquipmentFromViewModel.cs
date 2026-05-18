using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.Web.Models.ViewModels
{
    public class EquipmentFormViewModel
    {
        public EquipmentFormViewModel()
        {
            Name = string.Empty;
            Description = null;
            AvailabilityStatus = "Available";
            ConditionStatus = "Good";
            ExistingImageUrl = null;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Rental price is required")]
        [Range(0.01, 10000, ErrorMessage = "Rental price must be between 0.01 and 10000")]
        [Display(Name = "Rental Price")]
        [DataType(DataType.Currency)]
        public decimal RentalPrice { get; set; }

        [Required(ErrorMessage = "Availability status is required")]
        [Display(Name = "Availability Status")]
        public string AvailabilityStatus { get; set; }

        [Required(ErrorMessage = "Condition status is required")]
        [Display(Name = "Condition Status")]
        public string ConditionStatus { get; set; }

        [Display(Name = "Deposit Amount")]
        [DataType(DataType.Currency)]
        [Range(0, 10000, ErrorMessage = "Deposit amount must be between 0 and 10000")]
        public decimal? DepositAmount { get; set; }

        [Display(Name = "Image")]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "Current Image")]
        public string? ExistingImageUrl { get; set; }

        [Display(Name = "Remove Current Image")]
        public bool DeleteExistingImage { get; set; }
    }
}