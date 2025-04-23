using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLGargamelLibrary;

namespace GargmelWinForms
{
    public partial class ClientForm : Form
    {
        private Client _selectedClient = null;
        private bool _isEditing = false;
        private List<Client> _clients = new List<Client>();
        private Image _backgroundImage;

        public ClientForm()
        {
            InitializeComponent();
            this.Size = new Size(1000, 700);
            this.MinimumSize = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            LoadBackgroundImage();
            ApplySpookyTheme();
            comboBox1.DataSource = Enum.GetValues(typeof(Speciality));
            comboBox2.DataSource = Enum.GetValues(typeof(LevelOfMagic));
            ConfigureDataGridView();
            dataGridViewClients.Visible = false;
            btnReturn.BringToFront();
            btnEditSelected.Visible = false;
            btnDeleteSelected.Visible = false;
            btnSaveChanges.Visible = false;
        }

        private void LoadBackgroundImage()
        {
            try
            {
                _backgroundImage = Image.FromFile(@"E:\neeeeesss\2eme ing\2eme_semestre\net\GargamelLibrary1\GargamelLibrary1\client4.jpg");
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

            lblSpeciality.Location = new Point(50, 150);
            comboBox1.Location = new Point(200, 150);
            comboBox1.Size = new Size(200, 30);

            lblLevel.Location = new Point(50, 200);
            comboBox2.Location = new Point(200, 200);
            comboBox2.Size = new Size(200, 30);

            btnAdd.Location = new Point(450, 100);
            btnAdd.Size = new Size(150, 40);

            btnDisplay.Location = new Point(450, 150);
            btnDisplay.Size = new Size(150, 40);

            btnEditSelected.Location = new Point(650, 100);
            btnEditSelected.Size = new Size(200, 40);

            btnDeleteSelected.Location = new Point(650, 150);
            btnDeleteSelected.Size = new Size(200, 40);

            btnSaveChanges.Location = new Point(650, 200);
            btnSaveChanges.Size = new Size(200, 40);

            btnReturn.Location = new Point(50, 600);
            btnReturn.Size = new Size(150, 40);

            btnBack.Location = new Point(20, 20);
            btnBack.Size = new Size(40, 40);

            // DataGridView styling
            dataGridViewClients.EnableHeadersVisualStyles = false;
            dataGridViewClients.BackgroundColor = Color.FromArgb(40, 10, 40);
            dataGridViewClients.BorderStyle = BorderStyle.None;
            dataGridViewClients.GridColor = Color.FromArgb(70, 30, 70);
            dataGridViewClients.DefaultCellStyle.BackColor = Color.FromArgb(50, 20, 50);
            dataGridViewClients.DefaultCellStyle.ForeColor = Color.AntiqueWhite;
            dataGridViewClients.DefaultCellStyle.Font = new Font("Lucida Handwriting", 10);
            dataGridViewClients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 40, 90);
            dataGridViewClients.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewClients.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewClients.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(60, 30, 60);
            dataGridViewClients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 20, 60);
            dataGridViewClients.ColumnHeadersDefaultCellStyle.ForeColor = Color.AntiqueWhite;
            dataGridViewClients.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
            dataGridViewClients.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewClients.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 20, 60);
            dataGridViewClients.RowHeadersDefaultCellStyle.ForeColor = Color.AntiqueWhite;
            dataGridViewClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewClients.AllowUserToResizeRows = false;
            dataGridViewClients.RowTemplate.Height = 30;
            dataGridViewClients.Location = new Point((this.ClientSize.Width - 900) / 2, 250);
            dataGridViewClients.Size = new Size(900, 400);

            // Label styling
            var labels = new[] { lblName, lblSpeciality, lblLevel };
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

            var comboBoxes = new[] { comboBox1, comboBox2 };
            foreach (var comboBox in comboBoxes)
            {
                comboBox.BackColor = Color.FromArgb(70, 20, 70);
                comboBox.ForeColor = Color.AntiqueWhite;
                comboBox.FlatStyle = FlatStyle.Flat;
                comboBox.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
            }

            // Button styling
            var buttons = new[] { btnAdd, btnDisplay, btnEditSelected, btnDeleteSelected, btnSaveChanges, btnReturn, btnBack };
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
            dataGridViewClients.AutoGenerateColumns = false;
            dataGridViewClients.Columns.Clear();
            dataGridViewClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClients.MultiSelect = false;

