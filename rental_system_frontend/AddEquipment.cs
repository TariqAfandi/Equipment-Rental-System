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
using rental_System_db.Entities;

namespace rental_system_frontend
{
    public partial class AddEquipment : Form
    {
        public AddEquipment()
        {
            InitializeComponent();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEquipment_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new RentalDBContext())
                {
                    // Load categories
                    var categories = context.Categories
                        .Select(c => new { c.Id, c.Name })
                        .ToList();

                    ddlCategory.DataSource = categories;
                    ddlCategory.DisplayMember = "Name";
                    ddlCategory.ValueMember = "Id";
                }

                // Static status list
                ddlStatus.DataSource = new List<object>
                {
                    new { Id = "Available", Name = "Available" },
                    new { Id = "Unavailable", Name = "Unavailable" },
                    new { Id = "Maintenance", Name = "Maintenance" }
                };
                ddlStatus.DisplayMember = "Name";
                ddlStatus.ValueMember = "Id";

                // Static condition list
                ddlCondition.DataSource = new List<object>
                {
                    new { Id = "Excellent", Name = "Excellent" },
                    new { Id = "Good", Name = "Good" },
                    new { Id = "Fair", Name = "Fair" },
                    new { Id = "Used", Name = "Used" }
                };
                ddlCondition.DisplayMember = "Name";
                ddlCondition.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Input validation
                if (string.IsNullOrWhiteSpace(txtBoxName.Text) ||
                    string.IsNullOrWhiteSpace(txtBoxPrice.Text) ||
                    ddlCategory.SelectedValue == null ||
                    ddlStatus.SelectedValue == null ||
                    ddlCondition.SelectedValue == null)
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }

                if (!decimal.TryParse(txtBoxPrice.Text.Trim(), out decimal price) || price < 0)
                {
                    MessageBox.Show("Please enter a valid non-negative price.");
                    return;
                }

                var newEquipment = new Equipment
                {
                    Name = txtBoxName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    CategoryId = (int)ddlCategory.SelectedValue,
                    AvailabilityStatus = ddlStatus.SelectedValue.ToString(),
                    ConditionStatus = ddlCondition.SelectedValue.ToString(),
                    RentalPrice = price
                };

                using (var context = new RentalDBContext())
                {
                    context.Equipment.Add(newEquipment);
                    context.SaveChanges();
                }

                MessageBox.Show("Equipment added successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving: " + ex.Message);
            }
        }
    }
}
