namespace rental_system_frontend
{
    partial class RentalRequests
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
            panelTop = new Panel();
            txtSearchCustomerEquipment = new TextBox();
            btnRefresh = new Button();
            btnFilter = new Button();
            ddlStatus = new ComboBox();
            lblStatus = new Label();
            lblSearchCustomerEquipment = new Label();
            btnApprove = new Button();
            btnReject = new Button();
            panel1 = new Panel();
            dgvRequests = new DataGridView();
            panelTop.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(4, 9, 56);
            panelTop.Controls.Add(txtSearchCustomerEquipment);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(btnFilter);
            panelTop.Controls.Add(ddlStatus);
            panelTop.Controls.Add(lblStatus);
            panelTop.Controls.Add(lblSearchCustomerEquipment);
            panelTop.Cursor = Cursors.Hand;
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(2);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(962, 46);
            panelTop.TabIndex = 11;
            // 
            // txtSearchCustomerEquipment
            // 
            txtSearchCustomerEquipment.Location = new Point(251, 13);
            txtSearchCustomerEquipment.Name = "txtSearchCustomerEquipment";
            txtSearchCustomerEquipment.Size = new Size(171, 23);
            txtSearchCustomerEquipment.TabIndex = 9;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(181, 245, 243);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Popup;
            btnRefresh.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRefresh.ForeColor = Color.FromArgb(0, 9, 103);
            btnRefresh.Location = new Point(825, 9);
            btnRefresh.Margin = new Padding(2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(119, 27);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Reset/Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click_1;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(181, 245, 243);
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.FlatStyle = FlatStyle.Popup;
            btnFilter.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnFilter.ForeColor = Color.FromArgb(0, 9, 103);
            btnFilter.Location = new Point(701, 9);
            btnFilter.Margin = new Padding(2);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(119, 27);
            btnFilter.TabIndex = 7;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // ddlStatus
            // 
            ddlStatus.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ddlStatus.FormattingEnabled = true;
            ddlStatus.Items.AddRange(new object[] { "Available", "Unavailable", "Under Maintenance" });
            ddlStatus.Location = new Point(504, 12);
            ddlStatus.Margin = new Padding(2);
            ddlStatus.Name = "ddlStatus";
            ddlStatus.Size = new Size(167, 24);
            ddlStatus.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(427, 13);
            lblStatus.Margin = new Padding(2, 0, 2, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(73, 21);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status:";
            // 
            // lblSearchCustomerEquipment
            // 
            lblSearchCustomerEquipment.AutoSize = true;
            lblSearchCustomerEquipment.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSearchCustomerEquipment.ForeColor = Color.White;
            lblSearchCustomerEquipment.Location = new Point(11, 11);
            lblSearchCustomerEquipment.Margin = new Padding(2, 0, 2, 0);
            lblSearchCustomerEquipment.Name = "lblSearchCustomerEquipment";
            lblSearchCustomerEquipment.Size = new Size(235, 21);
            lblSearchCustomerEquipment.TabIndex = 1;
            lblSearchCustomerEquipment.Text = "Search Customer/Equipment";
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.Green;
            btnApprove.Cursor = Cursors.Hand;
            btnApprove.FlatStyle = FlatStyle.Popup;
            btnApprove.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnApprove.ForeColor = Color.FromArgb(255, 243, 227);
            btnApprove.Location = new Point(11, 9);
            btnApprove.Margin = new Padding(2);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(127, 27);
            btnApprove.TabIndex = 0;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.BackColor = Color.FromArgb(255, 91, 77);
            btnReject.Cursor = Cursors.Hand;
            btnReject.FlatStyle = FlatStyle.Popup;
            btnReject.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnReject.ForeColor = Color.FromArgb(255, 243, 227);
            btnReject.Location = new Point(142, 9);
            btnReject.Margin = new Padding(2);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(147, 27);
            btnReject.TabIndex = 1;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += btnReject_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnApprove);
            panel1.Controls.Add(btnReject);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 366);
            panel1.Name = "panel1";
            panel1.Size = new Size(962, 45);
            panel1.TabIndex = 13;
            // 
            // dgvRequests
            // 
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Dock = DockStyle.Fill;
            dgvRequests.Location = new Point(0, 46);
            dgvRequests.Margin = new Padding(2);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersWidth = 62;
            dgvRequests.RowTemplate.Height = 33;
            dgvRequests.Size = new Size(962, 320);
            dgvRequests.TabIndex = 14;
            // 
            // RentalRequests
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 411);
            Controls.Add(dgvRequests);
            Controls.Add(panelTop);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "RentalRequests";
            Text = "RentalRequests";
            Load += RentalRequests_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Button btnFilter;
        private Button btnRefresh;
        private ComboBox ddlStatus;
        private Label lblStatus;
        private Label lblStartDate;
        private Button btnApprove;
        private Button btnReject;
        private Panel panel1;
        private DataGridView dataGridView1;
        private DateTimePicker dtpStartDate;
        private Button btnUpdate;
        private DateTimePicker dtpEndDate;
        private Label lblEndDate;
        private DataGridView dgvRequests;
        private TextBox txtSearchCustomerEquipment;
        private Label lblSearchCustomerEquipment;
    }
}