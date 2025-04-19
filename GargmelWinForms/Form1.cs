using BLGargamelLibrary;
using DALGargameLibrary;

namespace GargmelWinForms
{
    public partial class Form1 : Form
    {
        MagicType? typeOfMagic;

        public Form1()
        {
            InitializeComponent();
            LoadMagicTypes();
            ConfigureDataGridView();
            ConfigureSpellBooksDataGridView();
            ConfigureRecipeBooksDataGridView();
            ListBook.Visible = false;
            // Masquer le deuxi�me DataGridView au d�marrage
            dgvSpellBooks.Visible = false;
            dgvRecipeBooks.Visible = false;
            btnShowSpellBooks.Click += button1_Click;
            btnShowRecipeBooks.Click += btnShowRecipeBooks_Click;
            btnReturn.Click += btnReturn_Click;
            btnReturn.BringToFront();
            btnBackToWelcome.BringToFront();
        }

        private void LoadMagicTypes()
        {
            // Remplir le ComboBox avec les valeurs de l'�num�ration MagicType
            cbMagicType.DataSource = Enum.GetValues(typeof(MagicType));
        }
        private void bAdd_Click(object sender, EventArgs e)
        {
            // V�rification de la validit� du num�ro de s�rie et du titre
            if (int.TryParse(tbSerial.Text, out int serial) && !string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                // V�rification de type de magie et nombre de recettes
                int? numberOfRecipes = int.TryParse(tbNOR.Text, out int recipes) ? recipes : (int?)null;

                if (typeOfMagic.HasValue || numberOfRecipes.HasValue)
                {
                    // Ajout du livre dans la biblioth�que
                    LibraryManager.AddBook(serial, tbTitle.Text, typeOfMagic, numberOfRecipes);
                    MessageBox.Show("Livre ajout� avec succ�s !");
                    // LoadBooks(); // D�commentez si vous souhaitez recharger les livres
                }
                else
                {
                    MessageBox.Show("Veuillez choisir un type de magie ou entrer un nombre de recettes.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un num�ro de s�rie valide et un titre.");
            }
        }

        private void cbMagicType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Affecter la valeur s�lectionn�e pour typeOfMagic
            typeOfMagic = cbMagicType.SelectedItem as MagicType?;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ce gestionnaire semble vide, � remplir si n�cessaire.
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }


        private void ConfigureDataGridView()
        {
            // Ajouter des colonnes personnalis�es
            ListBook.AutoGenerateColumns = false; // D�sactiver la g�n�ration automatique des colonnes
            ListBook.Columns.Clear();

            // Colonne pour le Serial
            ListBook.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Serial",
                HeaderText = "Serial",
                Name = "colSerial"
            });

            // Colonne pour le Title
            ListBook.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Title",
                Name = "colTitle"
            });

        }
        private void ConfigureSpellBooksDataGridView()
        {
            // D�sactiver la g�n�ration automatique des colonnes
            dgvSpellBooks.AutoGenerateColumns = false;

            // Effacer toutes les colonnes existantes
            dgvSpellBooks.Columns.Clear();

            // Colonne pour le Title
            dgvSpellBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Title",
                Name = "colTitle"
            });

            // Colonne pour le Magic Type
            dgvSpellBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TypeOfMagic",
                HeaderText = "Magic Type",
                Name = "colMagicType"
            });
        }
        private void ConfigureRecipeBooksDataGridView()
        {
            // D�sactiver la g�n�ration automatique des colonnes
            dgvRecipeBooks.AutoGenerateColumns = false;

            // Effacer toutes les colonnes existantes
            dgvRecipeBooks.Columns.Clear();

            // Colonne pour le Title
            dgvRecipeBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Title",
                Name = "colTitle"
            });

            // Colonne pour le NumberOfRecipes
            dgvRecipeBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NumberOfRecipes",
                HeaderText = "Number of Recipes",
                Name = "colNumberOfRecipes"
            });
        }

        private void bDisplay_Click(object sender, EventArgs e)
        {
            // R�cup�rer tous les livres (SpellBooks et RecipeBooks)
            var books = LibraryManager.GetAllBooks();
            // Afficher les livres dans le DataGridView
            ListBook.DataSource = books;

            // Afficher le DataGridView
            ListBook.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // R�cup�rer tous les SpellBooks
            var spellBooks = LibraryManager.GetAllSpellBooks();

            // Afficher les SpellBooks dans le deuxi�me DataGridView
            dgvSpellBooks.DataSource = spellBooks;

            // Afficher le deuxi�me DataGridView
            dgvSpellBooks.Visible = true;
        }

        private void dgvSpellBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btnShowRecipeBooks_Click(object sender, EventArgs e)
        {
            // R�cup�rer tous les RecipeBooks
            var recipeBooks = LibraryManager.GetAllRecipeBooks();

            // Afficher les RecipeBooks dans le deuxi�me DataGridView
            dgvRecipeBooks.DataSource = recipeBooks;

            // Afficher le deuxi�me DataGridView
            dgvRecipeBooks.Visible = true;
        }

        private void dgvRecipeBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // Masquer le DataGridView
            ListBook.Visible = false;
            dgvRecipeBooks.Visible = false;
            dgvSpellBooks.Visible = false;

            // Afficher � nouveau le formulaire principal

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();

            // Fermer Form1
            this.Close();

        }
    }
}
