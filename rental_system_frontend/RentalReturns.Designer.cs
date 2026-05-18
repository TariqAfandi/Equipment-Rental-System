namespace rental_system_frontend
{
    partial class RentalReturns
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
            dgvRecord = new DataGridView();
            btnRefresh = new Button();
            btnFilter = new Button();
            ddlCondition = new ComboBox();
            lblCondition = new Label();
            panelTop = new Panel();
            txtSearchCustomerEquipment = new TextBox();
            lblSearchCustomerEquipment = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRecord).BeginInit();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRecord
            // 
            dgvRecord.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecord.Dock = DockStyle.Fill;
            dgvRecord.Location = new Point(0, 48);
            dgvRecord.Margin = new Padding(2);
            dgvRecord.Name = "dgvRecord";
            dgvRecord.RowHeadersWidth = 62;
            dgvRecord.RowTemplate.Height = 33;
            dgvRecord.Size = new Size(953, 402);
            dgvRecord.TabIndex = 17;
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
            btnRefresh.Click += this.btnRefresh_Click;
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
            // ddlCondition
            // 
            ddlCondition.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ddlCondition.FormattingEnabled = true;
            ddlCondition.Items.AddRange(new object[] { "Lost", "Damage", "Good" });
            ddlCondition.Location = new Point(511, 11);
            ddlCondition.Margin = new Padding(2);
            ddlCondition.Name = "ddlCondition";
            ddlCondition.Size = new Size(177, 24);
            ddlCondition.TabIndex = 4;
            // 
            // lblCondition
            // 
            lblCondition.AutoSize = true;
            lblCondition.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCondition.ForeColor = Color.White;
            lblCondition.Location = new Point(407, 13);
            lblCondition.Margin = new Padding(2, 0, 2, 0);
            lblCondition.Name = "lblCondition";
            lblCondition.Size = new Size(100, 21);
            lblCondition.TabIndex = 3;
            lblCondition.Text = "Condition:";
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(4, 9, 56);
            panelTop.Controls.Add(txtSearchCustomerEquipment);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(btnFilter);
            panelTop.Controls.Add(ddlCondition);
            panelTop.Controls.Add(lblCondition);
            panelTop.Controls.Add(lblSearchCustomerEquipment);
            panelTop.Cursor = Cursors.Hand;
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(2);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(953, 48);
            panelTop.TabIndex = 15;
            // 
            // txtSearchCustomerEquipment
            // 
            txtSearchCustomerEquipment.Location = new Point(243, 11);
            txtSearchCustomerEquipment.Name = "txtSearchCustomerEquipment";
            txtSearchCustomerEquipment.Size = new Size(159, 23);
            txtSearchCustomerEquipment.TabIndex = 9;
            // 
            // lblSearchCustomerEquipment
            // 
            lblSearchCustomerEquipment.AutoSize = true;
            lblSearchCustomerEquipment.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSearchCustomerEquipment.ForeColor = Color.White;
            lblSearchCustomerEquipment.Location = new Point(3, 13);
            lblSearchCustomerEquipment.Margin = new Padding(2, 0, 2, 0);
            lblSearchCustomerEquipment.Name = "lblSearchCustomerEquipment";
            lblSearchCustomerEquipment.Size = new Size(235, 21);
            lblSearchCustomerEquipment.TabIndex = 1;
            lblSearchCustomerEquipment.Text = "Search Customer/Equipment";
            // 
            // RentalReturns
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 450);
            Controls.Add(dgvRecord);
            Controls.Add(panelTop);
            Margin = new Padding(2);
            Name = "RentalReturns";
            Text = "ManageReturns";
            Load += RentalReturns_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRecord).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvRecord;
        private Button btnRefresh;
        private Button btnFilter;
        private ComboBox comboBox1;
        private Label lblCondition;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Panel panelTop;
        private Panel panel1;
        private Label lblReturnDate;
        private DateTimePicker dateTimePicker1;
        private ComboBox ddlCondition;
        private TextBox txtSearchCustomerEquipment;
        private Label lblSearchCustomerEquipment;
    }
}