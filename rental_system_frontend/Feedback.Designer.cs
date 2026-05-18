namespace rental_system_frontend
{
    partial class Feedback
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
            dgvFeedback = new DataGridView();
            btnRefresh = new Button();
            btnFilter = new Button();
            lblEquipmentName = new Label();
            btnVisible = new Button();
            panelTop = new Panel();
            ddlName = new ComboBox();
            ddlRatings = new ComboBox();
            lblRating = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvFeedback).BeginInit();
            panelTop.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvFeedback
            // 
            dgvFeedback.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFeedback.Dock = DockStyle.Fill;
            dgvFeedback.Location = new Point(0, 50);
            dgvFeedback.Margin = new Padding(2);
            dgvFeedback.Name = "dgvFeedback";
            dgvFeedback.RowHeadersWidth = 62;
            dgvFeedback.RowTemplate.Height = 33;
            dgvFeedback.Size = new Size(953, 355);
            dgvFeedback.TabIndex = 17;
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
            // lblEquipmentName
            // 
            lblEquipmentName.AutoSize = true;
            lblEquipmentName.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblEquipmentName.ForeColor = Color.White;
            lblEquipmentName.Location = new Point(8, 14);
            lblEquipmentName.Margin = new Padding(2, 0, 2, 0);
            lblEquipmentName.Name = "lblEquipmentName";
            lblEquipmentName.Size = new Size(145, 21);
            lblEquipmentName.TabIndex = 1;
            lblEquipmentName.Text = "Equipment Name:";
            // 
            // btnVisible
            // 
            btnVisible.BackColor = Color.FromArgb(255, 91, 77);
            btnVisible.Cursor = Cursors.Hand;
            btnVisible.FlatStyle = FlatStyle.Popup;
            btnVisible.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnVisible.ForeColor = Color.FromArgb(255, 243, 227);
            btnVisible.Location = new Point(794, 9);
            btnVisible.Margin = new Padding(2);
            btnVisible.Name = "btnVisible";
            btnVisible.Size = new Size(148, 27);
            btnVisible.TabIndex = 2;
            btnVisible.Text = "Show/Hide";
            btnVisible.UseVisualStyleBackColor = false;
            btnVisible.Click += btnVisible_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(4, 9, 56);
            panelTop.Controls.Add(ddlName);
            panelTop.Controls.Add(ddlRatings);
            panelTop.Controls.Add(lblRating);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(btnFilter);
            panelTop.Controls.Add(lblEquipmentName);
            panelTop.Cursor = Cursors.Hand;
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(2);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(953, 50);
            panelTop.TabIndex = 15;
            // 
            // ddlName
            // 
            ddlName.FormattingEnabled = true;
            ddlName.Location = new Point(158, 14);
            ddlName.Name = "ddlName";
            ddlName.Size = new Size(207, 23);
            ddlName.TabIndex = 12;
            // 
            // ddlRatings
            // 
            ddlRatings.FormattingEnabled = true;
            ddlRatings.Location = new Point(538, 12);
            ddlRatings.Name = "ddlRatings";
            ddlRatings.Size = new Size(121, 23);
            ddlRatings.TabIndex = 11;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblRating.ForeColor = Color.White;
            lblRating.Location = new Point(370, 12);
            lblRating.Margin = new Padding(2, 0, 2, 0);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(163, 21);
            lblRating.TabIndex = 10;
            lblRating.Text = "Feedback Ratings:";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnVisible);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 405);
            panel1.Name = "panel1";
            panel1.Size = new Size(953, 45);
            panel1.TabIndex = 16;
            // 
            // Feedback
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 450);
            Controls.Add(dgvFeedback);
            Controls.Add(panelTop);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "Feedback";
            Text = "Feedback";
            Load += Feedback_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFeedback).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvFeedback;
        private Button btnRefresh;
        private ComboBox comboBox2;
        private Button btnFilter;
        private Label lblCategory;
        private ComboBox ddlRatings;
        private Label lblEquipmentName;
        private Button btnVisible;
        private Panel panelTop;
        private Panel panel1;
        private Label lblRating;
        private ComboBox ddlName;
    }
}