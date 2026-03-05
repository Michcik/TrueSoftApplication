namespace ContactManager.Controls
{
    partial class ContactCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picAvatar   = new System.Windows.Forms.PictureBox();
            this.lblName     = new System.Windows.Forms.Label();
            this.lblEmail    = new System.Windows.Forms.Label();
            this.lblPhone    = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnEdit     = new System.Windows.Forms.Button();
            this.btnDelete   = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();

            // picAvatar
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.picAvatar.Location    = new System.Drawing.Point(8, 8);
            this.picAvatar.Name        = "picAvatar";
            this.picAvatar.Size        = new System.Drawing.Size(56, 56);
            this.picAvatar.SizeMode    = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabStop     = false;

            // lblName
            this.lblName.AutoSize  = false;
            this.lblName.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.Location  = new System.Drawing.Point(72, 8);
            this.lblName.Size      = new System.Drawing.Size(280, 22);
            this.lblName.Name      = "lblName";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblEmail
            this.lblEmail.AutoSize  = false;
            this.lblEmail.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblEmail.Location  = new System.Drawing.Point(72, 30);
            this.lblEmail.Size      = new System.Drawing.Size(280, 18);
            this.lblEmail.Name      = "lblEmail";

            // lblPhone
            this.lblPhone.AutoSize  = false;
            this.lblPhone.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblPhone.Location  = new System.Drawing.Point(72, 48);
            this.lblPhone.Size      = new System.Drawing.Size(180, 18);
            this.lblPhone.Name      = "lblPhone";

            // lblCategory
            this.lblCategory.AutoSize  = false;
            this.lblCategory.Font      = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.White;
            this.lblCategory.Location  = new System.Drawing.Point(260, 44);
            this.lblCategory.Size      = new System.Drawing.Size(70, 18);
            this.lblCategory.Name      = "lblCategory";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnEdit
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.btnEdit.Location  = new System.Drawing.Point(340, 10);
            this.btnEdit.Name      = "btnEdit";
            this.btnEdit.Size      = new System.Drawing.Size(60, 26);
            this.btnEdit.Text      = "Edit";
            this.btnEdit.Click    += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(200, 70, 70);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.btnDelete.Location  = new System.Drawing.Point(340, 40);
            this.btnDelete.Name      = "btnDelete";
            this.btnDelete.Size      = new System.Drawing.Size(60, 26);
            this.btnDelete.Text      = "Delete";
            this.btnDelete.Click    += new System.EventHandler(this.btnDelete_Click);

            // ContactCard
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor     = System.Drawing.Color.White;
            this.BorderStyle   = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Name   = "ContactCard";
            this.Size   = new System.Drawing.Size(410, 74);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}
