using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using BLGargamelLibrary; // Bibliothèque métier
using DALGargameLibrary; // Accès aux données

namespace GargmelWinForms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadIngredients(); // Charger les ingrédients au démarrage
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtType.Text) ||
                string.IsNullOrWhiteSpace(txtLocation.Text) || string.IsNullOrWhiteSpace(txtColor.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ajouter l'ingrédient à la base de données
            LibraryManager.AddIngredient(txtName.Text, txtType.Text, txtLocation.Text, txtColor.Text);

            LoadIngredients(); // Recharger les données après l'ajout
            ClearFields();
        }

        private void LoadIngredients()
        {
            dgvIngredients.DataSource = null;
            dgvIngredients.DataSource = LibraryManager.GetAllIngredients(); // Charger depuis la BD
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtType.Text = "";
            txtLocation.Text = "";
            txtColor.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();

            // Fermer Form1
            this.Close();
        }
    }
}
