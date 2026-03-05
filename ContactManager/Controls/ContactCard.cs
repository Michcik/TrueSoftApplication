using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ContactManager.Models;

namespace ContactManager.Controls
{
    public partial class ContactCard : UserControl
    {
        // Custom events
        public event EventHandler<int> EditRequested;
        public event EventHandler<int> DeleteRequested;

        private Contact _contact;

        public ContactCard()
        {
            InitializeComponent();
        }

        public Contact Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                RefreshDisplay();
            }
        }

        private void RefreshDisplay()
        {
            if (_contact == null) return;

            lblName.Text     = _contact.FullName;
            lblEmail.Text    = _contact.Email;
            lblPhone.Text    = _contact.Phone;
            lblCategory.Text = _contact.Category.ToString();

            // Category colour chip
            lblCategory.BackColor = CategoryColor(_contact.Category);

            // Avatar
            if (!string.IsNullOrEmpty(_contact.AvatarPath) && File.Exists(_contact.AvatarPath))
            {
                try { picAvatar.Image = Image.FromFile(_contact.AvatarPath); }
                catch { SetDefaultAvatar(); }
            }
            else
            {
                SetDefaultAvatar();
            }
        }

        private void SetDefaultAvatar()
        {
            picAvatar.Image = null;
            picAvatar.BackColor = Color.FromArgb(180, 180, 200);
        }

        private static Color CategoryColor(ContactCategory cat)
        {
            switch (cat)
            {
                case ContactCategory.Business: return Color.FromArgb(70, 130, 180);   // steel blue
                case ContactCategory.Family:   return Color.FromArgb(60, 179, 113);   // medium sea green
                default:                       return Color.FromArgb(147, 112, 219);  // medium purple
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditRequested?.Invoke(this, _contact?.Id ?? 0);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRequested?.Invoke(this, _contact?.Id ?? 0);
        }
    }
}
