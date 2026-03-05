using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ContactManager.Data;
using ContactManager.Models;

namespace ContactManager.Forms
{
    public partial class AddEditContactForm : Form
    {
        private readonly ContactRepository _repo;
        private readonly int _contactId; // 0 = new
        private string _avatarPath;

        public AddEditContactForm(ContactRepository repo, int contactId = 0)
        {
            _repo      = repo;
            _contactId = contactId;
            InitializeComponent();
            PopulateCategories();

            if (_contactId > 0)
            {
                Text = "Edit Contact";
                LoadContact();
            }
            else
            {
                Text = "Add Contact";
            }
        }

        private void PopulateCategories()
        {
            cmbCategory.Items.Clear();
            foreach (var cat in Enum.GetValues(typeof(ContactCategory)))
                cmbCategory.Items.Add(cat);
            cmbCategory.SelectedIndex = 0;
        }

        private void LoadContact()
        {
            var c = _repo.GetById(_contactId);
            if (c == null) return;

            txtFirstName.Text = c.FirstName;
            txtLastName.Text  = c.LastName;
            txtEmail.Text     = c.Email;
            txtPhone.Text     = c.Phone;
            cmbCategory.SelectedItem = c.Category;
            _avatarPath = c.AvatarPath;
            UpdateAvatarPreview();
        }

        private void UpdateAvatarPreview()
        {
            if (!string.IsNullOrEmpty(_avatarPath) && File.Exists(_avatarPath))
            {
                try { picAvatar.Image = Image.FromFile(_avatarPath); }
                catch { picAvatar.Image = null; }
            }
            else
            {
                picAvatar.Image = null;
            }
        }

        private void btnChooseAvatar_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                dlg.Title  = "Select Avatar Image";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _avatarPath = dlg.FileName;
                    UpdateAvatarPreview();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;

            var contact = new Contact
            {
                Id         = _contactId,
                FirstName  = txtFirstName.Text.Trim(),
                LastName   = txtLastName.Text.Trim(),
                Email      = txtEmail.Text.Trim(),
                Phone      = txtPhone.Text.Trim(),
                Category   = (ContactCategory)cmbCategory.SelectedItem,
                AvatarPath = _avatarPath
            };

            try
            {
                if (_contactId == 0)
                    _repo.Add(contact);
                else
                    _repo.Update(contact);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving contact:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private new bool Validate()
        {
            ClearErrors();
            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errProvider.SetError(txtFirstName, "First name is required.");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errProvider.SetError(txtLastName, "Last name is required.");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errProvider.SetError(txtEmail, "Email is required.");
                valid = false;
            }
            else if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errProvider.SetError(txtEmail, "Enter a valid email address.");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errProvider.SetError(txtPhone, "Phone number is required.");
                valid = false;
            }

            return valid;
        }

        private void ClearErrors()
        {
            errProvider.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
