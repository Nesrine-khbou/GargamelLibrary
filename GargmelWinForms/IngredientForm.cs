using System;
using System.Windows.Forms;
using BLGargamelLibrary;

namespace GargmelWinForms
{
    public partial class Form2 : Form
    {
        private Ingredient selectedIngredient = null;

        public Form2()
        {
            InitializeComponent();
            LoadIngredients();
            SetupDataGridView();
            SetupEventHandlers();
        }

        private void SetupDataGridView()
        {
            dgvIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIngredients.MultiSelect = false;
            dgvIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetupEventHandlers()
        {
            dgvIngredients.CellClick += DgvIngredients_CellClick;
            btnAddIngredient.Click += BtnAddIngredient_Click;
            btnDeleteIngredient.Click += BtnDeleteIngredient_Click;
            btnClear.Click += BtnClear_Click;
            button1.Click += Button1_Click;
        }

        private void DgvIngredients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedIngredient = dgvIngredients.Rows[e.RowIndex].DataBoundItem as Ingredient;
                if (selectedIngredient != null)
                {
                    txtName.Text = selectedIngredient.Name;
                    txtType.Text = selectedIngredient.Type;
                    txtLocation.Text = selectedIngredient.Location;
                    txtColor.Text = selectedIngredient.Color;
                    btnAddIngredient.Text = "Update";
                }
            }
        }

        private void BtnAddIngredient_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (selectedIngredient == null)
                {
                    // Add new ingredient
                    LibraryManager.AddIngredient(txtName.Text, txtType.Text, txtLocation.Text, txtColor.Text);
                    MessageBox.Show("Ingredient added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Update existing ingredient
                    LibraryManager.UpdateIngredient(selectedIngredient.Id, txtName.Text, txtType.Text, txtLocation.Text, txtColor.Text);
                    MessageBox.Show("Ingredient updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadIngredients();
                ClearFields();
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtType.Text) ||
                string.IsNullOrWhiteSpace(txtLocation.Text) || string.IsNullOrWhiteSpace(txtColor.Text))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BtnDeleteIngredient_Click(object sender, EventArgs e)
        {
            if (selectedIngredient == null)
            {
                MessageBox.Show("Please select an ingredient to delete.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete {selectedIngredient.Name}?",
                                       "Confirm Delete",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LibraryManager.DeleteIngredient(selectedIngredient.Id);
                MessageBox.Show("Ingredient deleted successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadIngredients();
                ClearFields();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void LoadIngredients()
        {
            dgvIngredients.DataSource = null;
            dgvIngredients.DataSource = LibraryManager.GetAllIngredients();
            dgvIngredients.Columns["Id"].Visible = false;
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtType.Text = "";
            txtLocation.Text = "";
            txtColor.Text = "";
            selectedIngredient = null;
            btnAddIngredient.Text = "Add";
            dgvIngredients.ClearSelection();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Close();
        }
    }
}