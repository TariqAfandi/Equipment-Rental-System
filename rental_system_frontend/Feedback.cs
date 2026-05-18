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
    public partial class Feedback : Form
    {
        RentalDBContext context;
        public Feedback()
        {
            InitializeComponent();
            context = new RentalDBContext();
        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            LoadFeedbackData();
        }

        private void LoadDropdowns()
        {
            try
            {
                var equipmentNames = context.Equipment
                    .Select(e => new { e.Id, e.Name })
                    .Distinct()
                    .ToList();

                equipmentNames.Insert(0, new { Id = 0, Name = "" }); // "All" option

                ddlName.DataSource = equipmentNames;
                ddlName.DisplayMember = "Name";
                ddlName.ValueMember = "Id";

                var ratings = new List<object>
                {
                    new { Value = 0, Text = "" },
                    new { Value = 1, Text = "★" },
                    new { Value = 2, Text = "★★" },
                    new { Value = 3, Text = "★★★" },
                    new { Value = 4, Text = "★★★★" },
                    new { Value = 5, Text = "★★★★★" }
                };

                ddlRatings.DataSource = ratings;
                ddlRatings.DisplayMember = "Text";
                ddlRatings.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dropdowns: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFeedbackData(int? equipmentId = null, int? rating = null)
        {
            try
            {
                var query = context.Feedbacks.AsQueryable();

                if (equipmentId.HasValue && equipmentId != 0)
                    query = query.Where(f => f.EquipmentId == equipmentId.Value);

                if (rating.HasValue && rating != 0)
                    query = query.Where(f => f.Rating == rating.Value);

                var feedbackList = query
                    .Select(f => new
                    {
                        f.Id,
                        EquipmentName = f.Equipment.Name,
                        f.Comment,
                        f.Rating,
                        Visible = f.IsVisible ? "Visible" : "Hidden"
                    })
                    .ToList();

                dgvFeedback.DataSource = feedbackList;

                // Hide Id column
                if (dgvFeedback.Columns["Id"] != null)
                    dgvFeedback.Columns["Id"].Visible = false;

                // Auto-size columns
                dgvFeedback.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading feedback: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedEquipmentId = (int)ddlName.SelectedValue;
                int selectedRating = (int)ddlRatings.SelectedValue;

                int? equipmentId = selectedEquipmentId == 0 ? null : selectedEquipmentId;
                int? rating = selectedRating == 0 ? null : selectedRating;

                LoadFeedbackData(equipmentId, rating);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering feedback: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ddlName.SelectedIndex = 0;
                ddlRatings.SelectedIndex = 0;
                LoadFeedbackData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVisible_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFeedback.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a feedback row to toggle visibility.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedId = Convert.ToInt32(dgvFeedback.SelectedRows[0].Cells["Id"].Value);
                var feedback = context.Feedbacks.FirstOrDefault(f => f.Id == selectedId);

                if (feedback != null)
                {
                    feedback.IsVisible = !feedback.IsVisible;
                    context.SaveChanges();

                    MessageBox.Show($"Feedback is now {(feedback.IsVisible ? "Visible" : "Hidden")}.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFeedbackData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error toggling visibility: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
