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
    public partial class IngredientsForm : Form
    {
        private Ingredient _selectedIngredient = null;
        private bool _isEditing = false;
        private List<Ingredient> _ingredients = new List<Ingredient>();

        public IngredientsForm()
        {
            InitializeComponent();
            ConfigureDataGridView();
            dataGridViewIngredients.Visible = false;
            btnReturn.BringToFront();
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
        }

        private void ConfigureDataGridView()
        {
            dataGridViewIngredients.AutoGenerateColumns = false;
            dataGridViewIngredients.Columns.Clear();
            dataGridViewIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIngredients.MultiSelect = false;

            // Add columns
            dataGridViewIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "colId",
                ReadOnly = true,
                Visible = false
            });
            dataGridViewIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
                Name = "colName",
                ReadOnly = true
            });
            dataGridViewIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = "Type",
                Name = "colType",
                ReadOnly = true
            });
            dataGridViewIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Location",
                HeaderText = "Location",
                Name = "colLocation",
                ReadOnly = true
            });
            dataGridViewIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Color",
                HeaderText = "Color",
                Name = "colColor",
                ReadOnly = true
            });

            dataGridViewIngredients.SelectionChanged += DataGridViewIngredients_SelectionChanged;
            dataGridViewIngredients.DataBindingComplete += DataGridViewIngredients_DataBindingComplete;
        }

        private void DataGridViewIngredients_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_selectedIngredient != null && dataGridViewIngredients.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewIngredients.Rows)
                {
                    if (row.DataBoundItem is Ingredient ingredient && ingredient.Id == _selectedIngredient.Id)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void DataGridViewIngredients_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewIngredients.SelectedRows.Count > 0)
            {
                _selectedIngredient = dataGridViewIngredients.SelectedRows[0].DataBoundItem as Ingredient;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                _selectedIngredient = null;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                MessageBox.Show("Please finish editing the current ingredient before adding a new one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ValidateFields())
            {
                AddIngredient();
            }
        }

        private void AddIngredient()
        {
            try
            {
                LibraryManager.AddIngredient(
                    txtName.Text,
                    txtType.Text,
                    txtLocation.Text,
                    txtColor.Text
                );
                MessageBox.Show("Ingredient added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();

                if (dataGridViewIngredients.Visible)
                {
                    DisplayIngredients();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dataGridViewIngredients.Visible = true;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            DisplayIngredients();
        }

        private void DisplayIngredients()
        {
            try
            {
                _ingredients = LibraryManager.GetAllIngredients();
                dataGridViewIngredients.DataSource = null;
                dataGridViewIngredients.DataSource = _ingredients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading ingredients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedIngredient == null)
            {
                MessageBox.Show("Please select an ingredient to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isEditing = true;
            txtName.Text = _selectedIngredient.Name;
            txtType.Text = _selectedIngredient.Type;
            txtLocation.Text = _selectedIngredient.Location;
            txtColor.Text = _selectedIngredient.Color;

            btnAdd.Enabled = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;

            // Ensure form controls are visible
            txtName.BringToFront();
            txtType.BringToFront();
            txtLocation.BringToFront();
            txtColor.BringToFront();
            label1.BringToFront();
            label2.BringToFront();
            label3.BringToFront();
            label4.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedIngredient == null) return;

            var result = MessageBox.Show($"Are you sure you want to delete {_selectedIngredient.Name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    LibraryManager.DeleteIngredient(_selectedIngredient.Id);
                    MessageBox.Show("Ingredient deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayIngredients();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting ingredient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedIngredient == null) return;

            if (ValidateFields())
            {
                try
                {
                    LibraryManager.UpdateIngredient(
                        _selectedIngredient.Id,
                        txtName.Text,
                        txtType.Text,
                        txtLocation.Text,
                        txtColor.Text
                    );
                    MessageBox.Show("Ingredient updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    DisplayIngredients();
                    EndEditing();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtType.Text) ||
                string.IsNullOrWhiteSpace(txtLocation.Text) ||
                string.IsNullOrWhiteSpace(txtColor.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtType.Clear();
            txtLocation.Clear();
            txtColor.Clear();
        }

        private void EndEditing()
        {
            _isEditing = false;
            _selectedIngredient = null;
            btnAdd.Enabled = true;
            btnSave.Visible = false;
            ClearForm();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            dataGridViewIngredients.Visible = false;
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
    }
}