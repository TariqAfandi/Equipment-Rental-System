//using EquipmentRental.Data.Data;
//using EquipmentRental.Data.Entities;
using System;
using System.Threading.Tasks;
using rental_System_db.Data;
using rental_System_db.Entities;

namespace EquipmentRental.Data.Helpers
{
    public static class NotificationHelper
    {
        public static async Task CreateNotification(
            RentalDBContext context,
            int userId,
            string title,
            string message,
            string type)
        {
            var notification = new Notification
            {
                UserId = userId,
                Title = title,
                Message = message,
                Type = type,
                CreatedAt = DateTime.Now,
                IsRead = false
            };

            context.Notifications.Add(notification);
            await context.SaveChangesAsync();
        }

        public static async Task CreateRentalRequestNotification(
            RentalDBContext context,
            RentalRequest request,
            string action)
        {
            string title = string.Empty;
            string message = string.Empty;
            string type = string.Empty;

            switch (action)
            {
                case "Created":
                    title = "New Rental Request";
                    message = $"Your rental request for {request.Equipment.Name} has been submitted successfully. Request ID: {request.Id}";
                    type = "RentalRequest";
                    break;
                case "Approved":
                    title = "Rental Request Approved";
                    message = $"Your rental request for {request.Equipment.Name} has been approved. Please proceed to complete the rental process.";
                    type = "RentalApproval";
                    break;
                case "Rejected":
                    title = "Rental Request Rejected";
                    message = $"Your rental request for {request.Equipment.Name} has been rejected. Reason: {request.Notes}";
                    type = "RentalRejection";
                    break;
                case "Updated":
                    title = "Rental Request Updated";
                    message = $"Your rental request for {request.Equipment.Name} has been updated. Current status: {request.Status}";
                    type = "RentalUpdate";
                    break;
            }

            await CreateNotification(context, request.UserId, title, message, type);
        }

        public static async Task CreateRentalTransactionNotification(
            RentalDBContext context,
            RentalTransaction transaction,
            string action)
        {
            string title = string.Empty;
            string message = string.Empty;
            string type = string.Empty;

            switch (action)
            {
                case "Created":
                    title = "Rental Transaction Completed";
                    message = $"Your rental for {transaction.Equipment.Name} has been completed. The item is due for return on {transaction.ExpectedReturnDate.ToShortDateString()}.";
                    type = "RentalTransaction";
                    break;
                case "ReturnReminder":
                    title = "Return Reminder";
                    message = $"Your rental for {transaction.Equipment.Name} is due for return tomorrow. Please ensure timely return to avoid late fees.";
                    type = "ReturnReminder";
                    break;
                case "Overdue":
                    title = "Rental Overdue";
                    message = $"Your rental for {transaction.Equipment.Name} is now overdue. Please return the item as soon as possible to avoid additional fees.";
                    type = "RentalOverdue";
                    break;
            }

            await CreateNotification(context, transaction.UserId, title, message, type);
        }
    }
}