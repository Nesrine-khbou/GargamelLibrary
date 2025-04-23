using BLGargamelLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GargmelWinForms
{
    public partial class Form1 : Form
    {
        private Image backgroundImage;
        private MagicType? typeOfMagic;
        private Book? currentBook;
        private bool isEditing = false;

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            LoadBackgroundImage();
            ApplySpookyTheme();
            LoadMagicTypes();
            ConfigureDataGridViews();
            SetupEventHandlers();

            ListBook.Visible = false;
            dgvSpellBooks.Visible = false;
            dgvRecipeBooks.Visible = false;

            ListBook.TabStop = true;
            dgvSpellBooks.TabStop = true;
            dgvRecipeBooks.TabStop = true;
        }

        private void LoadBackgroundImage()
        {
            try
            {
                backgroundImage = Image.FromFile(@"E:\neeeeesss\2eme ing\2eme_semestre\net\GargamelLibrary1\GargamelLibrary1\book7.jpg");
                this.BackgroundImage = backgroundImage;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.DoubleBuffered = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load background image: {ex.Message}\nUsing fallback color.",
                    "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BackColor = Color.FromArgb(30, 10, 30);
            }
        }

        private void ApplySpookyTheme()
        {
            // Main form styling
            this.ForeColor = Color.GhostWhite;
            this.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);

            // Control positioning
            label1.Location = new Point((this.ClientSize.Width - label1.Width) / 2, 40);
            label2.Location = new Point(50, 75);
            comboBox1.Location = new Point(50, 100);
            comboBox1.Size = new Size(200, 30);
            label1.Location = new Point(50, 135);
            tbSerial.Location = new Point(50, 160);
            tbSerial.Size = new Size(200, 30);
            label3.Location = new Point(50, 195);
            tbTitle.Location = new Point(50, 220);
            tbTitle.Size = new Size(200, 30);
            groupBox1.Location = new Point(300, 100);
            groupBox1.Size = new Size(300, 100);
            label5.Location = new Point(10, 25);
            cbMagicType.Location = new Point(130, 25);
            cbMagicType.Size = new Size(160, 30);
            groupBox2.Location = new Point(300, 220);
            groupBox2.Size = new Size(300, 100);
            label6.Location = new Point(10, 25);
            tbNOR.Location = new Point(210, 25);
            tbNOR.Size = new Size(70, 30);
            bAdd.Location = new Point(50, 350);
            bAdd.Size = new Size(200, 40);
            bDisplay.Location = new Point(50, 400);
            bDisplay.Size = new Size(200, 40);
            btnShowSpellBooks.Location = new Point(650, 150);
            btnShowSpellBooks.Size = new Size(250, 40);
            btnShowRecipeBooks.Location = new Point(650, 200);
            btnShowRecipeBooks.Size = new Size(250, 40);
            btnReturn.Location = new Point(50, 500);
            btnReturn.Size = new Size(150, 40);
            btnBackToWelcome.Location = new Point(20, 20);
            btnBackToWelcome.Size = new Size(40, 40);

            // DataGridView styling
            var grids = new[] { ListBook, dgvSpellBooks, dgvRecipeBooks };
            foreach (var grid in grids)
            {
                grid.EnableHeadersVisualStyles = false;
                grid.BackgroundColor = Color.FromArgb(40, 10, 40);
                grid.BorderStyle = BorderStyle.None;
                grid.GridColor = Color.FromArgb(70, 30, 70);
                grid.DefaultCellStyle.BackColor = Color.FromArgb(50, 20, 50);
                grid.DefaultCellStyle.ForeColor = Color.AntiqueWhite;
                grid.DefaultCellStyle.Font = new Font("Lucida Handwriting", 10);
                grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 40, 90);
                grid.DefaultCellStyle.SelectionForeColor = Color.White;
                grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(60, 30, 60);
                grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 20, 60);
                grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.AntiqueWhite;
                grid.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
                grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grid.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 20, 60);
                grid.RowHeadersDefaultCellStyle.ForeColor = Color.AntiqueWhite;
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid.AllowUserToResizeRows = false;
                grid.RowTemplate.Height = 30;
                grid.Location = new Point((this.ClientSize.Width - 900) / 2, 250);
                grid.Size = new Size(900, 400);
            }

            // Label styling
            var labels = new[] { label1, label2, label3, label5, label6 };
            foreach (var label in labels)
            {
                label.ForeColor = Color.AntiqueWhite;
                label.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
                label.BackColor = Color.Transparent;
            }

            // GroupBox styling
            var groupBoxes = new[] { groupBox1, groupBox2 };
            foreach (var groupBox in groupBoxes)
            {
                groupBox.ForeColor = Color.AntiqueWhite;
                groupBox.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
                groupBox.BackColor = Color.Transparent;
            }

            // TextBox and ComboBox styling
            var textBoxes = new[] { tbSerial, tbTitle, tbNOR };
            foreach (var textBox in textBoxes)
            {
                textBox.BackColor = Color.FromArgb(70, 20, 70);
                textBox.ForeColor = Color.AntiqueWhite;
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
            }

            var comboBoxes = new[] { comboBox1, cbMagicType };
            foreach (var comboBox in comboBoxes)
            {
                comboBox.BackColor = Color.FromArgb(70, 20, 70);
                comboBox.ForeColor = Color.AntiqueWhite;
                comboBox.FlatStyle = FlatStyle.Flat;
                comboBox.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
            }

            // Button styling
            var buttons = new[] { bAdd, bDisplay, btnShowSpellBooks, btnShowRecipeBooks, btnReturn, btnBackToWelcome };
            foreach (var button in buttons)
            {
                button.BackColor = Color.FromArgb(120, 70, 20, 70);
                button.ForeColor = Color.AntiqueWhite;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = Color.Black;
                button.FlatAppearance.BorderSize = 2;
                button.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);

                button.MouseEnter += (sender, e) =>
                {
                    button.BackColor = Color.FromArgb(150, 90, 30, 90);
                    button.ForeColor = Color.White;
                    button.Cursor = Cursors.Hand;
                };

                button.MouseLeave += (sender, e) =>
                {
                    button.BackColor = Color.FromArgb(120, 70, 20, 70);
                    button.ForeColor = Color.AntiqueWhite;
                };
            }

            btnBackToWelcome.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
            btnBackToWelcome.Text = "←";
        }

        private DialogResult ShowStyledMessage(string message, string title = "Message")
        {
            Form messageForm = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                Text = title,
                BackColor = Color.FromArgb(50, 20, 50),
                ForeColor = Color.AntiqueWhite
            };

            Label messageLabel = new Label()
            {
                Text = message,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Lucida Handwriting", 12, FontStyle.Bold)
            };

            Button okButton = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.FromArgb(70, 30, 70),
                ForeColor = Color.AntiqueWhite,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Lucida Handwriting", 10)
            };

            okButton.FlatAppearance.BorderColor = Color.FromArgb(100, 50, 100);

            messageForm.Controls.Add(messageLabel);
            messageForm.Controls.Add(okButton);

            return messageForm.ShowDialog();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (backgroundImage == null)
            {
                using (Pen borderPen = new Pen(Color.FromArgb(70, 20, 70), 3))
                {
                    e.Graphics.DrawRectangle(borderPen, 5, 5, this.Width - 10, this.Height - 10);
                }
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, 30, 10, 30)), this.ClientRectangle);
            }
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
                    Name = "colSerial",
                    Width = 150
                });

                grid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Title",
                    HeaderText = "Title",
                    Name = "colTitle",
                    Width = 300
                });
            }

            ConfigureGrid(ListBook);
            ConfigureGrid(dgvSpellBooks);
            ConfigureGrid(dgvRecipeBooks);

            dgvSpellBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TypeOfMagic",
                HeaderText = "Magic Type",
                Name = "colMagicType",
                Width = 200
            });

            dgvRecipeBooks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NumberOfRecipes",
                HeaderText = "Recipes",
                Name = "colRecipes",
                Width = 150
            });
        }

        private void SetupEventHandlers()
        {
            btnShowSpellBooks.Click += (s, e) => ShowBooks(LibraryManager.GetAllSpellBooks(), dgvSpellBooks);
            btnShowRecipeBooks.Click += (s, e) => ShowBooks(LibraryManager.GetAllRecipeBooks(), dgvRecipeBooks);
            bDisplay.Click += (s, e) => ShowBooks(LibraryManager.GetAllBooks(), ListBook);

            btnReturn.Click += (s, e) => ShowMainForm();
            btnBackToWelcome.Click += (s, e) => { new WelcomeForm().Show(); this.Close(); };

            bAdd.Click += AddOrUpdateBook;
            cbMagicType.SelectedIndexChanged += (s, e) => typeOfMagic = (MagicType)cbMagicType.SelectedItem;

            ListBook.CellDoubleClick += (s, e) => LoadBookForEditing(ListBook);
            dgvSpellBooks.CellDoubleClick += (s, e) => LoadBookForEditing(dgvSpellBooks);
            dgvRecipeBooks.CellDoubleClick += (s, e) => LoadBookForEditing(dgvRecipeBooks);

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

                    Form confirmForm = new Form()
                    {
                        Width = 400,
                        Height = 150,
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        StartPosition = FormStartPosition.CenterParent,
                        MaximizeBox = false,
                        MinimizeBox = false,
                        Text = "Confirm Delete",
                        BackColor = Color.FromArgb(50, 20, 50),
                        ForeColor = Color.AntiqueWhite
                    };

                    Label messageLabel = new Label()
                    {
                        Text = $"Delete '{book.Title}'?",
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Lucida Handwriting", 12, FontStyle.Bold)
                    };

                    FlowLayoutPanel buttonPanel = new FlowLayoutPanel()
                    {
                        Dock = DockStyle.Bottom,
                        Height = 40,
                        FlowDirection = FlowDirection.RightToLeft,
                        Padding = new Padding(5)
                    };

                    Button noButton = new Button()
                    {
                        Text = "No",
                        DialogResult = DialogResult.No,
                        Width = 80,
                        BackColor = Color.FromArgb(70, 30, 70),
                        ForeColor = Color.AntiqueWhite,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Lucida Handwriting", 10)
                    };

                    Button yesButton = new Button()
                    {
                        Text = "Yes",
                        DialogResult = DialogResult.Yes,
                        Width = 80,
                        BackColor = Color.FromArgb(70, 30, 70),
                        ForeColor = Color.AntiqueWhite,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Lucida Handwriting", 10)
                    };

                    yesButton.FlatAppearance.BorderColor = Color.FromArgb(100, 50, 100);
                    noButton.FlatAppearance.BorderColor = Color.FromArgb(100, 50, 100);

                    buttonPanel.Controls.Add(yesButton);
                    buttonPanel.Controls.Add(noButton);

                    confirmForm.Controls.Add(messageLabel);
                    confirmForm.Controls.Add(buttonPanel);

                    if (confirmForm.ShowDialog() == DialogResult.Yes)
                    {
                        try
                        {
                            LibraryManager.DeleteBook(book.Id);
                            RefreshActiveGrid();
                            ShowStyledMessage("Book deleted successfully.", "Success");
                        }
                        catch (Exception ex)
                        {
                            ShowStyledMessage($"Error deleting book: {ex.Message}", "Error");
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
                ShowStyledMessage("Please enter valid serial and title.", "Validation Error");
                return;
            }

            int? recipes = int.TryParse(tbNOR.Text, out int r) ? r : (int?)null;

            try
            {
                if (isEditing && currentBook != null)
                {
                    LibraryManager.UpdateBook(currentBook.Id, serial, tbTitle.Text, typeOfMagic, recipes);
                    ShowStyledMessage("Book updated successfully!", "Success");

                    if (currentBook is SpellBook)
                        ShowBooks(LibraryManager.GetAllSpellBooks(), dgvSpellBooks);
                    else if (currentBook is RecipeBook)
                        ShowBooks(LibraryManager.GetAllRecipeBooks(), dgvRecipeBooks);
                }
                else
                {
                    LibraryManager.AddBook(serial, tbTitle.Text, typeOfMagic, recipes);
                    ShowStyledMessage("Book added successfully!", "Success");
                    ShowBooks(LibraryManager.GetAllBooks(), ListBook);
                }

                ResetForm();
            }
            catch (Exception ex)
            {
                ShowStyledMessage($"Error: {ex.Message}", "Error");
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