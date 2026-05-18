using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using rental_System_db.Data;

namespace rental_system_frontend
{
    public partial class RentalRequests : Form
    {
        RentalDBContext context;
        public RentalRequests()
        {
            InitializeComponent();
            context = new RentalDBContext();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateRentalRequest frmUpdateRentalRequest = new UpdateRentalRequest();
            frmUpdateRentalRequest.ShowDialog();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            HandleRequestStatusChange("Approved");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            HandleRequestStatusChange("Rejected");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //when a row is selected and delete button is clicked, delete the damn record
        }

        private void RentalRequests_Load(object sender, EventArgs e)
        {
            LoadStatusDropdown();
            LoadRequests();
        }

        private void LoadStatusDropdown()
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(""); // All
            ddlStatus.Items.Add("Pending");
            ddlStatus.Items.Add("Approved");
            ddlStatus.Items.Add("Rejected");
            ddlStatus.Items.Add("Completed");
            ddlStatus.SelectedIndex = 0;
        }

        private void LoadRequests(string search = "", string status = "")
        {
            var query = context.RentalRequests
                .Include(r => r.User)
                .Include(r => r.Equipment)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(r =>
                    r.User.Name.Contains(search) ||
                    r.Equipment.Name.Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                query = query.Where(r => r.Status == status);
            }

            var results = query.Select(r => new
            {
                r.Id,
                Customer = r.User.Name,
                Equipment = r.Equipment.Name,
                r.RequestDate,
                r.RentalStartDate,
                r.RentalEndDate,
                r.Status,
                r.TotalCost,
                ProcessedBy = r.ProcessedByUserId,
                r.ProcessedDate
            }).ToList();

            dgvRequests.DataSource = results;

            if (dgvRequests.Columns.Contains("Id"))
                dgvRequests.Columns["Id"].Visible = false;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string search = txtSearchCustomerEquipment.Text.Trim();
            string status = ddlStatus.SelectedItem?.ToString();
            LoadRequests(search, status);
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            txtSearchCustomerEquipment.Clear();
            ddlStatus.SelectedIndex = 0;
            LoadRequests();
        }

        private void HandleRequestStatusChange(string newStatus)
        {
            try
            {
                if (dgvRequests.CurrentRow == null)
                {
                    MessageBox.Show("Please select a request.");
                    return;
                }

                int requestId = (int)dgvRequests.CurrentRow.Cells["Id"].Value;
                var request = context.RentalRequests.Find(requestId);

                if (request == null || request.Status != "Pending")
                {
                    MessageBox.Show("Only pending requests can be processed.");
                    return;
                }

                request.Status = newStatus;
                request.ProcessedByUserId = 4; // Replace with actual logged-in user ID
                request.ProcessedDate = DateTime.Now;

                context.SaveChanges();
                MessageBox.Show($"Request marked as {newStatus}.");
                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating request: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
