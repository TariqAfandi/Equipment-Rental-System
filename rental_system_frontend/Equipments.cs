using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rental_System_db;
using rental_System_db.Data;

namespace rental_system_frontend
{
    public partial class Equipments : Form
    {
        RentalDBContext context;
        public Equipments()
        {
            InitializeComponent();
            context = new RentalDBContext();
        }

        private void lblCategory_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                AddEquipment frmAddEquipment = new AddEquipment();
                frmAddEquipment.ShowDialog();

                if (frmAddEquipment.DialogResult == DialogResult.OK)
                {
                    LoadEquipmentData(); // Refresh only if new data was added
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding equipment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEquipments.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an equipment to update.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedId = (int)dgvEquipments.SelectedRows[0].Cells["Id"].Value;
                UpdateEquipment frmUpdate = new UpdateEquipment(selectedId);
                frmUpdate.ShowDialog();

                if (frmUpdate.DialogResult == DialogResult.OK)
                {
                    LoadEquipmentData(); // Refresh after update
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating equipment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageCategory_Click(object sender, EventArgs e)
        {
            try
            {
                Category frmCategory = new Category();
                frmCategory.ShowDialog();
                // Refresh categories dropdown if needed
                LoadCategoryDropdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error managing categories: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEquipments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                string nameFilter = txtName.Text.Trim();
                int selectedCategoryId = (int)ddlCategory.SelectedValue;
                int? categoryFilter = selectedCategoryId == 0 ? null : (int?)selectedCategoryId;
                string statusFilter = ddlStatus.SelectedValue?.ToString();

                LoadEquipmentData(nameFilter, categoryFilter, statusFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying filters: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                txtName.Clear();
                ddlCategory.SelectedIndex = 0;
                ddlStatus.SelectedIndex = 0;
                LoadEquipmentData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEquipments.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show("Are you sure you want to delete this equipment?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    int selectedId = (int)dgvEquipments.SelectedRows[0].Cells["Id"].Value;
                    var equipmentToDelete = context.Equipment.FirstOrDefault(e => e.Id == selectedId);

                    if (equipmentToDelete != null)
                    {
                        context.Equipment.Remove(equipmentToDelete);
                        context.SaveChanges();
                        MessageBox.Show("Equipment deleted successfully.", "Deleted",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEquipmentData(); // Refresh grid
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting equipment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Equipments_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCategoryDropdown();
                LoadStatusDropdown();
                ConfigureDataGridView();
                LoadEquipmentData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadCategoryDropdown()
        {
            var categories = context.Categories
                .Select(c => new { c.Id, c.Name })
                .ToList();
            categories.Insert(0, new { Id = 0, Name = "All Categories" });

            ddlCategory.DataSource = categories;
            ddlCategory.DisplayMember = "Name";
            ddlCategory.ValueMember = "Id";
        }

        private void LoadStatusDropdown()
        {
            var statuses = new[]
            {
                new { Id = "", Name = "All Statuses" },
                new { Id = "Available", Name = "Available" },
                new { Id = "Unavailable", Name = "Unavailable" },
                new { Id = "Maintenance", Name = "Maintenance" }
            };

            ddlStatus.DataSource = statuses;
            ddlStatus.DisplayMember = "Name";
            ddlStatus.ValueMember = "Id";
        }

        private void ConfigureDataGridView()
        {
            dgvEquipments.AutoGenerateColumns = false;
            dgvEquipments.Columns.Clear();

            // Configure columns with proper headers and data properties
            dgvEquipments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Equipment Name",
                Width = 150
            });

            dgvEquipments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Category",
                Width = 120
            });

            dgvEquipments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RentalPrice",
                HeaderText = "Daily Price",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvEquipments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AvailabilityStatus",
                HeaderText = "Status",
                Width = 100
            });

            dgvEquipments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ConditionStatus",
                HeaderText = "Condition",
                Width = 100
            });

            dgvEquipments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Description",
                HeaderText = "Description",
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Hidden column for ID (used for operations but not displayed)
            dgvEquipments.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "Id",
                Visible = false
            });
        }

        private void LoadEquipmentData(string name = "", int? categoryId = null, string status = "")
        {
            try
            {
                var query = context.Equipment.AsQueryable();

                if (!string.IsNullOrWhiteSpace(name))
                    query = query.Where(e => e.Name.Contains(name));

                if (categoryId.HasValue && categoryId > 0)
                    query = query.Where(e => e.CategoryId == categoryId);

                if (!string.IsNullOrWhiteSpace(status))
                    query = query.Where(e => e.AvailabilityStatus == status);

                var equipmentList = query
                    .Select(e => new
                    {
                        e.Id,
                        e.Name,
                        Category = e.Category.Name,
                        e.RentalPrice,
                        e.AvailabilityStatus,
                        e.ConditionStatus,
                        e.Description
                    })
                    .ToList();

                dgvEquipments.DataSource = equipmentList;

                // Format the grid after data binding
                dgvEquipments.AutoResizeColumns();
                dgvEquipments.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading equipment data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
