namespace rental_system_frontend
{
    partial class AddReturn
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
            lblTitle = new Label();
            panel1 = new Panel();
            txtBoxAdditionalCharges = new TextBox();
            lblAdditionalCharges = new Label();
            txtBoxTransactionID = new TextBox();
            lblTransactionID = new Label();
            ddlCondition = new ComboBox();
            txtBoxLateFee = new TextBox();
            dtpReturnDate = new DateTimePicker();
            txtBoxReturnID = new TextBox();
            lblCondition = new Label();
            lblLateFee = new Label();
            lblReturnID = new Label();
            lblReturnDate = new Label();
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
            btnCancel.Location = new Point(396, 559);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(181, 45);
            btnCancel.TabIndex = 66;
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
            btnSave.Location = new Point(70, 559);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(181, 45);
            btnSave.TabIndex = 65;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(7, 8, 20);
            lblTitle.Font = new Font("Cascadia Code SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(221, 9);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(252, 52);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Add Return";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
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
            // txtBoxAdditionalCharges
            // 
            txtBoxAdditionalCharges.Location = new Point(247, 478);
            txtBoxAdditionalCharges.Name = "txtBoxAdditionalCharges";
            txtBoxAdditionalCharges.Size = new Size(330, 31);
            txtBoxAdditionalCharges.TabIndex = 94;
            // 
            // lblAdditionalCharges
            // 
            lblAdditionalCharges.AutoSize = true;
            lblAdditionalCharges.Location = new Point(70, 481);
            lblAdditionalCharges.Name = "lblAdditionalCharges";
            lblAdditionalCharges.Size = new Size(173, 25);
            lblAdditionalCharges.TabIndex = 93;
            lblAdditionalCharges.Text = "AddiotionalCharges:";
            // 
            // txtBoxTransactionID
            // 
            txtBoxTransactionID.Location = new Point(247, 177);
            txtBoxTransactionID.Name = "txtBoxTransactionID";
            txtBoxTransactionID.Size = new Size(330, 31);
            txtBoxTransactionID.TabIndex = 92;
            // 
            // lblTransactionID
            // 
            lblTransactionID.AutoSize = true;
            lblTransactionID.Location = new Point(70, 180);
            lblTransactionID.Name = "lblTransactionID";
            lblTransactionID.Size = new Size(127, 25);
            lblTransactionID.TabIndex = 91;
            lblTransactionID.Text = "Transaction ID:";
            // 
            // ddlCondition
            // 
            ddlCondition.FormattingEnabled = true;
            ddlCondition.Location = new Point(247, 326);
            ddlCondition.Name = "ddlCondition";
            ddlCondition.Size = new Size(330, 33);
            ddlCondition.TabIndex = 89;
            // 
            // txtBoxLateFee
            // 
            txtBoxLateFee.Location = new Point(247, 403);
            txtBoxLateFee.Name = "txtBoxLateFee";
            txtBoxLateFee.Size = new Size(330, 31);
            txtBoxLateFee.TabIndex = 88;
            // 
            // dtpReturnDate
            // 
            dtpReturnDate.Location = new Point(247, 248);
            dtpReturnDate.Name = "dtpReturnDate";
            dtpReturnDate.Size = new Size(330, 31);
            dtpReturnDate.TabIndex = 90;
            // 
            // txtBoxReturnID
            // 
            txtBoxReturnID.Location = new Point(247, 113);
            txtBoxReturnID.Name = "txtBoxReturnID";
            txtBoxReturnID.Size = new Size(330, 31);
            txtBoxReturnID.TabIndex = 87;
            // 
            // lblCondition
            // 
            lblCondition.AutoSize = true;
            lblCondition.Location = new Point(70, 334);
            lblCondition.Name = "lblCondition";
            lblCondition.Size = new Size(94, 25);
            lblCondition.TabIndex = 86;
            lblCondition.Text = "Condition:";
            // 
            // lblLateFee
            // 
            lblLateFee.AutoSize = true;
            lblLateFee.Location = new Point(70, 403);
            lblLateFee.Name = "lblLateFee";
            lblLateFee.Size = new Size(80, 25);
            lblLateFee.TabIndex = 85;
            lblLateFee.Text = "Late Fee:";
            // 
            // lblReturnID
            // 
            lblReturnID.AutoSize = true;
            lblReturnID.Location = new Point(70, 116);
            lblReturnID.Name = "lblReturnID";
            lblReturnID.Size = new Size(90, 25);
            lblReturnID.TabIndex = 83;
            lblReturnID.Text = "Return ID:";
            // 
            // lblReturnDate
            // 
            lblReturnDate.AutoSize = true;
            lblReturnDate.Location = new Point(70, 248);
            lblReturnDate.Name = "lblReturnDate";
            lblReturnDate.Size = new Size(109, 25);
            lblReturnDate.TabIndex = 84;
            lblReturnDate.Text = "Return Date:";
            // 
            // AddReturn
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 634);
            Controls.Add(txtBoxAdditionalCharges);
            Controls.Add(lblAdditionalCharges);
            Controls.Add(txtBoxTransactionID);
            Controls.Add(lblTransactionID);
            Controls.Add(ddlCondition);
            Controls.Add(txtBoxLateFee);
            Controls.Add(dtpReturnDate);
            Controls.Add(txtBoxReturnID);
            Controls.Add(lblCondition);
            Controls.Add(lblLateFee);
            Controls.Add(lblReturnID);
            Controls.Add(lblReturnDate);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(panel1);
            Name = "AddReturn";
            Text = "AddReturn";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private Label lblTitle;
        private Panel panel1;
        private TextBox txtBoxAdditionalCharges;
        private Label lblAdditionalCharges;
        private TextBox txtBoxTransactionID;
        private Label lblTransactionID;
        private ComboBox ddlCondition;
        private TextBox txtBoxLateFee;
        private DateTimePicker dtpReturnDate;
        private TextBox txtBoxReturnID;
        private Label lblCondition;
        private Label lblLateFee;
        private Label lblReturnID;
        private Label lblReturnDate;
    }
}