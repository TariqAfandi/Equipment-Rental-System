namespace rental_system_frontend
{
    partial class AddEquipment
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
            lblTitle = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            ddlCondition = new ComboBox();
            ddlStatus = new ComboBox();
            txtBoxPrice = new TextBox();
            txtDescription = new TextBox();
            txtBoxName = new TextBox();
            txtBoxEquipID = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            lblEquipID = new Label();
            label1 = new Label();
            panel1 = new Panel();
            ddlCategory = new ComboBox();
            lblCategory = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(7, 8, 20);
            lblTitle.Font = new Font("Cascadia Code SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(122, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(223, 35);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Add Equipment";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 91, 77);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.FromArgb(255, 243, 227);
            btnCancel.Location = new Point(286, 397);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(127, 27);
            btnCancel.TabIndex = 53;
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
            btnSave.Location = new Point(57, 397);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(127, 27);
            btnSave.TabIndex = 52;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // ddlCondition
            // 
            ddlCondition.FormattingEnabled = true;
            ddlCondition.Location = new Point(181, 343);
            ddlCondition.Margin = new Padding(2);
            ddlCondition.Name = "ddlCondition";
            ddlCondition.Size = new Size(232, 23);
            ddlCondition.TabIndex = 51;
            // 
            // ddlStatus
            // 
            ddlStatus.FormattingEnabled = true;
            ddlStatus.Location = new Point(181, 298);
            ddlStatus.Margin = new Padding(2);
            ddlStatus.Name = "ddlStatus";
            ddlStatus.Size = new Size(232, 23);
            ddlStatus.TabIndex = 50;
            // 
            // txtBoxPrice
            // 
            txtBoxPrice.Location = new Point(181, 251);
            txtBoxPrice.Margin = new Padding(2);
            txtBoxPrice.Name = "txtBoxPrice";
            txtBoxPrice.Size = new Size(232, 23);
            txtBoxPrice.TabIndex = 49;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(181, 167);
            txtDescription.Margin = new Padding(2);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(232, 23);
            txtDescription.TabIndex = 48;
            // 
            // txtBoxName
            // 
            txtBoxName.Location = new Point(181, 127);
            txtBoxName.Margin = new Padding(2);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(232, 23);
            txtBoxName.TabIndex = 47;
            // 
            // txtBoxEquipID
            // 
            txtBoxEquipID.Location = new Point(181, 79);
            txtBoxEquipID.Margin = new Padding(2);
            txtBoxEquipID.Name = "txtBoxEquipID";
            txtBoxEquipID.ReadOnly = true;
            txtBoxEquipID.Size = new Size(232, 23);
            txtBoxEquipID.TabIndex = 46;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(57, 348);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 45;
            label6.Text = "Condition:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(57, 302);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 44;
            label5.Text = "Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 251);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 43;
            label4.Text = "Price:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 167);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 41;
            label2.Text = "Description";
            // 
            // lblEquipID
            // 
            lblEquipID.AutoSize = true;
            lblEquipID.Location = new Point(57, 81);
            lblEquipID.Margin = new Padding(2, 0, 2, 0);
            lblEquipID.Name = "lblEquipID";
            lblEquipID.Size = new Size(82, 15);
            lblEquipID.TabIndex = 39;
            lblEquipID.Text = "Equipment ID:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 127);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 40;
            label1.Text = "Equipment Name:";
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
            panel1.TabIndex = 38;
            // 
            // ddlCategory
            // 
            ddlCategory.FormattingEnabled = true;
            ddlCategory.Location = new Point(181, 210);
            ddlCategory.Margin = new Padding(2);
            ddlCategory.Name = "ddlCategory";
            ddlCategory.Size = new Size(232, 23);
            ddlCategory.TabIndex = 55;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(57, 215);
            lblCategory.Margin = new Padding(2, 0, 2, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(58, 15);
            lblCategory.TabIndex = 54;
            lblCategory.Text = "Category:";
            // 
            // AddEquipment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 442);
            Controls.Add(ddlCategory);
            Controls.Add(lblCategory);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(ddlCondition);
            Controls.Add(ddlStatus);
            Controls.Add(txtBoxPrice);
            Controls.Add(txtDescription);
            Controls.Add(txtBoxName);
            Controls.Add(txtBoxEquipID);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(lblEquipID);
            Controls.Add(label1);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "AddEquipment";
            Text = "AddEquipment";
            Load += AddEquipment_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnCancel;
        private Button btnSave;
        private ComboBox ddlCondition;
        private ComboBox ddlStatus;
        private TextBox txtBoxPrice;
        private TextBox txtDescription;
        private TextBox txtBoxName;
        private TextBox txtBoxEquipID;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label lblEquipID;
        private Label label1;
        private Panel panel1;
        private ComboBox ddlCategory;
        private Label lblCategory;
    }
}