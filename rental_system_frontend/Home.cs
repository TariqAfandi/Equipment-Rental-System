using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rental_system_frontend
{
    public partial class Home : Form
    {
        private Button currentButton;
        private Form activeForm;
        public Home()
        {
            InitializeComponent();
            //activeForm = this;

            // Hide audit logs button if user is Manager
            if (Login.CurrentUserRole == "Manager")
            {
                btnAuditLogs.Visible = false;

                // Alternatively, you could disable it instead of hiding:
                 btnAuditLogs.Enabled = false;
            }
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private Color SelectedColor()
        {
            String color = "#0739AE";
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object sender)
        {
            if (sender != null)
            {
                if (currentButton != (Button)sender)
                {
                    DisableButton();
                    Color color = SelectedColor();
                    currentButton = (Button)sender;
                    currentButton.BackColor = color;
                    currentButton.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DisableButton()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button previousBtn)
                {
                    previousBtn.BackColor = Color.FromArgb(0, 9, 103);
                    previousBtn.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
                }
                else if (control is Panel panel)
                {
                    // Recursively check panels in case buttons are nested
                    foreach (Control nestedControl in panel.Controls)
                    {
                        if (nestedControl is Button nestedBtn)
                        {
                            nestedBtn.BackColor = Color.FromArgb(0, 9, 103);
                            nestedBtn.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            MainPanel.Controls.Clear(); // clear only panelMain, not entire form
            MainPanel.Controls.Add(childForm);
            MainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            MainLabel.Text = childForm.Text;
        }


        private void btnManageReturns_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RentalReturns(), sender);
        }

        private void btnFeedbacks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Feedback(), sender);
        }

        private void btnRentalTransactions_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RentalTransaction(), sender);
        }

        private void btnAuditLogs_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AuditLogs(), sender);
        }

        private void btnManageEqups_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Equipments(), sender);
        }

        private void btnRentalRequests_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RentalRequests(), sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login frmLogin = new Login();
            frmLogin.Show();
            this.Hide();
        }

        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Dashboard(), sender);
        }
    }
}
