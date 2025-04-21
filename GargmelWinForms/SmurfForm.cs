using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLGargamelLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GargmelWinForms
{
    public partial class SmurfForm : Form
    {
        private Smurf selectedSmurf = null;  // Track selected smurf

        public SmurfForm()
        {
            InitializeComponent();
            // Fill ComboBox with SmurfDescription enum values
            comboBox1.DataSource = Enum.GetValues(typeof(SmurfDescription));

            // Hide DataGridView by default
            dataGridView1.Visible = false;

            // Configure DataGridView
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // Add columns
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "colId",
                Visible = false // Hide ID as it's not needed visually
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
                Name = "colName"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Height",
                HeaderText = "Height (cm)",
                Name = "colHeight"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Description",
                HeaderText = "Description",
                Name = "colDescription"
            });
        }

        private void AddSmurf()
        {
            // Get values from controls
            string name = textBox1.Text;
            double height = (double)numericUpDown1.Value;
            SmurfDescription description = (SmurfDescription)comboBox1.SelectedItem;

            try
            {
                LibraryManager.AddSmurf(name, height, description);
                MessageBox.Show("Smurf added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields after adding
                textBox1.Clear();
                numericUpDown1.Value = 0;
                comboBox1.SelectedIndex = 0;

                // Refresh display
                DisplaySmurfs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplaySmurfs()
        {
            try
            {
                var smurfs = LibraryManager.GetAllSmurfs();
                dataGridView1.DataSource = smurfs;

                // Configure selection
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading smurfs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedSmurf = (Smurf)dataGridView1.SelectedRows[0].DataBoundItem;
                textBox1.Text = selectedSmurf.Name;
                numericUpDown1.Value = (decimal)selectedSmurf.Height;
                comboBox1.SelectedItem = selectedSmurf.Description;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (selectedSmurf == null)
            {
                MessageBox.Show("Please select a smurf to modify", "Warning",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LibraryManager.UpdateSmurf(
                    selectedSmurf.Id,
                textBox1.Text,
                    (double)numericUpDown1.Value,
                    (SmurfDescription)comboBox1.SelectedItem
                );

                MessageBox.Show("Smurf updated successfully!", "Success",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplaySmurfs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating smurf: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSmurf == null)
            {
                MessageBox.Show("Please select a smurf to delete", "Warning",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete {selectedSmurf.Name}?",
                                       "Confirm Delete",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    LibraryManager.DeleteSmurf(selectedSmurf.Id);
                    MessageBox.Show("Smurf deleted successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear selection and refresh
                    selectedSmurf = null;
                    textBox1.Clear();
                    numericUpDown1.Value = 0;
                    comboBox1.SelectedIndex = 0;
                    DisplaySmurfs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting smurf: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Existing event handlers (keep these as they are)
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { AddSmurf(); }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            DisplaySmurfs();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void button3_Click(object sender, EventArgs e)
        {
            new WelcomeForm().Show();
            this.Close();
        }
        private void button5_Click(object sender, EventArgs e) { dataGridView1.Visible = false; }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }
    }
}