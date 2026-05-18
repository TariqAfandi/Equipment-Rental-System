namespace rental_system_frontend
{
    partial class UpdateCategory
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
            txtBoxCategoryName = new TextBox();
            lblCategoryName = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            txtBoxCategoryID = new TextBox();
            lblCategoryID = new Label();
            panelTop = new Panel();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(7, 8, 20);
            lblTitle.Font = new Font("Cascadia Code SemiBold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(168, 9);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(367, 52);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Update Category";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtBoxCategoryName
            // 
            txtBoxCategoryName.Location = new Point(251, 212);
            txtBoxCategoryName.Name = "txtBoxCategoryName";
            txtBoxCategoryName.Size = new Size(330, 31);
            txtBoxCategoryName.TabIndex = 101;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(74, 215);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(140, 25);
            lblCategoryName.TabIndex = 100;
            lblCategoryName.Text = "Category Name:";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 91, 77);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.FromArgb(255, 243, 227);
            btnCancel.Location = new Point(400, 303);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(181, 45);
            btnCancel.TabIndex = 99;
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
            btnSave.Location = new Point(74, 303);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(181, 45);
            btnSave.TabIndex = 98;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // txtBoxCategoryID
            // 
            txtBoxCategoryID.Location = new Point(251, 148);
            txtBoxCategoryID.Name = "txtBoxCategoryID";
            txtBoxCategoryID.Size = new Size(330, 31);
            txtBoxCategoryID.TabIndex = 97;
            // 
            // lblCategoryID
            // 
            lblCategoryID.AutoSize = true;
            lblCategoryID.Location = new Point(74, 151);
            lblCategoryID.Name = "lblCategoryID";
            lblCategoryID.Size = new Size(111, 25);
            lblCategoryID.TabIndex = 96;
            lblCategoryID.Text = "Category ID:";
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(4, 9, 56);
            panelTop.Controls.Add(lblTitle);
            panelTop.Cursor = Cursors.Hand;
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(643, 80);
            panelTop.TabIndex = 95;
            // 
            // UpdateCategory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 367);
            Controls.Add(txtBoxCategoryName);
            Controls.Add(lblCategoryName);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtBoxCategoryID);
            Controls.Add(lblCategoryID);
            Controls.Add(panelTop);
            Name = "UpdateCategory";
            Text = "UpdateCategory";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtBoxCategoryName;
        private Label lblCategoryName;
        private Button btnCancel;
        private Button btnSave;
        private TextBox txtBoxCategoryID;
        private Label lblCategoryID;
        private Panel panelTop;
    }
}