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
    public partial class UpdateEquipment : Form
    {
        RentalDBContext context;

        private int equipmentId;
        private Equipment selectedEquipment;
        public UpdateEquipment(int equipmentId)
        {
            InitializeComponent();
            context = new RentalDBContext();
            this.equipmentId = equipmentId;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //close the opertaino and form
            this.Close();
        }

        private void UpdateEquipment_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDropdowns();

                selectedEquipment = context.Equipment.FirstOrDefault(e => e.Id == equipmentId);

                if (selectedEquipment == null)
                {
                    MessageBox.Show("Equipment not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtBoxEquipmentID.Text = selectedEquipment.Id.ToString();
                txtBoxName.Text = selectedEquipment.Name;
                txtDescription.Text = selectedEquipment.Description;
                txtBoxPrice.Text = selectedEquipment.RentalPrice.ToString();
                ddlCategory.SelectedValue = selectedEquipment.CategoryId;
                ddlStatus.SelectedItem = selectedEquipment.AvailabilityStatus;
                ddlCondition.SelectedItem = selectedEquipment.ConditionStatus;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadDropdowns()
        {
            // Categories
            var categories = context.Categories
                .Select(c => new { c.Id, c.Name })
                .ToList();

            ddlCategory.DataSource = categories;
            ddlCategory.DisplayMember = "Name";
            ddlCategory.ValueMember = "Id";

            // Statuses
            ddlStatus.DataSource = new List<string> { "Available", "Unavailable", "Maintenance" };

            // Conditions (example values — change if needed)
            ddlCondition.DataSource = new List<string> { "Excellent", "Good", "Fair", "Used" };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedEquipment == null)
                {
                    MessageBox.Show("Equipment not found.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtBoxName.Text) ||
                    string.IsNullOrWhiteSpace(txtBoxPrice.Text) ||
                    ddlCategory.SelectedValue == null ||
                    ddlStatus.SelectedItem == null ||
                    ddlCondition.SelectedItem == null)
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }

                if (!decimal.TryParse(txtBoxPrice.Text.Trim(), out decimal price) || price < 0)
                {
                    MessageBox.Show("Please enter a valid non-negative price.");
                    return;
                }

                selectedEquipment.Name = txtBoxName.Text.Trim();
                selectedEquipment.Description = txtDescription.Text.Trim();
                selectedEquipment.RentalPrice = price;
                selectedEquipment.CategoryId = (int)ddlCategory.SelectedValue;
                selectedEquipment.AvailabilityStatus = ddlStatus.SelectedItem.ToString();
                selectedEquipment.ConditionStatus = ddlCondition.SelectedItem.ToString();

                context.SaveChanges();

                MessageBox.Show("Equipment updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
