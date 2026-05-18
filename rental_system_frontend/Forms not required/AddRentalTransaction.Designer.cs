namespace rental_system_frontend
{
    partial class AddRentalTransaction
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
            lblTitle = new Label();
            txtEquipmentID = new TextBox();
            dtpStartDate = new DateTimePicker();
            dtpReturnDate = new DateTimePicker();
            txtBoxRentalPerios = new TextBox();
            txtRentalFee = new TextBox();
            lblRentalFee = new Label();
            txtBoxDeposit = new TextBox();
            lblDeposit = new Label();
            lblPaymentSatuts = new Label();
            ddlPaymentStatus = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblEquipmentID
            // 
            lblEquipmentID.AutoSize = true;
            lblEquipmentID.Location = new Point(77, 303);
            lblEquipmentID.Name = "lblEquipmentID";
            lblEquipmentID.Size = new Size(125, 25);
            lblEquipmentID.TabIndex = 71;
            lblEquipmentID.Text = "Equipment ID:";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 91, 77);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.FromArgb(255, 243, 227);
            btnCancel.Location = new Point(403, 795);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(181, 45);
            btnCancel.TabIndex = 70;
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
            btnSave.Location = new Point(77, 795);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(181, 45);
            btnSave.TabIndex = 69;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtBoxCustomerID
            // 
            txtBoxCustomerID.Location = new Point(254, 237);
            txtBoxCustomerID.Name = "txtBoxCustomerID";
            txtBoxCustomerID.Size = new Size(330, 31);
            txtBoxCustomerID.TabIndex = 65;
            // 
            // txtBoxRequestID
            // 
            txtBoxRequestID.Location = new Point(254, 172);
            txtBoxRequestID.Name = "txtBoxRequestID";
            txtBoxRequestID.Size = new Size(330, 31);
            txtBoxRequestID.TabIndex = 64;
            // 
            // txtBoxTransactionID
            // 
            txtBoxTransactionID.Location = new Point(254, 107);
            txtBoxTransactionID.Name = "txtBoxTransactionID";
            txtBoxTransactionID.Size = new Size(330, 31);
            txtBoxTransactionID.TabIndex = 63;
            // 
            // lblRentalPeriod
            // 
            lblRentalPeriod.AutoSize = true;
            lblRentalPeriod.Location = new Point(77, 506);
            lblRentalPeriod.Name = "lblRentalPeriod";
            lblRentalPeriod.Size = new Size(119, 25);
            lblRentalPeriod.TabIndex = 62;
            lblRentalPeriod.Text = "Rental Period:";
            // 
            // lblReturnDate
            // 
            lblReturnDate.AutoSize = true;
            lblReturnDate.Location = new Point(77, 436);
            lblReturnDate.Name = "lblReturnDate";
            lblReturnDate.Size = new Size(109, 25);
            lblReturnDate.TabIndex = 61;
            lblReturnDate.Text = "Return Date:";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(77, 368);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(94, 25);
            lblStartDate.TabIndex = 60;
            lblStartDate.Text = "Start Date:";
            // 
            // lblCustomerID
            // 
            lblCustomerID.AutoSize = true;
            lblCustomerID.Location = new Point(77, 237);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(116, 25);
            lblCustomerID.TabIndex = 59;
            lblCustomerID.Text = "Customer ID:";
            // 
            // lblTransactionID
            // 
            lblTransactionID.AutoSize = true;
            lblTransactionID.Location = new Point(77, 110);
            lblTransactionID.Name = "lblTransactionID";
            lblTransactionID.Size = new Size(127, 25);
            lblTransactionID.TabIndex = 57;
            lblTransactionID.Text = "Transaction ID:";
            // 
            // lblRequestID
            // 
            lblRequestID.AutoSize = true;
            lblRequestID.Location = new Point(77, 172);
            lblRequestID.Name = "lblRequestID";
            lblRequestID.Size = new Size(102, 25);
            lblRequestID.TabIndex = 58;
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
            panel1.TabIndex = 56;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(7, 8, 20);
            lblTitle.Font = new Font("Cascadia Code SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(159, 9);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(367, 52);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Add Transaction";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtEquipmentID
            // 
            txtEquipmentID.Location = new Point(254, 303);
            txtEquipmentID.Name = "txtEquipmentID";
            txtEquipmentID.Size = new Size(330, 31);
            txtEquipmentID.TabIndex = 72;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(254, 368);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(330, 31);
            dtpStartDate.TabIndex = 73;
            // 
            // dtpReturnDate
            // 
            dtpReturnDate.Location = new Point(254, 436);
            dtpReturnDate.Name = "dtpReturnDate";
            dtpReturnDate.Size = new Size(330, 31);
            dtpReturnDate.TabIndex = 74;
            // 
            // txtBoxRentalPerios
            // 
            txtBoxRentalPerios.Location = new Point(254, 506);
            txtBoxRentalPerios.Name = "txtBoxRentalPerios";
            txtBoxRentalPerios.Size = new Size(330, 31);
            txtBoxRentalPerios.TabIndex = 75;
            // 
            // txtRentalFee
            // 
            txtRentalFee.Location = new Point(254, 572);
            txtRentalFee.Name = "txtRentalFee";
            txtRentalFee.Size = new Size(330, 31);
            txtRentalFee.TabIndex = 77;
            // 
            // lblRentalFee
            // 
            lblRentalFee.AutoSize = true;
            lblRentalFee.Location = new Point(77, 572);
            lblRentalFee.Name = "lblRentalFee";
            lblRentalFee.Size = new Size(96, 25);
            lblRentalFee.TabIndex = 76;
            lblRentalFee.Text = "Rental Fee:";
            // 
            // txtBoxDeposit
            // 
            txtBoxDeposit.Location = new Point(254, 648);
            txtBoxDeposit.Name = "txtBoxDeposit";
            txtBoxDeposit.Size = new Size(330, 31);
            txtBoxDeposit.TabIndex = 79;
            // 
            // lblDeposit
            // 
            lblDeposit.AutoSize = true;
            lblDeposit.Location = new Point(77, 648);
            lblDeposit.Name = "lblDeposit";
            lblDeposit.Size = new Size(78, 25);
            lblDeposit.TabIndex = 78;
            lblDeposit.Text = "Deposit:";
            // 
            // lblPaymentSatuts
            // 
            lblPaymentSatuts.AutoSize = true;
            lblPaymentSatuts.Location = new Point(77, 720);
            lblPaymentSatuts.Name = "lblPaymentSatuts";
            lblPaymentSatuts.Size = new Size(137, 25);
            lblPaymentSatuts.TabIndex = 80;
            lblPaymentSatuts.Text = "Payment Status:";
            // 
            // ddlPaymentStatus
            // 
            ddlPaymentStatus.FormattingEnabled = true;
            ddlPaymentStatus.Location = new Point(254, 720);
            ddlPaymentStatus.Name = "ddlPaymentStatus";
            ddlPaymentStatus.Size = new Size(330, 33);
            ddlPaymentStatus.TabIndex = 81;
            // 
            // AddRentalTransaction
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 870);
            Controls.Add(ddlPaymentStatus);
            Controls.Add(lblPaymentSatuts);
            Controls.Add(txtBoxDeposit);
            Controls.Add(lblDeposit);
            Controls.Add(txtRentalFee);
            Controls.Add(lblRentalFee);
            Controls.Add(txtBoxRentalPerios);
            Controls.Add(dtpReturnDate);
            Controls.Add(dtpStartDate);
            Controls.Add(txtEquipmentID);
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
            Name = "AddRentalTransaction";
            Text = "AddRentalTransaction";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private Label lblTitle;
        private TextBox txtEquipmentID;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpReturnDate;
        private TextBox txtBoxRentalPerios;
        private TextBox txtRentalFee;
        private Label lblRentalFee;
        private TextBox txtBoxDeposit;
        private Label lblDeposit;
        private Label lblPaymentSatuts;
        private ComboBox ddlPaymentStatus;
    }
}