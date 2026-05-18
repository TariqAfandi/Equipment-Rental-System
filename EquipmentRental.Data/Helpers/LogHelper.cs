using EquipmentRental.Data.Data;
using EquipmentRental.Data.Entities;
using System;
using System.Threading.Tasks;

namespace EquipmentRental.Data.Helpers
{
    public static class LogHelper
    {
        public static async Task CreateLog(
            ApplicationDbContext context,
            int? userId,
            string action,
            string details,
            string? ipAddress,
            string source = "Web")
        {
            var log = new Log
            {
                UserId = userId,
                Action = action ?? "Unknown",
                Details = details ?? "No details provided",
                Timestamp = DateTime.Now,
                IpAddress = ipAddress ?? "Unknown",
                Source = source ?? "Web"
            };

            context.Logs.Add(log);
            await context.SaveChangesAsync();
        }

        public static async Task LogUserAction(
            ApplicationDbContext context,
            int userId,
            string action,
            string details,
            string? ipAddress,
            string source = "Web")
        {
            await CreateLog(context, userId, action, details, ipAddress ?? "Unknown", source);
        }

        public static async Task LogSystemAction(
            ApplicationDbContext context,
            string action,
            string details,
            string? ipAddress,
            string source = "Web")
        {
            await CreateLog(context, null, action, details, ipAddress ?? "Unknown", source);
        }

        public static async Task LogError(
            ApplicationDbContext context,
            Exception ex,
            int? userId,
            string? ipAddress,
            string source = "Web")
        {
            string details = $"Error: {ex.Message}";
            if (ex.StackTrace != null)
            {
                details += $", StackTrace: {ex.StackTrace}";
            }
            if (ex.InnerException != null)
            {
                details += $", Inner Exception: {ex.InnerException.Message}";
            }

            await CreateLog(context, userId, "Error", details, ipAddress ?? "Unknown", source);
        }
    }
}