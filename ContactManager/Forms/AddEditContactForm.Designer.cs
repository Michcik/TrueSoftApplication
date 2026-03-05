namespace ContactManager.Forms
{
    partial class AddEditContactForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components   = new System.ComponentModel.Container();
            this.errProvider  = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName  = new System.Windows.Forms.Label();
            this.txtLastName  = new System.Windows.Forms.TextBox();
            this.lblEmail     = new System.Windows.Forms.Label();
            this.txtEmail     = new System.Windows.Forms.TextBox();
            this.lblPhone     = new System.Windows.Forms.Label();
            this.txtPhone     = new System.Windows.Forms.TextBox();
            this.lblCategory  = new System.Windows.Forms.Label();
            this.cmbCategory  = new System.Windows.Forms.ComboBox();
            this.lblAvatar    = new System.Windows.Forms.Label();
            this.picAvatar    = new System.Windows.Forms.PictureBox();
            this.btnChooseAvatar = new System.Windows.Forms.Button();
            this.btnSave      = new System.Windows.Forms.Button();
            this.btnCancel    = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();

            int lx = 20, tx = 130, w = 220, lh = 22, th = 26, gap = 36;
            int row = 20;

            // First Name
            this.lblFirstName.Text     = "First Name *";
            this.lblFirstName.Location = new System.Drawing.Point(lx, row + 3);
            this.lblFirstName.Size     = new System.Drawing.Size(100, lh);
            this.txtFirstName.Location = new System.Drawing.Point(tx, row);
            this.txtFirstName.Size     = new System.Drawing.Size(w, th);
            row += gap;

            // Last Name
            this.lblLastName.Text     = "Last Name *";
            this.lblLastName.Location = new System.Drawing.Point(lx, row + 3);
            this.lblLastName.Size     = new System.Drawing.Size(100, lh);
            this.txtLastName.Location = new System.Drawing.Point(tx, row);
            this.txtLastName.Size     = new System.Drawing.Size(w, th);
            row += gap;

            // Email
            this.lblEmail.Text     = "Email *";
            this.lblEmail.Location = new System.Drawing.Point(lx, row + 3);
            this.lblEmail.Size     = new System.Drawing.Size(100, lh);
            this.txtEmail.Location = new System.Drawing.Point(tx, row);
            this.txtEmail.Size     = new System.Drawing.Size(w, th);
            row += gap;

            // Phone
            this.lblPhone.Text     = "Phone *";
            this.lblPhone.Location = new System.Drawing.Point(lx, row + 3);
            this.lblPhone.Size     = new System.Drawing.Size(100, lh);
            this.txtPhone.Location = new System.Drawing.Point(tx, row);
            this.txtPhone.Size     = new System.Drawing.Size(w, th);
            row += gap;

            // Category
            this.lblCategory.Text     = "Category";
            this.lblCategory.Location = new System.Drawing.Point(lx, row + 3);
            this.lblCategory.Size     = new System.Drawing.Size(100, lh);
            this.cmbCategory.Location = new System.Drawing.Point(tx, row);
            this.cmbCategory.Size     = new System.Drawing.Size(w, th);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            row += gap;

            // Avatar
            this.lblAvatar.Text     = "Avatar";
            this.lblAvatar.Location = new System.Drawing.Point(lx, row + 3);
            this.lblAvatar.Size     = new System.Drawing.Size(100, lh);

            this.picAvatar.Location  = new System.Drawing.Point(tx, row);
            this.picAvatar.Size      = new System.Drawing.Size(60, 60);
            this.picAvatar.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.BackColor = System.Drawing.Color.FromArgb(230, 230, 240);

            this.btnChooseAvatar.Text     = "Browse…";
            this.btnChooseAvatar.Location = new System.Drawing.Point(tx + 68, row + 17);
            this.btnChooseAvatar.Size     = new System.Drawing.Size(80, 26);
            this.btnChooseAvatar.Click   += new System.EventHandler(this.btnChooseAvatar_Click);
            row += 70;

            // Buttons
            this.btnSave.Text      = "Save";
            this.btnSave.Location  = new System.Drawing.Point(tx, row);
            this.btnSave.Size      = new System.Drawing.Size(100, 30);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Click    += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text      = "Cancel";
            this.btnCancel.Location  = new System.Drawing.Point(tx + 110, row);
            this.btnCancel.Size      = new System.Drawing.Size(100, 30);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click    += new System.EventHandler(this.btnCancel_Click);

            // ErrorProvider
            this.errProvider.ContainerControl = this;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize    = new System.Drawing.Size(390, row + 60);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox   = false;
            this.MinimizeBox   = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblFirstName, txtFirstName,
                lblLastName,  txtLastName,
                lblEmail,     txtEmail,
                lblPhone,     txtPhone,
                lblCategory,  cmbCategory,
                lblAvatar,    picAvatar, btnChooseAvatar,
                btnSave, btnCancel
            });
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ErrorProvider  errProvider;
        private System.Windows.Forms.Label          lblFirstName;
        private System.Windows.Forms.TextBox        txtFirstName;
        private System.Windows.Forms.Label          lblLastName;
        private System.Windows.Forms.TextBox        txtLastName;
        private System.Windows.Forms.Label          lblEmail;
        private System.Windows.Forms.TextBox        txtEmail;
        private System.Windows.Forms.Label          lblPhone;
        private System.Windows.Forms.TextBox        txtPhone;
        private System.Windows.Forms.Label          lblCategory;
        private System.Windows.Forms.ComboBox       cmbCategory;
        private System.Windows.Forms.Label          lblAvatar;
        private System.Windows.Forms.PictureBox     picAvatar;
        private System.Windows.Forms.Button         btnChooseAvatar;
        private System.Windows.Forms.Button         btnSave;
        private System.Windows.Forms.Button         btnCancel;
    }
}
