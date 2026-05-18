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
    public partial class RentalTransaction : Form
    {
        RentalDBContext context;
        public RentalTransaction()
        {
            InitializeComponent();
            context = new RentalDBContext();
        }

        private void RentalTransactions_Load(object sender, EventArgs e)
        {
            LoadTransactions();
            LoadStatusDropdown();
        }

        private void LoadTransactions(string search = "", string status = "")
        {
            try
            {
                var query = context.RentalTransactions
                    .Include(rt => rt.User)
                    .Include(rt => rt.Equipment)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(rt =>
                        rt.User.Name.Contains(search) ||
                        rt.Equipment.Name.Contains(search));
                }

                if (!string.IsNullOrWhiteSpace(status))
                {
                    query = query.Where(rt => rt.Status == status);
                }

                var result = query.Select(rt => new
                {
                    rt.Id,
                    Customer = rt.User.Name,
                    Equipment = rt.Equipment.Name,
                    rt.TransactionDate,
                    rt.ActualStartDate,
                    rt.ExpectedReturnDate,
                    rt.RentalFee,
                    rt.DepositAmount,
                    rt.PaymentStatus,
                    rt.Status
                }).ToList();

                dgvTransaction.DataSource = result;

                if (dgvTransaction.Columns.Contains("Id"))
                    dgvTransaction.Columns["Id"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load transactions: " + ex.Message);
            }
        }

        private void LoadStatusDropdown()
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(""); // for 'All'
            ddlStatus.Items.Add("Active");
            ddlStatus.Items.Add("Returned");
            ddlStatus.Items.Add("Pending");
            ddlStatus.SelectedIndex = 0;
        }




        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRentalTransaction frmAddRentalTransaction = new AddRentalTransaction();
            frmAddRentalTransaction.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateRentalTransaction frmUpdateRentalTransaction = new UpdateRentalTransaction();
            frmUpdateRentalTransaction.ShowDialog();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string search = txtSearchCustomerEquipment.Text.Trim();
            string status = ddlStatus.SelectedItem?.ToString();
            LoadTransactions(search, status);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchCustomerEquipment.Clear();
            ddlStatus.SelectedIndex = 0;
            LoadTransactions();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvTransaction.CurrentRow == null)
            {
                MessageBox.Show("Please select a transaction.");
                return;
            }

            int transactionId = Convert.ToInt32(dgvTransaction.CurrentRow.Cells["Id"].Value);
            var transaction = context.RentalTransactions.Find(transactionId);

            if (transaction == null)
            {
                MessageBox.Show("Transaction not found.");
                return;
            }

            if (transaction.Status == "Returned")
            {
                MessageBox.Show("This equipment has already been returned.");
                return;
            }

            if (transaction.Status == "Pending")
            {
                MessageBox.Show("This transaction is pending. It cannot be returned yet.");
                return;
            }

            transaction.Status = "Returned";
            context.SaveChanges();
            MessageBox.Show("Equipment marked as returned.");
            LoadTransactions();
        }
    }
}
