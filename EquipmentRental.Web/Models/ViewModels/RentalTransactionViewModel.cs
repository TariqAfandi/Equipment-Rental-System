using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.Web.Models.ViewModels
{
    public class RentalTransactionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Rental request is required")]
        [Display(Name = "Rental Request ID")]
        public int RentalRequestId { get; set; }

        [Required(ErrorMessage = "User is required")]
        [Display(Name = "User")]
        public int UserId { get; set; }

        // User details for display
        public string UserName { get; set; }

        [Required(ErrorMessage = "Equipment is required")]
        [Display(Name = "Equipment")]
        public int EquipmentId { get; set; }

        // Equipment details for display
        public string EquipmentName { get; set; }
        public string CategoryName { get; set; }

        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Actual start date is required")]
        [Display(Name = "Actual Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActualStartDate { get; set; }

        [Required(ErrorMessage = "Expected return date is required")]
        [Display(Name = "Expected Return Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpectedReturnDate { get; set; }

        [Required(ErrorMessage = "Rental fee is required")]
        [Range(0.01, 10000, ErrorMessage = "Rental fee must be between 0.01 and 10000")]
        [Display(Name = "Rental Fee")]
        [DataType(DataType.Currency)]
        public decimal RentalFee { get; set; }

        [Display(Name = "Deposit Amount")]
        [DataType(DataType.Currency)]
        public decimal? DepositAmount { get; set; }

        [Required(ErrorMessage = "Payment status is required")]
        [Display(Name = "Payment Status")]
        public string PaymentStatus { get; set; } = "Pending";

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public string Status { get; set; } = "Active";

        [Display(Name = "Notes")]
        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string Notes { get; set; }
    }
}