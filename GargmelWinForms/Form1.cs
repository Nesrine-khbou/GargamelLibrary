using BLGargamelLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GargmelWinForms
{
    public partial class Form1 : Form
    {
        private MagicType? typeOfMagic;
        private Book? currentBook;
        private bool isEditing = false;

        public Form1()
        {
            InitializeComponent();
            LoadMagicTypes();
            ConfigureDataGridViews();
            SetupEventHandlers();

            // Hide all DataGridViews initially
            ListBook.Visible = false;
            dgvSpellBooks.Visible = false;
            dgvRecipeBooks.Visible = false;

            // Ensure grids can receive keyboard focus
            ListBook.TabStop = true;
            dgvSpellBooks.TabStop = true;
            dgvRecipeBooks.TabStop = true;
        }

        private void LoadMagicTypes()
        {
            cbMagicType.DataSource = Enum.GetValues(typeof(MagicType));
        }

        private void ConfigureDataGridViews()
        {
            void ConfigureGrid(DataGridView grid)
            {
                grid.AutoGenerateColumns = false;
                grid.Columns.Clear();
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                grid.MultiSelect = false;

                // Visual styling
                grid.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                grid.DefaultCellStyle.SelectionForeColor = Color.Black;
                grid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.LightBlue;

                // Common columns
                grid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Id",
                    HeaderText = "ID",
                    Name = "colId",
                    Visible = false
                });

                grid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Serial",
                    HeaderText = "Serial",
                    Name = "colSerial"
                });

                grid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Title",
                    HeaderText = "Title",
                    Name = "colTitle"
                });
            }

            // Configure each grid
            ConfigureGrid(ListBook);
            ConfigureGrid(dgvSpellBooks);
            ConfigureGrid(dgvRecipeBooks);

            // Type-specific columns
            dgvSpellBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TypeOfMagic",
                HeaderText = "Magic Type",
                Name = "colMagicType"
            });

            dgvRecipeBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NumberOfRecipes",
                HeaderText = "Recipes",
                Name = "colRecipes"
            });
        }

        private void SetupEventHandlers()
        {
            // Display buttons
            btnShowSpellBooks.Click += (s, e) => ShowBooks(LibraryManager.GetAllSpellBooks(), dgvSpellBooks);
            btnShowRecipeBooks.Click += (s, e) => ShowBooks(LibraryManager.GetAllRecipeBooks(), dgvRecipeBooks);
            bDisplay.Click += (s, e) => ShowBooks(LibraryManager.GetAllBooks(), ListBook);

            // Navigation buttons
            btnReturn.Click += (s, e) => ShowMainForm();
            btnBackToWelcome.Click += (s, e) => { new WelcomeForm().Show(); this.Close(); };

            // Book operations
            bAdd.Click += AddOrUpdateBook;
            cbMagicType.SelectedIndexChanged += (s, e) => typeOfMagic = cbMagicType.SelectedItem as MagicType?;

            // Edit on double-click
            ListBook.CellDoubleClick += (s, e) => LoadBookForEditing(ListBook);
            dgvSpellBooks.CellDoubleClick += (s, e) => LoadBookForEditing(dgvSpellBooks);
            dgvRecipeBooks.CellDoubleClick += (s, e) => LoadBookForEditing(dgvRecipeBooks);

            // Delete key handling
            ListBook.KeyDown += HandleDeleteKey;
            dgvSpellBooks.KeyDown += HandleDeleteKey;
            dgvRecipeBooks.KeyDown += HandleDeleteKey;
        }

        private void HandleDeleteKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var grid = sender as DataGridView;
                if (grid?.SelectedRows.Count > 0)
                {
                    var book = (Book)grid.SelectedRows[0].DataBoundItem;
                    if (MessageBox.Show($"Delete '{book.Title}'?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            LibraryManager.DeleteBook(book.Id);
                            RefreshActiveGrid();
                            MessageBox.Show("Book deleted successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting book: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void LoadBookForEditing(DataGridView grid)
        {
            if (grid.SelectedRows.Count == 0) return;

            var book = (Book)grid.SelectedRows[0].DataBoundItem;
            currentBook = book;
            isEditing = true;

            tbSerial.Text = book.Serial.ToString();
            tbTitle.Text = book.Title;

            if (book is SpellBook spellBook)
            {
                comboBox1.SelectedItem = "SpellBook";
                cbMagicType.SelectedItem = spellBook.TypeOfMagic;
                tbNOR.Text = "";
            }
            else if (book is RecipeBook recipeBook)
            {
                comboBox1.SelectedItem = "RecipeBook";
                tbNOR.Text = recipeBook.NumberOfRecipes.ToString();
                cbMagicType.SelectedItem = MagicType.None;
            }

            bAdd.Text = "Update Book";
            ShowMainForm();
        }

        private void AddOrUpdateBook(object sender, EventArgs e)
        {
            if (!int.TryParse(tbSerial.Text, out int serial) || string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                MessageBox.Show("Please enter valid serial and title.");
                return;
            }

            int? recipes = int.TryParse(tbNOR.Text, out int r) ? r : (int?)null;

            try
            {
                if (isEditing && currentBook != null)
                {
                    LibraryManager.UpdateBook(currentBook.Id, serial, tbTitle.Text, typeOfMagic, recipes);
                    MessageBox.Show("Book updated!");

                    // Show the appropriate grid after update
                    if (currentBook is SpellBook)
                        ShowBooks(LibraryManager.GetAllSpellBooks(), dgvSpellBooks);
                    else if (currentBook is RecipeBook)
                        ShowBooks(LibraryManager.GetAllRecipeBooks(), dgvRecipeBooks);
                }
                else
                {
                    LibraryManager.AddBook(serial, tbTitle.Text, typeOfMagic, recipes);
                    MessageBox.Show("Book added!");
                    ShowBooks(LibraryManager.GetAllBooks(), ListBook);
                }

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ShowBooks<T>(List<T> books, DataGridView grid) where T : Book
        {
            grid.DataSource = books;
            ShowBooksGrid(grid);
        }

        private void ShowBooksGrid(DataGridView grid)
        {
            ListBook.Visible = grid == ListBook;
            dgvSpellBooks.Visible = grid == dgvSpellBooks;
            dgvRecipeBooks.Visible = grid == dgvRecipeBooks;
        }

        private void ShowMainForm()
        {
            ListBook.Visible = false;
            dgvSpellBooks.Visible = false;
            dgvRecipeBooks.Visible = false;
        }

        private void RefreshActiveGrid()
        {
            if (ListBook.Visible)
                ListBook.DataSource = LibraryManager.GetAllBooks();
            else if (dgvSpellBooks.Visible)
                dgvSpellBooks.DataSource = LibraryManager.GetAllSpellBooks();
            else if (dgvRecipeBooks.Visible)
                dgvRecipeBooks.DataSource = LibraryManager.GetAllRecipeBooks();
        }

        private void ResetForm()
        {
            currentBook = null;
            isEditing = false;
            tbSerial.Text = "";
            tbTitle.Text = "";
            tbNOR.Text = "";
            cbMagicType.SelectedItem = MagicType.None;
            comboBox1.SelectedIndex = -1;
            bAdd.Text = "Add Book";
        }
    }
}