namespace rental_system_frontend
{
    partial class UpdateRentalRequest
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
            btnCancel = new Button();
            btnSave = new Button();
            ddlStatus = new ComboBox();
            txtDescription = new TextBox();
            txtBoxEquipmentID = new TextBox();
            lblTitle = new Label();
            lblStatus = new Label();
            lblTotalCost = new Label();
            lblEndDate = new Label();
            lblStartDate = new Label();
            lblEquipmentID = new Label();
            lblRequestID = new Label();
            lblCustomerID = new Label();
            panel1 = new Panel();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            txtBoxRequestID = new TextBox();
            txtBoxTotalCost = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 91, 77);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.FromArgb(255, 243, 227);
            btnCancel.Location = new Point(408, 666);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(181, 45);
            btnCancel.TabIndex = 53;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 9, 103);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.FromArgb(255, 243, 227);
            btnSave.Location = new Point(82, 666);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(181, 45);
            btnSave.TabIndex = 52;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // ddlStatus
            // 
            ddlStatus.FormattingEnabled = true;
            ddlStatus.Location = new Point(259, 572);
            ddlStatus.Name = "ddlStatus";
            ddlStatus.Size = new Size(330, 33);
            ddlStatus.TabIndex = 51;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(259, 278);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(330, 31);
            txtDescription.TabIndex = 47;
            // 
            // txtBoxEquipmentID
            // 
            txtBoxEquipmentID.Location = new Point(259, 211);
            txtBoxEquipmentID.Name = "txtBoxEquipmentID";
            txtBoxEquipmentID.Size = new Size(330, 31);
            txtBoxEquipmentID.TabIndex = 46;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(7, 8, 20);
            lblTitle.Font = new Font("Cascadia Code SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(95, 9);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(505, 52);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Update Rental Request";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(82, 580);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(64, 25);
            lblStatus.TabIndex = 44;
            lblStatus.Text = "Status:";
            // 
            // lblTotalCost
            // 
            lblTotalCost.AutoSize = true;
            lblTotalCost.Location = new Point(82, 504);
            lblTotalCost.Name = "lblTotalCost";
            lblTotalCost.Size = new Size(94, 25);
            lblTotalCost.TabIndex = 43;
            lblTotalCost.Text = "Total Cost:";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(82, 418);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(88, 25);
            lblEndDate.TabIndex = 42;
            lblEndDate.Text = "End Date:";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(82, 346);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(94, 25);
            lblStartDate.TabIndex = 41;
            lblStartDate.Text = "Start Date:";
            // 
            // lblEquipmentID
            // 
            lblEquipmentID.AutoSize = true;
            lblEquipmentID.Location = new Point(82, 278);
            lblEquipmentID.Name = "lblEquipmentID";
            lblEquipmentID.Size = new Size(125, 25);
            lblEquipmentID.TabIndex = 40;
            lblEquipmentID.Text = "Equipment ID:";
            // 
            // lblRequestID
            // 
            lblRequestID.AutoSize = true;
            lblRequestID.Location = new Point(82, 135);
            lblRequestID.Name = "lblRequestID";
            lblRequestID.Size = new Size(102, 25);
            lblRequestID.TabIndex = 38;
            lblRequestID.Text = "Request ID:";
            // 
            // lblCustomerID
            // 
            lblCustomerID.AutoSize = true;
            lblCustomerID.Location = new Point(82, 211);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(116, 25);
            lblCustomerID.TabIndex = 39;
            lblCustomerID.Text = "Customer ID:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(4, 9, 56);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(643, 73);
            panel1.TabIndex = 37;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(259, 348);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(330, 31);
            dtpStartDate.TabIndex = 54;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(259, 418);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(330, 31);
            dtpEndDate.TabIndex = 55;
            // 
            // txtBoxRequestID
            // 
            txtBoxRequestID.Location = new Point(259, 132);
            txtBoxRequestID.Name = "txtBoxRequestID";
            txtBoxRequestID.Size = new Size(330, 31);
            txtBoxRequestID.TabIndex = 45;
            // 
            // txtBoxTotalCost
            // 
            txtBoxTotalCost.Location = new Point(259, 498);
            txtBoxTotalCost.Name = "txtBoxTotalCost";
            txtBoxTotalCost.Size = new Size(330, 31);
            txtBoxTotalCost.TabIndex = 56;
            // 
            // UpdateRentalRequest
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 736);
            Controls.Add(txtBoxTotalCost);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(ddlStatus);
            Controls.Add(txtDescription);
            Controls.Add(txtBoxEquipmentID);
            Controls.Add(txtBoxRequestID);
            Controls.Add(lblStatus);
            Controls.Add(lblTotalCost);
            Controls.Add(lblEndDate);
            Controls.Add(lblStartDate);
            Controls.Add(lblEquipmentID);
            Controls.Add(lblRequestID);
            Controls.Add(lblCustomerID);
            Controls.Add(panel1);
            Name = "UpdateRentalRequest";
            Text = "UpdateRentalRequest";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private ComboBox ddlStatus;
        private TextBox txtDescription;
        private TextBox txtBoxEquipmentID;
        private Label lblTitle;
        private Label lblStatus;
        private Label lblTotalCost;
        private Label lblEndDate;
        private Label lblStartDate;
        private Label lblEquipmentID;
        private Label lblRequestID;
        private Label lblCustomerID;
        private Panel panel1;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private TextBox txtBoxRequestID;
        private TextBox txtBoxTotalCost;
    }
}