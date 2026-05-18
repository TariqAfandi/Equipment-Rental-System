using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EquipmentRental.Data.Helpers;
using rental_System_db.Data;

namespace rental_system_frontend
{
    public partial class Login : Form
    {
        RentalDBContext context;
        public static string CurrentUserRole { get; private set; } // Track user role
        public Login()
        {
            InitializeComponent();
            context = new RentalDBContext();
        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            string email = txtBoxEmail.Text.Trim();
            string password = txtBoxPassword.Text;

            // Validate input
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password", "Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hash the entered password
            string hashedPassword = PasswordHelper.HashPassword(password);

            // Check credentials
            var user = context.Users.FirstOrDefault(u =>
                       u.Email == email &&
                       u.Password == PasswordHelper.HashPassword(password) &&
                       (u.Role == "Administrator" || u.Role == "Manager"));

            if (user != null)
            {
                CurrentUserRole = user.Role;

                // Log the successful login
                await LogHelper.LogUserAction(
                    context,
                    user.Id,
                    "Login Success",
                    $"User '{user.Email}' logged in successfully.",
                    GetLocalIPAddress(),
                    "Desktop"
                );

                Home frmHome = new Home();
                frmHome.Show();
                this.Hide();
            }
            else
            {
                await LogHelper.LogSystemAction(
                    context,
                    "Login Failed",
                    $"Failed login attempt for email '{email}'.",
                    GetLocalIPAddress(),
                    "Desktop"
        );

                MessageBox.Show("Invalid credentials or unauthorized role", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private string GetLocalIPAddress()
        {
            try
            {
                var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
            }
            catch
            {
                // Could log error or ignore
            }
            return "127.0.0.1"; // default fallback
        }

        private void txtBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
