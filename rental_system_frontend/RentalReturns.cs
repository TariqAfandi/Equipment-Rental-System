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
    public partial class RentalReturns : Form
    {
        RentalDBContext context;
        public RentalReturns()
        {
            InitializeComponent();
            context = new RentalDBContext();
        }

        private void RentalReturns_Load(object sender, EventArgs e)
        {
            LoadConditionDropdown();
            LoadReturnRecords();
        }

        private void LoadConditionDropdown()
        {
            ddlCondition.Items.Clear();
            ddlCondition.Items.Add(""); // All
            ddlCondition.Items.Add("Good");
            ddlCondition.Items.Add("Damaged");
            ddlCondition.Items.Add("Lost");
            ddlCondition.SelectedIndex = 0;
        }

        private void LoadReturnRecords(string search = "", string condition = "")
        {
            var query = context.ReturnRecords
                .Include(r => r.RentalTransaction)
                    .ThenInclude(t => t.User)
                .Include(r => r.RentalTransaction)
                    .ThenInclude(t => t.Equipment)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(r =>
                    r.RentalTransaction.User.Name.Contains(search) ||
                    r.RentalTransaction.Equipment.Name.Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(condition))
            {
                query = query.Where(r => r.ReturnCondition == condition);
            }

            var results = query.Select(r => new
            {
                r.Id,
                Customer = r.RentalTransaction.User.Name,
                Equipment = r.RentalTransaction.Equipment.Name,
                r.ReturnDate,
                r.ReturnCondition,
                r.LateFee,
                r.DamageFee,
                r.RefundAmount,
                ProcessedBy = r.ProcessedByUserId,
                r.Notes
            }).ToList();

            dgvRecord.DataSource = results;
            if (dgvRecord.Columns.Contains("Id"))
                dgvRecord.Columns["Id"].Visible = false;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string search = txtSearchCustomerEquipment.Text.Trim();
            string condition = ddlCondition.SelectedItem?.ToString();
            LoadReturnRecords(search, condition);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchCustomerEquipment.Clear();
            ddlCondition.SelectedIndex = 0;
            LoadReturnRecords();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Making a new form and navigating the users to that form
            AddReturn frmAddReturn = new AddReturn();
            frmAddReturn.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateReturn frmUpdateReturn = new UpdateReturn();
            frmUpdateReturn.ShowDialog();
        }
    }
}
