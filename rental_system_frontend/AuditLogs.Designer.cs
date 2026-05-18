namespace rental_system_frontend
{
    partial class AuditLogs
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
            dgvLogs = new DataGridView();
            panelTop = new Panel();
            ddlActionType = new ComboBox();
            btnRefresh = new Button();
            ddlSource = new ComboBox();
            btnFilter = new Button();
            lblSource = new Label();
            lblActionType = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // dgvLogs
            // 
            dgvLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLogs.Dock = DockStyle.Fill;
            dgvLogs.Location = new Point(0, 48);
            dgvLogs.Margin = new Padding(2);
            dgvLogs.Name = "dgvLogs";
            dgvLogs.RowHeadersWidth = 62;
            dgvLogs.RowTemplate.Height = 33;
            dgvLogs.Size = new Size(953, 402);
            dgvLogs.TabIndex = 20;
            dgvLogs.CellContentClick += dgvLogs_CellContentClick;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(4, 9, 56);
            panelTop.Controls.Add(ddlActionType);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(ddlSource);
            panelTop.Controls.Add(btnFilter);
            panelTop.Controls.Add(lblSource);
            panelTop.Controls.Add(lblActionType);
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(lblSearch);
            panelTop.Cursor = Cursors.Hand;
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(2);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(953, 48);
            panelTop.TabIndex = 18;
            // 
            // ddlActionType
            // 
            ddlActionType.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ddlActionType.FormattingEnabled = true;
            ddlActionType.Items.AddRange(new object[] { "" });
            ddlActionType.Location = new Point(124, 13);
            ddlActionType.Margin = new Padding(2);
            ddlActionType.Name = "ddlActionType";
            ddlActionType.Size = new Size(133, 24);
            ddlActionType.TabIndex = 9;
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
            // ddlSource
            // 
            ddlSource.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ddlSource.FormattingEnabled = true;
            ddlSource.Items.AddRange(new object[] { "" });
            ddlSource.Location = new Point(351, 13);
            ddlSource.Margin = new Padding(2);
            ddlSource.Name = "ddlSource";
            ddlSource.Size = new Size(112, 24);
            ddlSource.TabIndex = 6;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(181, 245, 243);
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.FlatStyle = FlatStyle.Popup;
            btnFilter.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnFilter.ForeColor = Color.FromArgb(0, 9, 103);
            btnFilter.Location = new Point(724, 9);
            btnFilter.Margin = new Padding(2);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(96, 27);
            btnFilter.TabIndex = 7;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // lblSource
            // 
            lblSource.AutoSize = true;
            lblSource.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSource.ForeColor = Color.White;
            lblSource.Location = new Point(274, 15);
            lblSource.Margin = new Padding(2, 0, 2, 0);
            lblSource.Name = "lblSource";
            lblSource.Size = new Size(73, 21);
            lblSource.TabIndex = 5;
            lblSource.Text = "Source:";
            // 
            // lblActionType
            // 
            lblActionType.AutoSize = true;
            lblActionType.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblActionType.ForeColor = Color.White;
            lblActionType.Location = new Point(11, 14);
            lblActionType.Margin = new Padding(2, 0, 2, 0);
            lblActionType.Name = "lblActionType";
            lblActionType.Size = new Size(109, 21);
            lblActionType.TabIndex = 3;
            lblActionType.Text = "Action Type";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(555, 16);
            txtSearch.Margin = new Padding(2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(150, 21);
            txtSearch.TabIndex = 2;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSearch.ForeColor = Color.White;
            lblSearch.Location = new Point(478, 15);
            lblSearch.Margin = new Padding(2, 0, 2, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(73, 21);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search:";
            // 
            // AuditLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 450);
            Controls.Add(dgvLogs);
            Controls.Add(panelTop);
            Margin = new Padding(2);
            Name = "AuditLogs";
            Text = "AuditLogs";
            Load += AuditLogs_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panelTop;
        private Button btnRefresh;
        private ComboBox comboBox2;
        private Button btnFilter;
        private Label lblSource;
        private Label lblTimeStamp;
        private Label lblUserID;
        private Button btnDelete;
        private Panel panel1;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private DataGridView dgvLogs;
        private ComboBox ddlActionType;
        private ComboBox ddlSource;
        private Label lblActionType;
        private TextBox txtSearch;
        private Label lblSearch;
    }
}