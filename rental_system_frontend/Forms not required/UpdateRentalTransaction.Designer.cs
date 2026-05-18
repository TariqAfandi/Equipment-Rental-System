namespace rental_system_frontend
{
    partial class UpdateRentalTransaction
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
            ddlPaymentStatus = new ComboBox();
            txtBoxDeposit = new TextBox();
            lblDeposit = new Label();
            txtRentalFee = new TextBox();
            lblRentalFee = new Label();
            txtBoxRentalPerios = new TextBox();
            dtpReturnDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            txtEquipmentID = new TextBox();
            lblTitle = new Label();
            lblPaymentSatuts = new Label();
            lblEquipmentID = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            txtBoxCustomerID = new TextBox();
            txtBoxRequestID = new TextBox();
            txtBoxTransactionID = new TextBox();
            lblRentalPeriod = new Label();
            lblReturnDate = new Label();
            lblStartDate = new Label();
            lblCustomerID = new Label();
            lblTransactionID = new Label();
            lblRequestID = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ddlPaymentStatus
            // 
            ddlPaymentStatus.FormattingEnabled = true;
            ddlPaymentStatus.Location = new Point(254, 735);
            ddlPaymentStatus.Name = "ddlPaymentStatus";
            ddlPaymentStatus.Size = new Size(330, 33);
            ddlPaymentStatus.TabIndex = 104;
            // 
            // txtBoxDeposit
            // 
            txtBoxDeposit.Location = new Point(254, 663);
            txtBoxDeposit.Name = "txtBoxDeposit";
            txtBoxDeposit.Size = new Size(330, 31);
            txtBoxDeposit.TabIndex = 102;
            // 
            // lblDeposit
            // 
            lblDeposit.AutoSize = true;
            lblDeposit.Location = new Point(77, 663);
            lblDeposit.Name = "lblDeposit";
            lblDeposit.Size = new Size(78, 25);
            lblDeposit.TabIndex = 101;
            lblDeposit.Text = "Deposit:";
            // 
            // txtRentalFee
            // 
            txtRentalFee.Location = new Point(254, 587);
            txtRentalFee.Name = "txtRentalFee";
            txtRentalFee.Size = new Size(330, 31);
            txtRentalFee.TabIndex = 100;
            // 
            // lblRentalFee
            // 
            lblRentalFee.AutoSize = true;
            lblRentalFee.Location = new Point(77, 587);
            lblRentalFee.Name = "lblRentalFee";
            lblRentalFee.Size = new Size(96, 25);
            lblRentalFee.TabIndex = 99;
            lblRentalFee.Text = "Rental Fee:";
            // 
            // txtBoxRentalPerios
            // 
            txtBoxRentalPerios.Location = new Point(254, 521);
            txtBoxRentalPerios.Name = "txtBoxRentalPerios";
            txtBoxRentalPerios.Size = new Size(330, 31);
            txtBoxRentalPerios.TabIndex = 98;
            // 
            // dtpReturnDate
            // 
            dtpReturnDate.Location = new Point(254, 451);
            dtpReturnDate.Name = "dtpReturnDate";
            dtpReturnDate.Size = new Size(330, 31);
            dtpReturnDate.TabIndex = 97;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(254, 383);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(330, 31);
            dtpStartDate.TabIndex = 96;
            // 
            // txtEquipmentID
            // 
            txtEquipmentID.Location = new Point(254, 318);
            txtEquipmentID.Name = "txtEquipmentID";
            txtEquipmentID.Size = new Size(330, 31);
            txtEquipmentID.TabIndex = 95;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(7, 8, 20);
            lblTitle.Font = new Font("Cascadia Code SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(148, 9);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(436, 52);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Update Transaction";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPaymentSatuts
            // 
            lblPaymentSatuts.AutoSize = true;
            lblPaymentSatuts.Location = new Point(77, 735);
            lblPaymentSatuts.Name = "lblPaymentSatuts";
            lblPaymentSatuts.Size = new Size(137, 25);
            lblPaymentSatuts.TabIndex = 103;
            lblPaymentSatuts.Text = "Payment Status:";
            // 
            // lblEquipmentID
            // 
            lblEquipmentID.AutoSize = true;
            lblEquipmentID.Location = new Point(77, 318);
            lblEquipmentID.Name = "lblEquipmentID";
            lblEquipmentID.Size = new Size(125, 25);
            lblEquipmentID.TabIndex = 94;
            lblEquipmentID.Text = "Equipment ID:";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 91, 77);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.FromArgb(255, 243, 227);
            btnCancel.Location = new Point(403, 810);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(181, 45);
            btnCancel.TabIndex = 93;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 9, 103);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.FromArgb(255, 243, 227);
            btnSave.Location = new Point(77, 810);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(181, 45);
            btnSave.TabIndex = 92;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // txtBoxCustomerID
            // 
            txtBoxCustomerID.Location = new Point(254, 252);
            txtBoxCustomerID.Name = "txtBoxCustomerID";
            txtBoxCustomerID.Size = new Size(330, 31);
            txtBoxCustomerID.TabIndex = 91;
            // 
            // txtBoxRequestID
            // 
            txtBoxRequestID.Location = new Point(254, 187);
            txtBoxRequestID.Name = "txtBoxRequestID";
            txtBoxRequestID.Size = new Size(330, 31);
            txtBoxRequestID.TabIndex = 90;
            // 
            // txtBoxTransactionID
            // 
            txtBoxTransactionID.Location = new Point(254, 122);
            txtBoxTransactionID.Name = "txtBoxTransactionID";
            txtBoxTransactionID.Size = new Size(330, 31);
            txtBoxTransactionID.TabIndex = 89;
            // 
            // lblRentalPeriod
            // 
            lblRentalPeriod.AutoSize = true;
            lblRentalPeriod.Location = new Point(77, 521);
            lblRentalPeriod.Name = "lblRentalPeriod";
            lblRentalPeriod.Size = new Size(119, 25);
            lblRentalPeriod.TabIndex = 88;
            lblRentalPeriod.Text = "Rental Period:";
            // 
            // lblReturnDate
            // 
            lblReturnDate.AutoSize = true;
            lblReturnDate.Location = new Point(77, 451);
            lblReturnDate.Name = "lblReturnDate";
            lblReturnDate.Size = new Size(109, 25);
            lblReturnDate.TabIndex = 87;
            lblReturnDate.Text = "Return Date:";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(77, 383);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(94, 25);
            lblStartDate.TabIndex = 86;
            lblStartDate.Text = "Start Date:";
            // 
            // lblCustomerID
            // 
            lblCustomerID.AutoSize = true;
            lblCustomerID.Location = new Point(77, 252);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(116, 25);
            lblCustomerID.TabIndex = 85;
            lblCustomerID.Text = "Customer ID:";
            // 
            // lblTransactionID
            // 
            lblTransactionID.AutoSize = true;
            lblTransactionID.Location = new Point(77, 125);
            lblTransactionID.Name = "lblTransactionID";
            lblTransactionID.Size = new Size(127, 25);
            lblTransactionID.TabIndex = 83;
            lblTransactionID.Text = "Transaction ID:";
            // 
            // lblRequestID
            // 
            lblRequestID.AutoSize = true;
            lblRequestID.Location = new Point(77, 187);
            lblRequestID.Name = "lblRequestID";
            lblRequestID.Size = new Size(102, 25);
            lblRequestID.TabIndex = 84;
            lblRequestID.Text = "Request ID:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(4, 9, 56);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(643, 73);
            panel1.TabIndex = 82;
            // 
            // UpdateRentalTransaction
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 870);
            Controls.Add(ddlPaymentStatus);
            Controls.Add(txtBoxDeposit);
            Controls.Add(lblDeposit);
            Controls.Add(txtRentalFee);
            Controls.Add(lblRentalFee);
            Controls.Add(txtBoxRentalPerios);
            Controls.Add(dtpReturnDate);
            Controls.Add(dtpStartDate);
            Controls.Add(txtEquipmentID);
            Controls.Add(lblPaymentSatuts);
            Controls.Add(lblEquipmentID);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtBoxCustomerID);
            Controls.Add(txtBoxRequestID);
            Controls.Add(txtBoxTransactionID);
            Controls.Add(lblRentalPeriod);
            Controls.Add(lblReturnDate);
            Controls.Add(lblStartDate);
            Controls.Add(lblCustomerID);
            Controls.Add(lblTransactionID);
            Controls.Add(lblRequestID);
            Controls.Add(panel1);
            Name = "UpdateRentalTransaction";
            Text = "UpdateRentalTransaction";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ddlPaymentStatus;
        private TextBox txtBoxDeposit;
        private Label lblDeposit;
        private TextBox txtRentalFee;
        private Label lblRentalFee;
        private TextBox txtBoxRentalPerios;
        private DateTimePicker dtpReturnDate;
        private DateTimePicker dtpStartDate;
        private TextBox txtEquipmentID;
        private Label lblTitle;
        private Label lblPaymentSatuts;
        private Label lblEquipmentID;
        private Button btnCancel;
        private Button btnSave;
        private TextBox txtBoxCustomerID;
        private TextBox txtBoxRequestID;
        private TextBox txtBoxTransactionID;
        private Label lblRentalPeriod;
        private Label lblReturnDate;
        private Label lblStartDate;
        private Label lblCustomerID;
        private Label lblTransactionID;
        private Label lblRequestID;
        private Panel panel1;
    }
}