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
    public partial class ClientForm : Form
    {
        private Client _selectedClient = null;
        private bool _isEditing = false;
        private List<Client> _clients = new List<Client>();

        public ClientForm()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(Speciality));
            comboBox2.DataSource = Enum.GetValues(typeof(LevelOfMagic));
            ConfigureDataGridView();
            dataGridViewClients.Visible = false;
            button3.BringToFront();
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
        }

        private void ConfigureDataGridView()
        {
            dataGridViewClients.AutoGenerateColumns = false;
            dataGridViewClients.Columns.Clear();
            dataGridViewClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClients.MultiSelect = false;

            // Add columns
            dataGridViewClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "colId",
                ReadOnly = true
            });
            dataGridViewClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
                Name = "colName",
                ReadOnly = true
            });
            dataGridViewClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Speciality",
                HeaderText = "Speciality",
                Name = "colSpeciality",
                ReadOnly = true
            });
            dataGridViewClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LevelOfMagic",
                HeaderText = "Level of Magic",
                Name = "colLevelOfMagic",
                ReadOnly = true
            });

            dataGridViewClients.SelectionChanged += DataGridViewClients_SelectionChanged;
            dataGridViewClients.DataBindingComplete += DataGridViewClients_DataBindingComplete;
        }

        private void DataGridViewClients_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_selectedClient != null && dataGridViewClients.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewClients.Rows)
                {
                    if (row.DataBoundItem is Client client && client.Id == _selectedClient.Id)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void DataGridViewClients_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewClients.SelectedRows.Count > 0)
            {
                _selectedClient = dataGridViewClients.SelectedRows[0].DataBoundItem as Client;
                button5.Visible = true;
                button6.Visible = true;
            }
            else
            {
                _selectedClient = null;
                button5.Visible = false;
                button6.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                MessageBox.Show("Please finish editing the current client before adding a new one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AddClient();
        }

        private void AddClient()
        {
            string name = textBox1.Text;
            Speciality speciality = (Speciality)comboBox1.SelectedItem;
            LevelOfMagic levelOfMagic = (LevelOfMagic)comboBox2.SelectedItem;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a valid name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                LibraryManager.AddClient(name, speciality, levelOfMagic);
                MessageBox.Show("Client added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();

                if (dataGridViewClients.Visible)
                {
                    DisplayClients();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridViewClients.Visible = true;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            DisplayClients();
        }

        private void DisplayClients()
        {
            try
            {
                _clients = LibraryManager.GetAllClients();
                dataGridViewClients.DataSource = null;
                dataGridViewClients.DataSource = _clients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (_selectedClient == null)
            {
                MessageBox.Show("Please select a client to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isEditing = true;
            textBox1.Text = _selectedClient.Name;
            comboBox1.SelectedItem = _selectedClient.Speciality;
            comboBox2.SelectedItem = _selectedClient.LevelOfMagic;

            button1.Enabled = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = true;

            // Ensure form controls are visible
            textBox1.BringToFront();
            comboBox1.BringToFront();
            comboBox2.BringToFront();
            label1.BringToFront();
            label2.BringToFront();
            label3.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (_selectedClient == null) return;

            var result = MessageBox.Show($"Are you sure you want to delete {_selectedClient.Name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    LibraryManager.DeleteClient(_selectedClient.Id);
                    MessageBox.Show("Client deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayClients();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (_selectedClient == null) return;

            string name = textBox1.Text;
            Speciality speciality = (Speciality)comboBox1.SelectedItem;
            LevelOfMagic levelOfMagic = (LevelOfMagic)comboBox2.SelectedItem;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a valid name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                LibraryManager.UpdateClient(_selectedClient.Id, name, speciality, levelOfMagic);
                MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                DisplayClients();
                EndEditing();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void EndEditing()
        {
            _isEditing = false;
            _selectedClient = null;
            button1.Enabled = true;
            button7.Visible = false;
            ClearForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridViewClients.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            EndEditing();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Close();
        }

        // Empty event handlers
        private void label3_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void ClientForm_Load(object sender, EventArgs e) { }
        private void dataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}