            // Add columns
            dataGridViewClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "colId",
                Visible = false
            });
            dataGridViewClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
                Name = "colName",
                Width = 250
            });
            dataGridViewClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Speciality",
                HeaderText = "Speciality",
                Name = "colSpeciality",
                Width = 250
            });
            dataGridViewClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LevelOfMagic",
                HeaderText = "Level of Magic",
                Name = "colLevelOfMagic",
                Width = 250
            });

            dataGridViewClients.SelectionChanged += DataGridViewClients_SelectionChanged;
            dataGridViewClients.DataBindingComplete += DataGridViewClients_DataBindingComplete;
            dataGridViewClients.KeyDown += HandleDeleteKey;
        }

        private void DataGridViewClients_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_selectedClient != null && dataGridViewClients.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewClients.Rows)
                {
                    if (row.DataBoundItem is Client client && client.Id == _selectedClient.Id)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
        }

        private void DataGridViewClients_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewClients.SelectedRows.Count > 0)
            {
                _selectedClient = dataGridViewClients.SelectedRows[0].DataBoundItem as Client;
                btnEditSelected.Visible = true;
                btnDeleteSelected.Visible = true;
            }
            else
            {
                _selectedClient = null;
                btnEditSelected.Visible = false;
                btnDeleteSelected.Visible = false;
            }
        }

        private void HandleDeleteKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var grid = sender as DataGridView;
                if (grid?.SelectedRows.Count > 0)
                {
                    var client = (Client)grid.SelectedRows[0].DataBoundItem;

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
                        Text = $"Delete '{client.Name}'?",
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
                            LibraryManager.DeleteClient(client.Id);
                            ShowStyledMessage("Client deleted successfully.", "Success");
                            DisplayClients();
                        }
                        catch (Exception ex)
                        {
                            ShowStyledMessage($"Error deleting client: {ex.Message}", "Error");
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_isEditing)
            {
                ShowStyledMessage("Please finish editing the current client before adding a new one.", "Information");
                return;
            }
            AddClient();
        }

        private void AddClient()
        {
            string name = txtName.Text;
            Speciality speciality = (Speciality)comboBox1.SelectedItem;
            LevelOfMagic levelOfMagic = (LevelOfMagic)comboBox2.SelectedItem;

            if (string.IsNullOrWhiteSpace(name))
            {
                ShowStyledMessage("Please enter a valid name.", "Error");
                return;
            }

            try
            {
                LibraryManager.AddClient(name, speciality, levelOfMagic);
                ShowStyledMessage("Client added successfully!", "Success");
                ClearForm();

                if (dataGridViewClients.Visible)
                {
                    DisplayClients();
                }
            }
            catch (Exception ex)
            {
                ShowStyledMessage($"An error occurred: {ex.Message}", "Error");
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dataGridViewClients.Visible = true;
            btnEditSelected.Visible = false;
            btnDeleteSelected.Visible = false;
            btnSaveChanges.Visible = false;
            DisplayClients();
        }

        private void DisplayClients()
        {
            try
            {
                _clients = LibraryManager.GetAllClients();
                dataGridViewClients.DataSource = null;
                dataGridViewClients.DataSource = _clients;
            }
            catch (Exception ex)
            {
                ShowStyledMessage($"An error occurred while loading clients: {ex.Message}", "Error");
            }
        }

        private void btnEditSelected_Click(object sender, EventArgs e)
        {
            if (_selectedClient == null)
            {
                ShowStyledMessage("Please select a client to edit.", "Information");
                return;
            }

            _isEditing = true;
            txtName.Text = _selectedClient.Name;
            comboBox1.SelectedItem = _selectedClient.Speciality;
            comboBox2.SelectedItem = _selectedClient.LevelOfMagic;

            btnAdd.Enabled = false;
            btnEditSelected.Visible = false;
            btnDeleteSelected.Visible = false;
            btnSaveChanges.Visible = true;
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (_selectedClient == null) return;

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
                Text = $"Delete '{_selectedClient.Name}'?",
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
                    LibraryManager.DeleteClient(_selectedClient.Id);
                    ShowStyledMessage("Client deleted successfully.", "Success");
                    DisplayClients();
                }
                catch (Exception ex)
                {
                    ShowStyledMessage($"Error deleting client: {ex.Message}", "Error");
                }
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (_selectedClient == null) return;

            string name = txtName.Text;
            Speciality speciality = (Speciality)comboBox1.SelectedItem;
            LevelOfMagic levelOfMagic = (LevelOfMagic)comboBox2.SelectedItem;

            if (string.IsNullOrWhiteSpace(name))
            {
                ShowStyledMessage("Please enter a valid name.", "Error");
                return;
            }

            try
            {
                LibraryManager.UpdateClient(_selectedClient.Id, name, speciality, levelOfMagic);
                ShowStyledMessage("Client updated successfully!", "Success");

                ClearForm();
                DisplayClients();
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
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void EndEditing()
        {
            _isEditing = false;
            _selectedClient = null;
            btnAdd.Enabled = true;
            btnSaveChanges.Visible = false;
            ClearForm();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            dataGridViewClients.Visible = false;
            btnEditSelected.Visible = false;
            btnDeleteSelected.Visible = false;
            btnSaveChanges.Visible = false;
            EndEditing();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void ClientForm_Load(object sender, EventArgs e) { }
        private void dataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
