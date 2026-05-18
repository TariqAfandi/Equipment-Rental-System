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
    public partial class AuditLogs : Form
    {
        RentalDBContext context;
        public AuditLogs()
        {
            InitializeComponent();
            context = new RentalDBContext();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AuditLogs_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            LoadLogs();
        }

        private void LoadDropdowns()
        {
            // Distinct Action Types
            var actionTypes = context.Logs
                .Select(l => l.Action)
                .Distinct()
                .OrderBy(a => a)
                .ToList();

            actionTypes.Insert(0, ""); // Empty = All
            ddlActionType.DataSource = actionTypes;

            // Distinct Sources
            var sources = context.Logs
                .Select(l => l.Source)
                .Distinct()
                .OrderBy(s => s)
                .ToList();

            sources.Insert(0, "");
            ddlSource.DataSource = sources;
        }

        private void LoadLogs(string actionFilter = "", string sourceFilter = "", string search = "")
        {
            try
            {
                var logsQuery = context.Logs
                    .Include(l => l.User)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(actionFilter))
                    logsQuery = logsQuery.Where(l => l.Action == actionFilter);

                if (!string.IsNullOrWhiteSpace(sourceFilter))
                    logsQuery = logsQuery.Where(l => l.Source == sourceFilter);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    logsQuery = logsQuery.Where(l =>
                        l.User != null &&
                        (l.User.Name.Contains(search) || l.User.Email.Contains(search))
                    );
                }

                var logs = logsQuery
                    .OrderByDescending(l => l.Timestamp)
                    .Select(l => new
                    {
                        l.Id,
                        Username = l.User != null ? l.User.Name : "System",
                        Email = l.User != null ? l.User.Email : "-",
                        l.Action,
                        l.Details,
                        l.Source,
                        l.IpAddress,
                        Timestamp = l.Timestamp.ToString("g")
                    })
                    .ToList();

                dgvLogs.DataSource = logs;

                // Hide ID column
                if (dgvLogs.Columns.Contains("Id"))
                    dgvLogs.Columns["Id"].Visible = false;

                // Adjust column sizing
                dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLogs.Columns["Username"].HeaderText = "User";
                dgvLogs.Columns["IpAddress"].HeaderText = "IP Address";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load logs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string selectedAction = ddlActionType.SelectedItem?.ToString() ?? "";
            string selectedSource = ddlSource.SelectedItem?.ToString() ?? "";
            string searchText = txtSearch.Text.Trim();

            LoadLogs(selectedAction, selectedSource, searchText);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ddlActionType.SelectedIndex = 0;
            ddlSource.SelectedIndex = 0;
            txtSearch.Clear();
            LoadLogs();
        }
    }
}
