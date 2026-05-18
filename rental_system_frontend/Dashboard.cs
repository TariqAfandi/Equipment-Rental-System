using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rental_System_db.Data;

namespace rental_system_frontend
{
    public partial class Dashboard : Form
    {
        RentalDBContext context = new RentalDBContext();
        public Dashboard()
        {
            InitializeComponent();
            context = new RentalDBContext();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Total Equipment Count
            lblTotalEquipment.Text = context.Equipment.Count().ToString();

            // Total Categories
            lblTotalCategories.Text = context.Categories.Count().ToString();

            // Total Pending Requests
            lblTotalPending.Text = context.RentalRequests
                .Where(r => r.Status == "Pending")
                .Count()
                .ToString();

            // Total Active Rentals
            lblTotalActiveRentals.Text = context.RentalTransactions
                .Where(r => r.Status == "Active")
                .Count()
                .ToString();

            // Total Rental Requests
            lblTotalRequests.Text = context.RentalRequests.Count().ToString();
        }
    }
}
