namespace rental_system_frontend
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            lblWelcome = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            txtBoxEmail = new RichTextBox();
            txtBoxPassword = new RichTextBox();
            btnSignIn = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Cascadia Code", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(63, 37);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(243, 25);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Login to your account";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(63, 99);
            lblEmail.Margin = new Padding(2, 0, 2, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 21);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            lblEmail.Click += lblEmail_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(63, 168);
            lblPassword.Margin = new Padding(2, 0, 2, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(82, 21);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.BorderStyle = BorderStyle.None;
            txtBoxEmail.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxEmail.ForeColor = SystemColors.ActiveBorder;
            txtBoxEmail.Location = new Point(63, 122);
            txtBoxEmail.Margin = new Padding(2, 2, 2, 2);
            txtBoxEmail.Multiline = false;
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.Size = new Size(247, 27);
            txtBoxEmail.TabIndex = 4;
            txtBoxEmail.Text = "";
            txtBoxEmail.TextChanged += txtBoxEmail_TextChanged;
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.BorderStyle = BorderStyle.None;
            txtBoxPassword.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxPassword.ForeColor = SystemColors.ActiveBorder;
            txtBoxPassword.Location = new Point(63, 191);
            txtBoxPassword.Margin = new Padding(2, 2, 2, 2);
            txtBoxPassword.Multiline = false;
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.Size = new Size(247, 27);
            txtBoxPassword.TabIndex = 5;
            txtBoxPassword.Text = "";
            txtBoxPassword.TextChanged += txtBoxPassword_TextChanged;
            // 
            // btnSignIn
            // 
            btnSignIn.BackColor = Color.White;
            btnSignIn.Cursor = Cursors.Hand;
            btnSignIn.FlatStyle = FlatStyle.Popup;
            btnSignIn.Font = new Font("Cascadia Code", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSignIn.ForeColor = Color.FromArgb(0, 9, 103);
            btnSignIn.Location = new Point(63, 250);
            btnSignIn.Margin = new Padding(2, 2, 2, 2);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(247, 32);
            btnSignIn.TabIndex = 6;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = false;
            btnSignIn.Click += button1_ClickAsync;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 9, 103);
            panel1.Controls.Add(txtBoxPassword);
            panel1.Controls.Add(btnSignIn);
            panel1.Controls.Add(lblWelcome);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(txtBoxEmail);
            panel1.Controls.Add(lblPassword);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(366, 329);
            panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(366, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(330, 329);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(696, 329);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Login";
            Text = "Login";
            FormClosing += Login_FormClosing;
            Load += Login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblWelcome;
        private Label lblEmail;
        private Label lblPassword;
        private RichTextBox txtBoxEmail;
        private RichTextBox txtBoxPassword;
        private Button btnSignIn;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}