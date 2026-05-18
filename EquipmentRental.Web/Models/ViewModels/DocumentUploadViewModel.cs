using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.Web.Models.ViewModels
{
    public class DocumentUploadViewModel
    {
        public DocumentUploadViewModel()
        {
            TransactionReference = string.Empty;
            Description = null;
        }

        [Required]
        public int RentalTransactionId { get; set; }

        public string TransactionReference { get; set; }

        [Required(ErrorMessage = "Please select a file to upload")]
        [Display(Name = "File")]
        public IFormFile? File { get; set; }

        [Display(Name = "Description")]
        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters")]
        public string? Description { get; set; }
    }
}