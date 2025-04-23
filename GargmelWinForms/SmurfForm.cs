using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLGargamelLibrary;

namespace GargmelWinForms
{
    public partial class SmurfForm : Form
    {
        private Smurf _selectedSmurf = null;
        private bool _isEditing = false;
        private List<Smurf> _smurfs = new List<Smurf>();
        private Image _backgroundImage;

        public SmurfForm()
        {
            InitializeComponent();
            this.Size = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            LoadBackgroundImage();
            ApplySpookyTheme();
            comboBoxDescription.DataSource = Enum.GetValues(typeof(SmurfDescription));
            ConfigureDataGridView();
            dataGridViewSmurfs.Visible = false;
            btnReturn.BringToFront();
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
        }

        private void LoadBackgroundImage()
        {
            try
            {
                _backgroundImage = Image.FromFile(@"E:\neeeeesss\2eme ing\2eme_semestre\net\GargamelLibrary1\GargamelLibrary1\smurfs1.jpg");
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
            lblName.Location = new Point(50, 100);
            txtName.Location = new Point(200, 100);
            txtName.Size = new Size(200, 30);

            lblHeight.Location = new Point(50, 150);
            numericHeight.Location = new Point(200, 150);
            numericHeight.Size = new Size(200, 30);

            lblDescription.Location = new Point(50, 200);
            comboBoxDescription.Location = new Point(200, 200);
            comboBoxDescription.Size = new Size(200, 30);

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
            dataGridViewSmurfs.EnableHeadersVisualStyles = false;
            dataGridViewSmurfs.BackgroundColor = Color.FromArgb(40, 10, 40);
            dataGridViewSmurfs.BorderStyle = BorderStyle.None;
            dataGridViewSmurfs.GridColor = Color.FromArgb(70, 30, 70);
            dataGridViewSmurfs.DefaultCellStyle.BackColor = Color.FromArgb(50, 20, 50);
            dataGridViewSmurfs.DefaultCellStyle.ForeColor = Color.AntiqueWhite;
            dataGridViewSmurfs.DefaultCellStyle.Font = new Font("Lucida Handwriting", 10);
            dataGridViewSmurfs.DefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 40, 90);
            dataGridViewSmurfs.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewSmurfs.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSmurfs.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(60, 30, 60);
            dataGridViewSmurfs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 20, 60);
            dataGridViewSmurfs.ColumnHeadersDefaultCellStyle.ForeColor = Color.AntiqueWhite;
            dataGridViewSmurfs.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
            dataGridViewSmurfs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSmurfs.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 20, 60);
            dataGridViewSmurfs.RowHeadersDefaultCellStyle.ForeColor = Color.AntiqueWhite;
            dataGridViewSmurfs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSmurfs.AllowUserToResizeRows = false;
            dataGridViewSmurfs.RowTemplate.Height = 30;
            dataGridViewSmurfs.Location = new Point((this.ClientSize.Width - 900) / 2, 250);
            dataGridViewSmurfs.Size = new Size(900, 400);

            // Label styling
            var labels = new[] { lblName, lblHeight, lblDescription };
            foreach (var label in labels)
            {
                label.ForeColor = Color.AntiqueWhite;
                label.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
                label.BackColor = Color.Transparent;
            }

            // TextBox and ComboBox styling
            var textBoxes = new[] { txtName };
            foreach (var textBox in textBoxes)
            {
                textBox.BackColor = Color.FromArgb(70, 20, 70);
                textBox.ForeColor = Color.AntiqueWhite;
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
            }

            var comboBoxes = new[] { comboBoxDescription };
            foreach (var comboBox in comboBoxes)
            {
                comboBox.BackColor = Color.FromArgb(70, 20, 70);
                comboBox.ForeColor = Color.AntiqueWhite;
                comboBox.FlatStyle = FlatStyle.Flat;
                comboBox.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
            }

            // NumericUpDown styling
            numericHeight.BackColor = Color.FromArgb(70, 20, 70);
            numericHeight.ForeColor = Color.AntiqueWhite;
            numericHeight.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
            numericHeight.BorderStyle = BorderStyle.FixedSingle;

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
            dataGridViewSmurfs.AutoGenerateColumns = false;
            dataGridViewSmurfs.Columns.Clear();
            dataGridViewSmurfs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSmurfs.MultiSelect = false;

