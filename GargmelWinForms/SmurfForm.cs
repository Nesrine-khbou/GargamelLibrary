using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLGargamelLibrary;
using DALGargameLibrary;

namespace GargmelWinForms
{
    public partial class SmurfForm : Form
    {
        private Smurf _selectedSmurf = null;
        private bool _isEditing = false;
        private List<Smurf> _smurfs = new List<Smurf>();

        public SmurfForm()
        {
            InitializeComponent();
            comboBoxDescription.DataSource = Enum.GetValues(typeof(SmurfDescription));
            ConfigureDataGridView();
            dataGridViewSmurfs.Visible = false;
            btnReturn.BringToFront();
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
        }

        private void ConfigureDataGridView()
        {
            dataGridViewSmurfs.AutoGenerateColumns = false;
            dataGridViewSmurfs.Columns.Clear();
            dataGridViewSmurfs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSmurfs.MultiSelect = false;

            // Add columns
            dataGridViewSmurfs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "colId",
                ReadOnly = true
            });
            dataGridViewSmurfs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
                Name = "colName",
                ReadOnly = true
            });
            dataGridViewSmurfs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Height",
                HeaderText = "Height",
                Name = "colHeight",
                ReadOnly = true
            });
            dataGridViewSmurfs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Description",
                HeaderText = "Description",
                Name = "colDescription",
                ReadOnly = true
            });

            dataGridViewSmurfs.SelectionChanged += DataGridViewSmurfs_SelectionChanged;
            dataGridViewSmurfs.DataBindingComplete += DataGridViewSmurfs_DataBindingComplete;
        }

        private void DataGridViewSmurfs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_selectedSmurf != null && dataGridViewSmurfs.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewSmurfs.Rows)
                {
                    if (row.DataBoundItem is Smurf smurf && smurf.Id == _selectedSmurf.Id)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void DataGridViewSmurfs_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSmurfs.SelectedRows.Count > 0)
            {
                _selectedSmurf = dataGridViewSmurfs.SelectedRows[0].DataBoundItem as Smurf;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                _selectedSmurf = null;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                MessageBox.Show("Please finish editing the current smurf before adding a new one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AddSmurf();
        }

        private void AddSmurf()
        {
            string name = txtName.Text;
            double height = (double)numericHeight.Value;
            SmurfDescription description = (SmurfDescription)comboBoxDescription.SelectedItem;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a valid name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                LibraryManager.AddSmurf(name, height, description);
                MessageBox.Show("Smurf added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();

                if (dataGridViewSmurfs.Visible)
                {
                    DisplaySmurfs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dataGridViewSmurfs.Visible = true;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            DisplaySmurfs();
        }

        private void DisplaySmurfs()
        {
            try
            {
                _smurfs = LibraryManager.GetAllSmurfs();
                dataGridViewSmurfs.DataSource = null;
                dataGridViewSmurfs.DataSource = _smurfs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading smurfs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedSmurf == null)
            {
                MessageBox.Show("Please select a smurf to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isEditing = true;
            txtName.Text = _selectedSmurf.Name;
            numericHeight.Value = (decimal)_selectedSmurf.Height;
            comboBoxDescription.SelectedItem = _selectedSmurf.Description;

            btnAdd.Enabled = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            // Ensure form controls are visible
            txtName.BringToFront();
            numericHeight.BringToFront();
            comboBoxDescription.BringToFront();
            label1.BringToFront();
            label2.BringToFront();
            label3.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedSmurf == null) return;

            var result = MessageBox.Show($"Are you sure you want to delete {_selectedSmurf.Name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    LibraryManager.DeleteSmurf(_selectedSmurf.Id);
                    MessageBox.Show("Smurf deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplaySmurfs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting smurf: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedSmurf == null) return;

            string name = txtName.Text;
            double height = (double)numericHeight.Value;
            SmurfDescription description = (SmurfDescription)comboBoxDescription.SelectedItem;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a valid name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                LibraryManager.UpdateSmurf(_selectedSmurf.Id, name, height, description);
                MessageBox.Show("Smurf updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                DisplaySmurfs();
                EndEditing();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            numericHeight.Value = 0;
            comboBoxDescription.SelectedIndex = 0;
        }

        private void EndEditing()
        {
            _isEditing = false;
            _selectedSmurf = null;
            btnAdd.Enabled = true;
            btnSave.Visible = false;
            ClearForm();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            dataGridViewSmurfs.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            EndEditing();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Close();
        }

        // Empty event handlers
        private void txtName_TextChanged(object sender, EventArgs e) { }
        private void comboBoxDescription_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dataGridViewSmurfs_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void numericHeight_ValueChanged(object sender, EventArgs e) { }
    }
}