using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentRental.Web.Models.ViewModels
{
    public class ProcessReturnViewModel
    {
        public ProcessReturnViewModel()
        {
            // Initialize all non-nullable string properties
            EquipmentName = string.Empty;
            CustomerName = string.Empty;
            Notes = string.Empty;
            ReturnCondition = "Good";
            EquipmentImageUrl = string.Empty;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Rental transaction is required")]
        [Display(Name = "Rental Transaction")]
        public int RentalTransactionId { get; set; }

        [Required(ErrorMessage = "Return date is required")]
        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReturnDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Return condition is required")]
        [Display(Name = "Return Condition")]
        public string ReturnCondition { get; set; }

        [Display(Name = "Late Fee")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal? LateFee { get; set; } = 0;

        [Display(Name = "Damage Fee")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal? DamageFee { get; set; } = 0;

        [Display(Name = "Refund Amount")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal? RefundAmount { get; set; } = 0;

        [Required(ErrorMessage = "Processed by user is required")]
        [Display(Name = "Processed By")]
        public int ProcessedByUserId { get; set; }

        [Display(Name = "Notes")]
        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string Notes { get; set; }

        // Additional display properties
        public string EquipmentName { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public decimal? DepositAmount { get; set; }
        public string EquipmentImageUrl { get; set; }
    }
}