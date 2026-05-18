namespace rental_system_frontend
{
    partial class RentalTransaction
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
            dgvTransaction = new DataGridView();
            panelTop = new Panel();
            lblSearchCustomerEquipment = new Label();
            txtSearchCustomerEquipment = new TextBox();
            btnRefresh = new Button();
            btnFilter = new Button();
            ddlStatus = new ComboBox();
            lblStatus = new Label();
            btnReturn = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvTransaction).BeginInit();
            panelTop.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTransaction
            // 
            dgvTransaction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransaction.Dock = DockStyle.Fill;
            dgvTransaction.Location = new Point(0, 45);
            dgvTransaction.Margin = new Padding(2);
            dgvTransaction.Name = "dgvTransaction";
            dgvTransaction.RowHeadersWidth = 62;
            dgvTransaction.RowTemplate.Height = 33;
            dgvTransaction.Size = new Size(953, 360);
            dgvTransaction.TabIndex = 17;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(4, 9, 56);
            panelTop.Controls.Add(lblSearchCustomerEquipment);
            panelTop.Controls.Add(txtSearchCustomerEquipment);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(btnFilter);
            panelTop.Controls.Add(ddlStatus);
            panelTop.Controls.Add(lblStatus);
            panelTop.Cursor = Cursors.Hand;
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(2);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(953, 45);
            panelTop.TabIndex = 15;
            // 
            // lblSearchCustomerEquipment
            // 
            lblSearchCustomerEquipment.AutoSize = true;
            lblSearchCustomerEquipment.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSearchCustomerEquipment.ForeColor = Color.White;
            lblSearchCustomerEquipment.Location = new Point(11, 13);
            lblSearchCustomerEquipment.Margin = new Padding(2, 0, 2, 0);
            lblSearchCustomerEquipment.Name = "lblSearchCustomerEquipment";
            lblSearchCustomerEquipment.Size = new Size(244, 21);
            lblSearchCustomerEquipment.TabIndex = 12;
            lblSearchCustomerEquipment.Text = "Search Customer/Equipment:";
            // 
            // txtSearchCustomerEquipment
            // 
            txtSearchCustomerEquipment.Location = new Point(260, 11);
            txtSearchCustomerEquipment.Name = "txtSearchCustomerEquipment";
            txtSearchCustomerEquipment.Size = new Size(189, 23);
            txtSearchCustomerEquipment.TabIndex = 11;
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
            btnRefresh.Click += btnRefresh_Click;
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
            ddlStatus.Location = new Point(531, 10);
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
            lblStatus.Location = new Point(454, 11);
            lblStatus.Margin = new Padding(2, 0, 2, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(73, 21);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status:";
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.FromArgb(0, 9, 103);
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.FlatStyle = FlatStyle.Popup;
            btnReturn.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnReturn.ForeColor = Color.FromArgb(255, 243, 227);
            btnReturn.Location = new Point(794, 9);
            btnReturn.Margin = new Padding(2);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(148, 27);
            btnReturn.TabIndex = 2;
            btnReturn.Text = "Return Equipment";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnReturn);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 405);
            panel1.Name = "panel1";
            panel1.Size = new Size(953, 45);
            panel1.TabIndex = 16;
            // 
            // RentalTransaction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 450);
            Controls.Add(dgvTransaction);
            Controls.Add(panelTop);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "RentalTransaction";
            Text = "Rental Transactions";
            Load += RentalTransactions_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTransaction).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panelTop;
        private DateTimePicker dtpEndDate;
        private Label lblReturnDate;
        private DateTimePicker dtpStartDate;
        private Button btnRefresh;
        private Button btnFilter;
        private ComboBox ddlStatus;
        private Label lblStatus;
        private Label lblStartDate;
        private Button btnDelete;
        private Panel panel1;
        private Button btnAdd;
        private Button btnUpdate;
        private Label label1;
        private TextBox textBox1;
        private DataGridView dgvTransaction;
        private Label lblSearchCustomerEquipment;
        private TextBox txtSearchCustomerEquipment;
        private Button btnReturn;
    }
}