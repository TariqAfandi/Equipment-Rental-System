using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRental.Web.Data
{
    public class RentalDBContext : IdentityDbContext
    {
        public RentalDBContext(DbContextOptions<RentalDBContext> options)
            : base(options)
        {
        }
    }
}
    