            // Add columns
            dataGridViewSmurfs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "colId",
                Visible = false
            });
            dataGridViewSmurfs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
                Name = "colName",
                Width = 250
            });
            dataGridViewSmurfs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Height",
                HeaderText = "Height",
                Name = "colHeight",
                Width = 150
            });
            dataGridViewSmurfs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Description",
                HeaderText = "Description",
                Name = "colDescription",
                Width = 250
            });

            dataGridViewSmurfs.SelectionChanged += DataGridViewSmurfs_SelectionChanged;
            dataGridViewSmurfs.DataBindingComplete += DataGridViewSmurfs_DataBindingComplete;
            dataGridViewSmurfs.KeyDown += HandleDeleteKey;
        }

        private void DataGridViewSmurfs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_selectedSmurf != null && dataGridViewSmurfs.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewSmurfs.Rows)
                {
                    if (row.DataBoundItem is Smurf smurf && smurf.Id == _selectedSmurf.Id)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void DataGridViewSmurfs_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSmurfs.SelectedRows.Count > 0)
            {
                _selectedSmurf = dataGridViewSmurfs.SelectedRows[0].DataBoundItem as Smurf;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                _selectedSmurf = null;
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
                    var smurf = (Smurf)grid.SelectedRows[0].DataBoundItem;

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
                        Text = $"Delete '{smurf.Name}'?",
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
                            LibraryManager.DeleteSmurf(smurf.Id);
                            ShowStyledMessage("Smurf deleted successfully.", "Success");
                            DisplaySmurfs();
                        }
                        catch (Exception ex)
                        {
                            ShowStyledMessage($"Error deleting smurf: {ex.Message}", "Error");
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                ShowStyledMessage("Please finish editing the current smurf before adding a new one.", "Information");
                return;
            }
            AddSmurf();
        }

        private void AddSmurf()
        {
            string name = txtName.Text;
            double height = (double)numericHeight.Value;
            SmurfDescription description = (SmurfDescription)comboBoxDescription.SelectedItem;

            if (string.IsNullOrWhiteSpace(name))
            {
                ShowStyledMessage("Please enter a valid name.", "Error");
                return;
            }

            try
            {
                LibraryManager.AddSmurf(name, height, description);
                ShowStyledMessage("Smurf added successfully!", "Success");
                ClearForm();

                if (dataGridViewSmurfs.Visible)
                {
                    DisplaySmurfs();
                }
            }
            catch (Exception ex)
            {
                ShowStyledMessage($"An error occurred: {ex.Message}", "Error");
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dataGridViewSmurfs.Visible = true;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            DisplaySmurfs();
        }

        private void DisplaySmurfs()
        {
            try
            {
                _smurfs = LibraryManager.GetAllSmurfs();
                dataGridViewSmurfs.DataSource = null;
                dataGridViewSmurfs.DataSource = _smurfs;
            }
            catch (Exception ex)
            {
                ShowStyledMessage($"An error occurred while loading smurfs: {ex.Message}", "Error");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedSmurf == null)
            {
                ShowStyledMessage("Please select a smurf to edit.", "Information");
                return;
            }

            _isEditing = true;
            txtName.Text = _selectedSmurf.Name;
            numericHeight.Value = (decimal)_selectedSmurf.Height;
            comboBoxDescription.SelectedItem = _selectedSmurf.Description;

            btnAdd.Enabled = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedSmurf == null) return;

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
                Text = $"Delete '{_selectedSmurf.Name}'?",
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
                    LibraryManager.DeleteSmurf(_selectedSmurf.Id);
                    ShowStyledMessage("Smurf deleted successfully.", "Success");
                    DisplaySmurfs();
                }
                catch (Exception ex)
                {
                    ShowStyledMessage($"Error deleting smurf: {ex.Message}", "Error");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedSmurf == null) return;

            string name = txtName.Text;
            double height = (double)numericHeight.Value;
            SmurfDescription description = (SmurfDescription)comboBoxDescription.SelectedItem;

            if (string.IsNullOrWhiteSpace(name))
            {
                ShowStyledMessage("Please enter a valid name.", "Error");
                return;
            }

            try
            {
                LibraryManager.UpdateSmurf(_selectedSmurf.Id, name, height, description);
                ShowStyledMessage("Smurf updated successfully!", "Success");

                ClearForm();
                DisplaySmurfs();
                EndEditing();
            }
            catch (Exception ex)
            {
                ShowStyledMessage($"An error occurred: {ex.Message}", "Error");
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            numericHeight.Value = 0;
            comboBoxDescription.SelectedIndex = 0;
        }

        private void EndEditing()
        {
            _isEditing = false;
            _selectedSmurf = null;
            btnAdd.Enabled = true;
            btnSave.Visible = false;
            ClearForm();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            dataGridViewSmurfs.Visible = false;
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

        private void txtName_TextChanged(object sender, EventArgs e) { }
        private void comboBoxDescription_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dataGridViewSmurfs_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void numericHeight_ValueChanged(object sender, EventArgs e) { }
    }
}