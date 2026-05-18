namespace rental_system_frontend
{
    partial class UpdateEquipment
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
            ddlCondition = new ComboBox();
            ddlStatus = new ComboBox();
            txtBoxPrice = new TextBox();
            txtDescription = new TextBox();
            txtBoxName = new TextBox();
            txtBoxEquipmentID = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            lblCategory = new Label();
            label2 = new Label();
            lblEquipmentID = new Label();
            lblTitle = new Label();
            lblEquipmentName = new Label();
            panel1 = new Panel();
            ddlCategory = new ComboBox();
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
            btnCancel.Location = new Point(286, 389);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(127, 27);
            btnCancel.TabIndex = 36;
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
            btnSave.Location = new Point(57, 389);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(127, 27);
            btnSave.TabIndex = 35;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // ddlCondition
            // 
            ddlCondition.FormattingEnabled = true;
            ddlCondition.Location = new Point(181, 339);
            ddlCondition.Margin = new Padding(2);
            ddlCondition.Name = "ddlCondition";
            ddlCondition.Size = new Size(232, 23);
            ddlCondition.TabIndex = 34;
            // 
            // ddlStatus
            // 
            ddlStatus.FormattingEnabled = true;
            ddlStatus.Location = new Point(181, 293);
            ddlStatus.Margin = new Padding(2);
            ddlStatus.Name = "ddlStatus";
            ddlStatus.Size = new Size(232, 23);
            ddlStatus.TabIndex = 33;
            // 
            // txtBoxPrice
            // 
            txtBoxPrice.Location = new Point(181, 247);
            txtBoxPrice.Margin = new Padding(2);
            txtBoxPrice.Name = "txtBoxPrice";
            txtBoxPrice.Size = new Size(232, 23);
            txtBoxPrice.TabIndex = 31;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(181, 163);
            txtDescription.Margin = new Padding(2);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(232, 23);
            txtDescription.TabIndex = 30;
            // 
            // txtBoxName
            // 
            txtBoxName.Location = new Point(181, 122);
            txtBoxName.Margin = new Padding(2);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(232, 23);
            txtBoxName.TabIndex = 29;
            // 
            // txtBoxEquipmentID
            // 
            txtBoxEquipmentID.Location = new Point(181, 75);
            txtBoxEquipmentID.Margin = new Padding(2);
            txtBoxEquipmentID.Name = "txtBoxEquipmentID";
            txtBoxEquipmentID.ReadOnly = true;
            txtBoxEquipmentID.Size = new Size(232, 23);
            txtBoxEquipmentID.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(57, 344);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 27;
            label6.Text = "Condition:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(57, 298);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 26;
            label5.Text = "Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 247);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 25;
            label4.Text = "Price:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(57, 203);
            lblCategory.Margin = new Padding(2, 0, 2, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(58, 15);
            lblCategory.TabIndex = 24;
            lblCategory.Text = "Category:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 163);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 23;
            label2.Text = "Description";
            // 
            // lblEquipmentID
            // 
            lblEquipmentID.AutoSize = true;
            lblEquipmentID.Location = new Point(57, 77);
            lblEquipmentID.Margin = new Padding(2, 0, 2, 0);
            lblEquipmentID.Name = "lblEquipmentID";
            lblEquipmentID.Size = new Size(82, 15);
            lblEquipmentID.TabIndex = 21;
            lblEquipmentID.Text = "Equipment ID:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(7, 8, 20);
            lblTitle.Font = new Font("Cascadia Code SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(99, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(271, 35);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Update Equipment";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEquipmentName
            // 
            lblEquipmentName.AutoSize = true;
            lblEquipmentName.Location = new Point(57, 122);
            lblEquipmentName.Margin = new Padding(2, 0, 2, 0);
            lblEquipmentName.Name = "lblEquipmentName";
            lblEquipmentName.Size = new Size(103, 15);
            lblEquipmentName.TabIndex = 22;
            lblEquipmentName.Text = "Equipment Name:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(4, 9, 56);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(450, 44);
            panel1.TabIndex = 20;
            // 
            // ddlCategory
            // 
            ddlCategory.FormattingEnabled = true;
            ddlCategory.Location = new Point(181, 199);
            ddlCategory.Margin = new Padding(2);
            ddlCategory.Name = "ddlCategory";
            ddlCategory.Size = new Size(232, 23);
            ddlCategory.TabIndex = 37;
            // 
            // UpdateEquipment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 442);
            Controls.Add(ddlCategory);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(ddlCondition);
            Controls.Add(ddlStatus);
            Controls.Add(txtBoxPrice);
            Controls.Add(txtDescription);
            Controls.Add(txtBoxName);
            Controls.Add(txtBoxEquipmentID);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lblCategory);
            Controls.Add(label2);
            Controls.Add(lblEquipmentID);
            Controls.Add(lblEquipmentName);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "UpdateEquipment";
            Text = "UpdateEquipment";
            Load += UpdateEquipment_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private ComboBox ddlCondition;
        private ComboBox ddlStatus;
        private TextBox txtBoxPrice;
        private TextBox txtDescription;
        private TextBox txtBoxName;
        private TextBox txtBoxEquipmentID;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label lblCategory;
        private Label label2;
        private Label lblEquipmentID;
        private Label lblTitle;
        private Label lblEquipmentName;
        private Panel panel1;
        private ComboBox ddlCategory;
    }
}