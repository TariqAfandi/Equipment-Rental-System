using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.Web.Models.ViewModels
{
    public class RentalRequestViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Equipment is required")]
        [Display(Name = "Equipment")]
        public int EquipmentId { get; set; }

        // Equipment details for display
        public string EquipmentName { get; set; }
        public string CategoryName { get; set; }
        public string EquipmentImageUrl { get; set; }
        public decimal RentalPrice { get; set; }
        public decimal? TotalCost { get; set; }

        [Display(Name = "Request Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "Rental start date is required")]
        [Display(Name = "Rental Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RentalStartDate { get; set; }

        [Required(ErrorMessage = "Rental end date is required")]
        [Display(Name = "Rental End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RentalEndDate { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Pending";

        [Display(Name = "Notes")]
        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string Notes { get; set; }
    }
}