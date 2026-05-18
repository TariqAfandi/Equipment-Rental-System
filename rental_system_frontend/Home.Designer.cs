
namespace rental_system_frontend
{
    partial class Home
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
            btnLogout = new FontAwesome.Sharp.IconButton();
            btnAuditLogs = new FontAwesome.Sharp.IconButton();
            btnRentalTransactions = new FontAwesome.Sharp.IconButton();
            btnFeedbacks = new FontAwesome.Sharp.IconButton();
            btnManageReturns = new FontAwesome.Sharp.IconButton();
            btnRentalRequests = new FontAwesome.Sharp.IconButton();
            btnManageEquips = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            btnDashboard = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            panelTitle = new Panel();
            MainLabel = new Label();
            MainPanel = new Panel();
            lblWelcome = new Label();
            lblWelcome2 = new Label();
            panel1.SuspendLayout();
            panelTitle.SuspendLayout();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(0, 9, 103);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatStyle = FlatStyle.Popup;
            btnLogout.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogout.ForeColor = Color.White;
            btnLogout.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            btnLogout.IconColor = Color.White;
            btnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLogout.IconSize = 40;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(7, 416);
            btnLogout.Margin = new Padding(2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(143, 54);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnAuditLogs
            // 
            btnAuditLogs.BackColor = Color.FromArgb(0, 9, 103);
            btnAuditLogs.Cursor = Cursors.Hand;
            btnAuditLogs.FlatStyle = FlatStyle.Popup;
            btnAuditLogs.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAuditLogs.ForeColor = Color.White;
            btnAuditLogs.IconChar = FontAwesome.Sharp.IconChar.History;
            btnAuditLogs.IconColor = Color.White;
            btnAuditLogs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAuditLogs.IconSize = 40;
            btnAuditLogs.ImageAlign = ContentAlignment.MiddleLeft;
            btnAuditLogs.Location = new Point(7, 358);
            btnAuditLogs.Margin = new Padding(2);
            btnAuditLogs.Name = "btnAuditLogs";
            btnAuditLogs.Size = new Size(143, 54);
            btnAuditLogs.TabIndex = 6;
            btnAuditLogs.Text = "Audit Logs";
            btnAuditLogs.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAuditLogs.UseVisualStyleBackColor = false;
            btnAuditLogs.Click += btnAuditLogs_Click;
            // 
            // btnRentalTransactions
            // 
            btnRentalTransactions.BackColor = Color.FromArgb(0, 9, 103);
            btnRentalTransactions.Cursor = Cursors.Hand;
            btnRentalTransactions.FlatStyle = FlatStyle.Popup;
            btnRentalTransactions.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRentalTransactions.ForeColor = Color.White;
            btnRentalTransactions.IconChar = FontAwesome.Sharp.IconChar.FileText;
            btnRentalTransactions.IconColor = Color.White;
            btnRentalTransactions.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRentalTransactions.IconSize = 40;
            btnRentalTransactions.ImageAlign = ContentAlignment.MiddleLeft;
            btnRentalTransactions.Location = new Point(7, 243);
            btnRentalTransactions.Margin = new Padding(2);
            btnRentalTransactions.Name = "btnRentalTransactions";
            btnRentalTransactions.Size = new Size(143, 54);
            btnRentalTransactions.TabIndex = 5;
            btnRentalTransactions.Text = "Rental Transactions";
            btnRentalTransactions.TextAlign = ContentAlignment.MiddleLeft;
            btnRentalTransactions.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRentalTransactions.UseVisualStyleBackColor = false;
            btnRentalTransactions.Click += btnRentalTransactions_Click;
            // 
            // btnFeedbacks
            // 
            btnFeedbacks.BackColor = Color.FromArgb(0, 9, 103);
            btnFeedbacks.Cursor = Cursors.Hand;
            btnFeedbacks.FlatStyle = FlatStyle.Popup;
            btnFeedbacks.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnFeedbacks.ForeColor = Color.White;
            btnFeedbacks.IconChar = FontAwesome.Sharp.IconChar.Comments;
            btnFeedbacks.IconColor = Color.White;
            btnFeedbacks.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFeedbacks.IconSize = 40;
            btnFeedbacks.ImageAlign = ContentAlignment.MiddleLeft;
            btnFeedbacks.Location = new Point(7, 301);
            btnFeedbacks.Margin = new Padding(2);
            btnFeedbacks.Name = "btnFeedbacks";
            btnFeedbacks.Size = new Size(143, 54);
            btnFeedbacks.TabIndex = 4;
            btnFeedbacks.Text = "Feedbacks";
            btnFeedbacks.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFeedbacks.UseVisualStyleBackColor = false;
            btnFeedbacks.Click += btnFeedbacks_Click;
            // 
            // btnManageReturns
            // 
            btnManageReturns.BackColor = Color.FromArgb(0, 9, 103);
            btnManageReturns.Cursor = Cursors.Hand;
            btnManageReturns.FlatStyle = FlatStyle.Popup;
            btnManageReturns.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnManageReturns.ForeColor = Color.White;
            btnManageReturns.IconChar = FontAwesome.Sharp.IconChar.Sync;
            btnManageReturns.IconColor = Color.White;
            btnManageReturns.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnManageReturns.IconSize = 40;
            btnManageReturns.ImageAlign = ContentAlignment.MiddleLeft;
            btnManageReturns.Location = new Point(7, 185);
            btnManageReturns.Margin = new Padding(2);
            btnManageReturns.Name = "btnManageReturns";
            btnManageReturns.Size = new Size(143, 54);
            btnManageReturns.TabIndex = 3;
            btnManageReturns.Text = "Manage Returns";
            btnManageReturns.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManageReturns.UseVisualStyleBackColor = false;
            btnManageReturns.Click += btnManageReturns_Click;
            // 
            // btnRentalRequests
            // 
            btnRentalRequests.BackColor = Color.FromArgb(0, 9, 103);
            btnRentalRequests.Cursor = Cursors.Hand;
            btnRentalRequests.FlatStyle = FlatStyle.Popup;
            btnRentalRequests.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRentalRequests.ForeColor = Color.White;
            btnRentalRequests.IconChar = FontAwesome.Sharp.IconChar.Commenting;
            btnRentalRequests.IconColor = Color.White;
            btnRentalRequests.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRentalRequests.IconSize = 40;
            btnRentalRequests.ImageAlign = ContentAlignment.MiddleLeft;
            btnRentalRequests.Location = new Point(7, 127);
            btnRentalRequests.Margin = new Padding(2);
            btnRentalRequests.Name = "btnRentalRequests";
            btnRentalRequests.Size = new Size(143, 54);
            btnRentalRequests.TabIndex = 2;
            btnRentalRequests.Text = "Rental Requests";
            btnRentalRequests.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRentalRequests.UseVisualStyleBackColor = false;
            btnRentalRequests.Click += btnRentalRequests_Click;
            // 
            // btnManageEquips
            // 
            btnManageEquips.BackColor = Color.FromArgb(0, 9, 103);
            btnManageEquips.Cursor = Cursors.Hand;
            btnManageEquips.FlatStyle = FlatStyle.Popup;
            btnManageEquips.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnManageEquips.ForeColor = Color.White;
            btnManageEquips.IconChar = FontAwesome.Sharp.IconChar.Toolbox;
            btnManageEquips.IconColor = Color.White;
            btnManageEquips.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnManageEquips.IconSize = 40;
            btnManageEquips.ImageAlign = ContentAlignment.MiddleLeft;
            btnManageEquips.Location = new Point(7, 70);
            btnManageEquips.Margin = new Padding(2);
            btnManageEquips.Name = "btnManageEquips";
            btnManageEquips.Size = new Size(143, 54);
            btnManageEquips.TabIndex = 1;
            btnManageEquips.Text = "Manage Equipments";
            btnManageEquips.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnManageEquips.UseVisualStyleBackColor = false;
            btnManageEquips.Click += btnManageEqups_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(7, 8, 20);
            panel1.Controls.Add(btnManageReturns);
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(btnRentalRequests);
            panel1.Controls.Add(btnFeedbacks);
            panel1.Controls.Add(btnRentalTransactions);
            panel1.Controls.Add(btnAuditLogs);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(btnManageEquips);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(152, 476);
            panel1.TabIndex = 8;
            panel1.Paint += panel1_Paint;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(0, 9, 103);
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.FlatStyle = FlatStyle.Popup;
            btnDashboard.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.IconChar = FontAwesome.Sharp.IconChar.Th;
            btnDashboard.IconColor = Color.White;
            btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDashboard.IconSize = 40;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(7, 11);
            btnDashboard.Margin = new Padding(2);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(143, 54);
            btnDashboard.TabIndex = 11;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click_1;
            // 
            // panel2
            // 
            panel2.Location = new Point(152, 61);
            panel2.Name = "panel2";
            panel2.Size = new Size(684, 419);
            panel2.TabIndex = 10;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.FromArgb(7, 8, 20);
            panelTitle.Controls.Add(MainLabel);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(152, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(966, 55);
            panelTitle.TabIndex = 9;
            // 
            // MainLabel
            // 
            MainLabel.AutoSize = true;
            MainLabel.BackColor = Color.FromArgb(7, 8, 20);
            MainLabel.Font = new Font("Cascadia Code SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            MainLabel.ForeColor = Color.White;
            MainLabel.Location = new Point(6, 9);
            MainLabel.Name = "MainLabel";
            MainLabel.Size = new Size(79, 35);
            MainLabel.TabIndex = 0;
            MainLabel.Text = "Home";
            MainLabel.Click += label1_Click;
            // 
            // MainPanel
            // 
            MainPanel.BackColor = SystemColors.ControlLightLight;
            MainPanel.Controls.Add(lblWelcome2);
            MainPanel.Controls.Add(lblWelcome);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(152, 55);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(966, 421);
            MainPanel.TabIndex = 10;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblWelcome.Location = new Point(151, 44);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(631, 37);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome to Equipment Rental Management System";
            // 
            // lblWelcome2
            // 
            lblWelcome2.AutoSize = true;
            lblWelcome2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblWelcome2.Location = new Point(256, 98);
            lblWelcome2.Name = "lblWelcome2";
            lblWelcome2.Size = new Size(428, 28);
            lblWelcome2.TabIndex = 1;
            lblWelcome2.Text = "Rent the equipment you need, when you need it";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1118, 476);
            Controls.Add(MainPanel);
            Controls.Add(panelTitle);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "Home";
            Text = "Home";
            FormClosing += Home_FormClosing;
            Load += Home_Load;
            panel1.ResumeLayout(false);
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ResumeLayout(false);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void BtnRentalRequests_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnLogout;
        private FontAwesome.Sharp.IconButton btnAuditLogs;
        private FontAwesome.Sharp.IconButton btnRentalTransactions;
        private FontAwesome.Sharp.IconButton btnFeedbacks;
        private FontAwesome.Sharp.IconButton btnManageReturns;
        private FontAwesome.Sharp.IconButton btnRentalRequests;
        private FontAwesome.Sharp.IconButton btnManageEquips;
        private Panel panel1;
        private Panel panelTitle;
        private Label MainLabel;
        private Panel panel2;
        private Panel MainPanel;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private Label lblWelcome;
        private Label lblWelcome2;
    }
}