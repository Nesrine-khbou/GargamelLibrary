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
using DALGargameLibrary;

namespace GargmelWinForms
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
            // Remplir les ComboBox avec les valeurs des énumérations
            comboBox1.DataSource = Enum.GetValues(typeof(Speciality));
            comboBox2.DataSource = Enum.GetValues(typeof(LevelOfMagic));
            ConfigureDataGridView();
            dataGridViewClients.Visible = false;
            button3.BringToFront();

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClient();

        }
        private void AddClient()
        {
            // Récupérer les valeurs des contrôles
            string name = textBox1.Text;
            Speciality speciality = (Speciality)comboBox1.SelectedItem;
            LevelOfMagic levelOfMagic = (LevelOfMagic)comboBox2.SelectedItem;

            // Valider les entrées
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a valid name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ajouter le client à la base de données
            try
            {
                LibraryManager.AddClient(name, speciality, levelOfMagic);
                MessageBox.Show("Client added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Effacer les champs après l'ajout
                textBox1.Clear();
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridViewClients.Visible = true;
            DisplayClients();

        }
        private void DisplayClients()
        {
            try
            {
                // Récupérer tous les clients de la base de données
                var clients = LibraryManager.GetAllClients();

                // Afficher les clients dans le DataGridView
                dataGridViewClients.DataSource = clients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }
        private void ConfigureDataGridView()
        {
            // Désactiver la génération automatique des colonnes
            dataGridViewClients.AutoGenerateColumns = false;

            // Ajouter des colonnes personnalisées
            dataGridViewClients.Columns.Clear();

            // Colonne pour l'ID
            dataGridViewClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "colId"
            });

            // Colonne pour le nom
            dataGridViewClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
                Name = "colName"
            });

            // Colonne pour la spécialité
            dataGridViewClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Speciality",
                HeaderText = "Speciality",
                Name = "colSpeciality"
            });

            // Colonne pour le niveau de magie
            dataGridViewClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LevelOfMagic",
                HeaderText = "Level of Magic",
                Name = "colLevelOfMagic"
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Masquer le DataGridView
            dataGridViewClients.Visible = false;

            // Afficher à nouveau le formulaire principal

        }

        private void dataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();

            // Fermer Form1
            this.Close();
        }
    }
}
