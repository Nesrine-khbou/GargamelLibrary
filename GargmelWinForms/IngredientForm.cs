using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLGargamelLibrary;

namespace GargmelWinForms
{
    public partial class IngredientsForm : Form
    {
        private Ingredient _selectedIngredient = null;
        private bool _isEditing = false;
        private List<Ingredient> _ingredients = new List<Ingredient>();
        private Image _backgroundImage;

        public IngredientsForm()
        {
            InitializeComponent();
            this.Size = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            LoadBackgroundImage();
            ApplySpookyTheme();
            ConfigureDataGridView();
            dataGridViewIngredients.Visible = false;
            btnReturn.BringToFront();
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
        }

        private void LoadBackgroundImage()
        {
            try
            {
                _backgroundImage = Image.FromFile(@"E:\neeeeesss\2eme ing\2eme_semestre\net\GargamelLibrary1\GargamelLibrary1\ingredient8.png");
                this.BackgroundImage = _backgroundImage;
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
            label1.Location = new Point(50, 100);
            txtName.Location = new Point(200, 100);
            txtName.Size = new Size(200, 30);

            label2.Location = new Point(50, 150);
            txtType.Location = new Point(200, 150);
            txtType.Size = new Size(200, 30);

            label3.Location = new Point(50, 200);
            txtLocation.Location = new Point(200, 200);
            txtLocation.Size = new Size(200, 30);

            label4.Location = new Point(50, 250);
            txtColor.Location = new Point(200, 250);
            txtColor.Size = new Size(200, 30);

            btnAdd.Location = new Point(450, 100);
            btnAdd.Size = new Size(150, 40);

            btnDisplay.Location = new Point(450, 150);
            btnDisplay.Size = new Size(150, 40);

            btnEdit.Location = new Point(650, 100);
            btnEdit.Size = new Size(200, 40);

            btnDelete.Location = new Point(650, 150);
            btnDelete.Size = new Size(200, 40);

            btnSave.Location = new Point(650, 200);
            btnSave.Size = new Size(200, 40);

            btnReturn.Location = new Point(50, 600);
            btnReturn.Size = new Size(150, 40);

            btnBack.Location = new Point(20, 20);
            btnBack.Size = new Size(40, 40);

            // DataGridView styling
            dataGridViewIngredients.EnableHeadersVisualStyles = false;
            dataGridViewIngredients.BackgroundColor = Color.FromArgb(40, 10, 40);
            dataGridViewIngredients.BorderStyle = BorderStyle.None;
            dataGridViewIngredients.GridColor = Color.FromArgb(70, 30, 70);
            dataGridViewIngredients.DefaultCellStyle.BackColor = Color.FromArgb(50, 20, 50);
            dataGridViewIngredients.DefaultCellStyle.ForeColor = Color.AntiqueWhite;
            dataGridViewIngredients.DefaultCellStyle.Font = new Font("Lucida Handwriting", 10);
            dataGridViewIngredients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 40, 90);
            dataGridViewIngredients.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewIngredients.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewIngredients.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(60, 30, 60);
            dataGridViewIngredients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 20, 60);
            dataGridViewIngredients.ColumnHeadersDefaultCellStyle.ForeColor = Color.AntiqueWhite;
            dataGridViewIngredients.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
            dataGridViewIngredients.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewIngredients.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 20, 60);
            dataGridViewIngredients.RowHeadersDefaultCellStyle.ForeColor = Color.AntiqueWhite;
            dataGridViewIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewIngredients.AllowUserToResizeRows = false;
            dataGridViewIngredients.RowTemplate.Height = 30;
            dataGridViewIngredients.Location = new Point((this.ClientSize.Width - 900) / 2, 300);
            dataGridViewIngredients.Size = new Size(900, 350);

            // Label styling
            var labels = new[] { label1, label2, label3, label4 };
            foreach (var label in labels)
            {
                label.ForeColor = Color.AntiqueWhite;
                label.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
                label.BackColor = Color.Transparent;
            }

            // TextBox styling
            var textBoxes = new[] { txtName, txtType, txtLocation, txtColor };
            foreach (var textBox in textBoxes)
            {
                textBox.BackColor = Color.FromArgb(70, 20, 70);
                textBox.ForeColor = Color.AntiqueWhite;
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
            }

            // Button styling
            var buttons = new[] { btnAdd, btnDisplay, btnEdit, btnDelete, btnSave, btnReturn, btnBack };
            foreach (var button in buttons)
            {
                button.BackColor = Color.FromArgb(255, 70, 20, 70);
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

            // Special styling for back button
            btnBack.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
            btnBack.Text = "←";
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

            if (_backgroundImage == null)
            {
                using (Pen borderPen = new Pen(Color.FromArgb(70, 20, 70), 3))
                {
                    e.Graphics.DrawRectangle(borderPen, 5, 5, this.Width - 10, this.Height - 10);
                }
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(200, 30, 10, 30)), this.ClientRectangle);
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridViewIngredients.AutoGenerateColumns = false;
            dataGridViewIngredients.Columns.Clear();
            dataGridViewIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIngredients.MultiSelect = false;

