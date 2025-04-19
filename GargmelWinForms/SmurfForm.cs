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

namespace GargmelWinForms
{
    public partial class SmurfForm : Form
    {
        public SmurfForm()
        {
            InitializeComponent();
            // Remplir le ComboBox avec les valeurs de l'énumération SmurfDescription
            comboBox1.DataSource = Enum.GetValues(typeof(SmurfDescription));

            // Masquer le DataGridView par défaut
            dataGridView1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSmurf();

        }
        private void AddSmurf()
        {
            // Récupérer les valeurs des contrôles
            string name = textBox1.Text;
            double height = (double)numericUpDown1.Value;

            SmurfDescription description = (SmurfDescription)comboBox1.SelectedItem;

            // Ajouter le Schtroumpf à la base de données
            try
            {
                LibraryManager.AddSmurf(name, height, description);
                MessageBox.Show("Smurf added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Effacer les champs après l'ajout
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedIndex = 0;

                // Actualiser l'affichage des Schtroumpfs
                DisplaySmurfs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            // Afficher le DataGridView
            dataGridView1.Visible = true;

            // Afficher les Schtroumpfs
            DisplaySmurfs();
        }
        private void DisplaySmurfs()
        {
            try
            {
                // Récupérer tous les Schtroumpfs de la base de données
                var smurfs = LibraryManager.GetAllSmurfs();

                // Afficher les Schtroumpfs dans le DataGridView
                dataGridView1.DataSource = smurfs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading smurfs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();

            // Fermer Form1
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Masquer le DataGridView
            dataGridView1.Visible = false;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
