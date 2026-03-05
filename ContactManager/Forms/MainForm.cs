using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ContactManager.Controls;
using ContactManager.Data;
using ContactManager.Models;

namespace ContactManager.Forms
{
    public partial class MainForm : Form
    {
        private readonly ContactRepository _repo = new ContactRepository();

        public MainForm()
        {
            InitializeComponent();
            LoadContacts();
        }

        private void LoadContacts()
        {
            string filter = txtSearch.Text.Trim();
            string sortBy = cmbSort.SelectedItem?.ToString() ?? "LastName";

            List<Contact> contacts;
            try
            {
                contacts = _repo.GetAll(filter, sortBy);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading contacts:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Clear existing cards
            panelList.Controls.Clear();

            if (contacts.Count == 0)
            {
                var lbl = new Label
                {
                    Text      = "No contacts found.",
                    AutoSize  = false,
                    Dock      = DockStyle.Top,
                    Height    = 40,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    ForeColor = System.Drawing.Color.Gray,
                    Font      = new System.Drawing.Font("Segoe UI", 10F)
                };
                panelList.Controls.Add(lbl);
                return;
            }

            // Add cards in reverse so first item appears at top in FlowLayout
            for (int i = contacts.Count - 1; i >= 0; i--)
            {
                var card = new ContactCard { Contact = contacts[i] };
                card.EditRequested   += OnEditRequested;
                card.DeleteRequested += OnDeleteRequested;
                panelList.Controls.Add(card);
            }
        }

        private void OnEditRequested(object sender, int contactId)
        {
            using (var form = new AddEditContactForm(_repo, contactId))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadContacts();
            }
        }

        private void OnDeleteRequested(object sender, int contactId)
        {
            var result = MessageBox.Show(
                "Are you sure you want to delete this contact?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                _repo.Delete(contactId);
                LoadContacts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting contact:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditContactForm(_repo))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadContacts();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadContacts();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadContacts();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter   = "CSV Files|*.csv";
                dlg.FileName = "contacts.csv";
                dlg.Title    = "Export Contacts";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    _repo.ExportToCsv(dlg.FileName,
                        txtSearch.Text.Trim(),
                        cmbSort.SelectedItem?.ToString() ?? "LastName");
                    MessageBox.Show("Contacts exported successfully.", "Export",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export failed:\n{ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