            // Add columns
            dataGridViewIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "colId",
                Visible = false
            });
            dataGridViewIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
                Name = "colName",
                Width = 200
            });
            dataGridViewIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = "Type",
                Name = "colType",
                Width = 200
            });
            dataGridViewIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Location",
                HeaderText = "Location",
                Name = "colLocation",
                Width = 200
            });
            dataGridViewIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Color",
                HeaderText = "Color",
                Name = "colColor",
                Width = 200
            });

            dataGridViewIngredients.SelectionChanged += DataGridViewIngredients_SelectionChanged;
            dataGridViewIngredients.DataBindingComplete += DataGridViewIngredients_DataBindingComplete;
            dataGridViewIngredients.KeyDown += HandleDeleteKey;
        }

        private void DataGridViewIngredients_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_selectedIngredient != null && dataGridViewIngredients.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewIngredients.Rows)
                {
                    if (row.DataBoundItem is Ingredient ingredient && ingredient.Id == _selectedIngredient.Id)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void DataGridViewIngredients_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewIngredients.SelectedRows.Count > 0)
            {
                _selectedIngredient = dataGridViewIngredients.SelectedRows[0].DataBoundItem as Ingredient;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                _selectedIngredient = null;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void HandleDeleteKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var grid = sender as DataGridView;
                if (grid?.SelectedRows.Count > 0)
                {
                    var ingredient = (Ingredient)grid.SelectedRows[0].DataBoundItem;

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
                        Text = $"Delete '{ingredient.Name}'?",
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
                            LibraryManager.DeleteIngredient(ingredient.Id);
                            ShowStyledMessage("Ingredient deleted successfully.", "Success");
                            DisplayIngredients();
                        }
                        catch (Exception ex)
                        {
                            ShowStyledMessage($"Error deleting ingredient: {ex.Message}", "Error");
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                ShowStyledMessage("Please finish editing the current ingredient before adding a new one.", "Information");
                return;
            }

            if (ValidateFields())
            {
                AddIngredient();
            }
        }

        private void AddIngredient()
        {
            try
            {
                LibraryManager.AddIngredient(
                    txtName.Text,
                    txtType.Text,
                    txtLocation.Text,
                    txtColor.Text
                );
                ShowStyledMessage("Ingredient added successfully!", "Success");
                ClearForm();

                if (dataGridViewIngredients.Visible)
                {
                    DisplayIngredients();
                }
            }
            catch (Exception ex)
            {
                ShowStyledMessage($"An error occurred: {ex.Message}", "Error");
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dataGridViewIngredients.Visible = true;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            DisplayIngredients();
        }

        private void DisplayIngredients()
        {
            try
            {
                _ingredients = LibraryManager.GetAllIngredients();
                dataGridViewIngredients.DataSource = null;
                dataGridViewIngredients.DataSource = _ingredients;
            }
            catch (Exception ex)
            {
                ShowStyledMessage($"An error occurred while loading ingredients: {ex.Message}", "Error");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedIngredient == null)
            {
                ShowStyledMessage("Please select an ingredient to edit.", "Information");
                return;
            }

            _isEditing = true;
            txtName.Text = _selectedIngredient.Name;
            txtType.Text = _selectedIngredient.Type;
            txtLocation.Text = _selectedIngredient.Location;
            txtColor.Text = _selectedIngredient.Color;

            btnAdd.Enabled = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedIngredient == null) return;

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
                Text = $"Delete '{_selectedIngredient.Name}'?",
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
                    LibraryManager.DeleteIngredient(_selectedIngredient.Id);
                    ShowStyledMessage("Ingredient deleted successfully.", "Success");
                    DisplayIngredients();
                }
                catch (Exception ex)
                {
                    ShowStyledMessage($"Error deleting ingredient: {ex.Message}", "Error");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedIngredient == null) return;

            if (ValidateFields())
            {
                try
                {
                    LibraryManager.UpdateIngredient(
                        _selectedIngredient.Id,
                        txtName.Text,
                        txtType.Text,
                        txtLocation.Text,
                        txtColor.Text
                    );
                    ShowStyledMessage("Ingredient updated successfully!", "Success");

                    ClearForm();
                    DisplayIngredients();
                    EndEditing();
                }
                catch (Exception ex)
                {
                    ShowStyledMessage($"An error occurred: {ex.Message}", "Error");
                }
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtType.Text) ||
                string.IsNullOrWhiteSpace(txtLocation.Text) ||
                string.IsNullOrWhiteSpace(txtColor.Text))
            {
                ShowStyledMessage("Please fill in all fields.", "Error");
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtType.Clear();
            txtLocation.Clear();
            txtColor.Clear();
        }

        private void EndEditing()
        {
            _isEditing = false;
            _selectedIngredient = null;
            btnAdd.Enabled = true;
            btnSave.Visible = false;
            ClearForm();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            dataGridViewIngredients.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            EndEditing();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Close();
        }
    }
}
