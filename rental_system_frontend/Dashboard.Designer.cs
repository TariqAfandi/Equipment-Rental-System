namespace rental_system_frontend
{
    partial class Dashboard
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
            lblTotalEquipment = new Label();
            lblTotalCategories = new Label();
            lblTotalPending = new Label();
            lblTotalActiveRentals = new Label();
            lblTotalRequests = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // lblTotalEquipment
            // 
            lblTotalEquipment.AutoSize = true;
            lblTotalEquipment.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalEquipment.Location = new Point(615, 95);
            lblTotalEquipment.Name = "lblTotalEquipment";
            lblTotalEquipment.Size = new Size(65, 28);
            lblTotalEquipment.TabIndex = 0;
            lblTotalEquipment.Text = "label1";
            // 
            // lblTotalCategories
            // 
            lblTotalCategories.AutoSize = true;
            lblTotalCategories.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalCategories.Location = new Point(615, 138);
            lblTotalCategories.Name = "lblTotalCategories";
            lblTotalCategories.Size = new Size(65, 28);
            lblTotalCategories.TabIndex = 1;
            lblTotalCategories.Text = "label1";
            // 
            // lblTotalPending
            // 
            lblTotalPending.AutoSize = true;
            lblTotalPending.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalPending.Location = new Point(615, 186);
            lblTotalPending.Name = "lblTotalPending";
            lblTotalPending.Size = new Size(65, 28);
            lblTotalPending.TabIndex = 2;
            lblTotalPending.Text = "label1";
            // 
            // lblTotalActiveRentals
            // 
            lblTotalActiveRentals.AutoSize = true;
            lblTotalActiveRentals.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalActiveRentals.Location = new Point(615, 226);
            lblTotalActiveRentals.Name = "lblTotalActiveRentals";
            lblTotalActiveRentals.Size = new Size(65, 28);
            lblTotalActiveRentals.TabIndex = 3;
            lblTotalActiveRentals.Text = "label1";
            // 
            // lblTotalRequests
            // 
            lblTotalRequests.AutoSize = true;
            lblTotalRequests.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalRequests.Location = new Point(615, 265);
            lblTotalRequests.Name = "lblTotalRequests";
            lblTotalRequests.Size = new Size(65, 28);
            lblTotalRequests.TabIndex = 4;
            lblTotalRequests.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(190, 95);
            label1.Name = "label1";
            label1.Size = new Size(158, 28);
            label1.TabIndex = 5;
            label1.Text = "Total Equipment:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(190, 138);
            label2.Name = "label2";
            label2.Size = new Size(156, 28);
            label2.TabIndex = 6;
            label2.Text = "Total Categories:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(190, 186);
            label3.Name = "label3";
            label3.Size = new Size(275, 28);
            label3.TabIndex = 7;
            label3.Text = "Total Pending Rental Requests:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(190, 226);
            label4.Name = "label4";
            label4.Size = new Size(184, 28);
            label4.TabIndex = 8;
            label4.Text = "Total Active Rentals:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(190, 265);
            label5.Name = "label5";
            label5.Size = new Size(140, 28);
            label5.TabIndex = 9;
            label5.Text = "Total Requests:";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTotalRequests);
            Controls.Add(lblTotalActiveRentals);
            Controls.Add(lblTotalPending);
            Controls.Add(lblTotalCategories);
            Controls.Add(lblTotalEquipment);
            Margin = new Padding(2);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTotalEquipment;
        private Label lblTotalCategories;
        private Label lblTotalPending;
        private Label lblTotalActiveRentals;
        private Label lblTotalRequests;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}