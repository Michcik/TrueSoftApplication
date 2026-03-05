namespace ContactManager.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop      = new System.Windows.Forms.Panel();
            this.lblTitle    = new System.Windows.Forms.Label();
            this.txtSearch   = new System.Windows.Forms.TextBox();
            this.lblSearch   = new System.Windows.Forms.Label();
            this.lblSort     = new System.Windows.Forms.Label();
            this.cmbSort     = new System.Windows.Forms.ComboBox();
            this.btnAdd      = new System.Windows.Forms.Button();
            this.btnExport   = new System.Windows.Forms.Button();
            this.panelList   = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            this.pnlTop.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height    = 110;
            this.pnlTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblTitle, lblSearch, txtSearch, lblSort, cmbSort, btnAdd, btnExport
            });

            // lblTitle
            this.lblTitle.Text      = "Contact Manager";
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(12, 8);
            this.lblTitle.Size      = new System.Drawing.Size(260, 32);
            this.lblTitle.AutoSize  = false;

            // lblSearch
            this.lblSearch.Text      = "Search:";
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearch.Location  = new System.Drawing.Point(12, 52);
            this.lblSearch.Size      = new System.Drawing.Size(54, 22);
            this.lblSearch.AutoSize  = false;

            // txtSearch
            this.txtSearch.Location     = new System.Drawing.Point(68, 50);
            this.txtSearch.Size         = new System.Drawing.Size(200, 26);
            this.txtSearch.Font         = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // lblSort
            this.lblSort.Text      = "Sort by:";
            this.lblSort.ForeColor = System.Drawing.Color.White;
            this.lblSort.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSort.Location  = new System.Drawing.Point(278, 52);
            this.lblSort.Size      = new System.Drawing.Size(54, 22);
            this.lblSort.AutoSize  = false;

            // cmbSort
            this.cmbSort.Location          = new System.Drawing.Point(334, 50);
            this.cmbSort.Size              = new System.Drawing.Size(110, 26);
            this.cmbSort.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Font              = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSort.Items.AddRange(new object[] { "LastName", "FirstName", "Category" });
            this.cmbSort.SelectedIndex     = 0;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);

            // btnAdd
            this.btnAdd.Text      = "+ Add Contact";
            this.btnAdd.Location  = new System.Drawing.Point(460, 45);
            this.btnAdd.Size      = new System.Drawing.Size(110, 32);
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(60, 179, 113);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Click    += new System.EventHandler(this.btnAdd_Click);

            // btnExport
            this.btnExport.Text      = "Export CSV";
            this.btnExport.Location  = new System.Drawing.Point(580, 45);
            this.btnExport.Size      = new System.Drawing.Size(90, 32);
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(100, 100, 140);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.Click    += new System.EventHandler(this.btnExport_Click);

            // panelList (scrollable card list)
            this.panelList.Dock          = System.Windows.Forms.DockStyle.Fill;
            this.panelList.AutoScroll    = true;
            this.panelList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelList.WrapContents  = false;
            this.panelList.Padding       = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panelList.BackColor     = System.Drawing.Color.FromArgb(245, 245, 250);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(700, 520);
            this.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize         = new System.Drawing.Size(700, 480);
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Contact Manager";
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.pnlTop);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel           pnlTop;
        private System.Windows.Forms.Label           lblTitle;
        private System.Windows.Forms.Label           lblSearch;
        private System.Windows.Forms.TextBox         txtSearch;
        private System.Windows.Forms.Label           lblSort;
        private System.Windows.Forms.ComboBox        cmbSort;
        private System.Windows.Forms.Button          btnAdd;
        private System.Windows.Forms.Button          btnExport;
        private System.Windows.Forms.FlowLayoutPanel panelList;
    }
}
