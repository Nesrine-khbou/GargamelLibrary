using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GargmelWinForms
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Créer une instance de Form1
            Form1 form1 = new Form1();

            // Afficher Form1
            form1.Show();

            // Masquer WelcomeForm
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientForm ClientForm = new ClientForm();

            // Afficher ClientForm
            ClientForm.Show();

            // Masquer WelcomeForm
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SmurfForm SmurfForm = new SmurfForm();

            // Afficher SmurfForm
            SmurfForm.Show();

            // Masquer WelcomeForm
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 IngredientForm = new Form2();

            // Afficher IngredientForm
            IngredientForm.Show();

            // Masquer WelcomeForm
            this.Hide();
        }
    }
}
