namespace rental_system_frontend
{
    partial class Equipments
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
            dgvEquipments = new DataGridView();
            panelTop = new Panel();
            btnRefresh = new Button();
            ddlCategory = new ComboBox();
            btnFilter = new Button();
            lblCategory = new Label();
            ddlStatus = new ComboBox();
            lblStatus = new Label();
            txtName = new TextBox();
            lblName = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvEquipments).BeginInit();
            panelTop.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEquipments
            // 
            dgvEquipments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipments.Dock = DockStyle.Fill;
            dgvEquipments.Location = new Point(0, 48);
            dgvEquipments.Margin = new Padding(2);
            dgvEquipments.Name = "dgvEquipments";
            dgvEquipments.RowHeadersWidth = 62;
            dgvEquipments.RowTemplate.Height = 33;
            dgvEquipments.Size = new Size(953, 357);
            dgvEquipments.TabIndex = 17;
            dgvEquipments.CellContentClick += dgvEquipments_CellContentClick;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(4, 9, 56);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(ddlCategory);
            panelTop.Controls.Add(btnFilter);
            panelTop.Controls.Add(lblCategory);
            panelTop.Controls.Add(ddlStatus);
            panelTop.Controls.Add(lblStatus);
            panelTop.Controls.Add(txtName);
            panelTop.Controls.Add(lblName);
            panelTop.Cursor = Cursors.Hand;
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(2);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(953, 48);
            panelTop.TabIndex = 15;
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
            // ddlCategory
            // 
            ddlCategory.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ddlCategory.FormattingEnabled = true;
            ddlCategory.Items.AddRange(new object[] { "Powerr Tools", "Cameras", "Construction Equipments", "Event Supplies" });
            ddlCategory.Location = new Point(293, 14);
            ddlCategory.Margin = new Padding(2);
            ddlCategory.Name = "ddlCategory";
            ddlCategory.Size = new Size(149, 24);
            ddlCategory.TabIndex = 6;
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
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCategory.ForeColor = Color.White;
            lblCategory.Location = new Point(198, 13);
            lblCategory.Margin = new Padding(2, 0, 2, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(91, 21);
            lblCategory.TabIndex = 5;
            lblCategory.Text = "Category:";
            // 
            // ddlStatus
            // 
            ddlStatus.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ddlStatus.FormattingEnabled = true;
            ddlStatus.Items.AddRange(new object[] { "Available", "Unavailable", "Under Maintenance" });
            ddlStatus.Location = new Point(523, 14);
            ddlStatus.Margin = new Padding(2);
            ddlStatus.Name = "ddlStatus";
            ddlStatus.Size = new Size(167, 24);
            ddlStatus.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(446, 13);
            lblStatus.Margin = new Padding(2, 0, 2, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(73, 21);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status:";
            // 
            // txtName
            // 
            txtName.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(61, 16);
            txtName.Margin = new Padding(2);
            txtName.Name = "txtName";
            txtName.Size = new Size(133, 21);
            txtName.TabIndex = 2;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(3, 13);
            lblName.Margin = new Padding(2, 0, 2, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(55, 21);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 9, 103);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Popup;
            btnAdd.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = Color.FromArgb(255, 243, 227);
            btnAdd.Location = new Point(11, 9);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(127, 27);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(0, 9, 103);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.FromArgb(255, 243, 227);
            btnUpdate.Location = new Point(142, 9);
            btnUpdate.Margin = new Padding(2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(147, 27);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 91, 77);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.FromArgb(255, 243, 227);
            btnDelete.Location = new Point(794, 9);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(148, 27);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnDelete);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 405);
            panel1.Name = "panel1";
            panel1.Size = new Size(953, 45);
            panel1.TabIndex = 16;
            // 
            // Equipments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 450);
            Controls.Add(dgvEquipments);
            Controls.Add(panelTop);
            Controls.Add(panel1);
            Name = "Equipments";
            Text = "Equipments";
            Load += Equipments_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEquipments).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEquipments;
        private Panel panelTop;
        private Button btnRefresh;
        private ComboBox ddlCategory;
        private Button btnFilter;
        private Label lblCategory;
        private ComboBox ddlStatus;
        private Label lblStatus;
        private TextBox txtName;
        private Label lblName;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Panel panel1;
    }
}