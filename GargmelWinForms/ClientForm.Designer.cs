namespace GargmelWinForms
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblName = new Label();
            lblSpeciality = new Label();
            btnAdd = new Button();
            btnDisplay = new Button();
            lblLevel = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            txtName = new TextBox();
            dataGridViewClients = new DataGridView();
            btnReturn = new Button();
            btnBack = new Button();
            btnEditSelected = new Button();
            btnDeleteSelected = new Button();
            btnSaveChanges = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClients).BeginInit();
            SuspendLayout();

            // lblName
            lblName.AutoSize = true;
            lblName.Location = new Point(46, 50);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name";

            // lblSpeciality
            lblSpeciality.AutoSize = true;
            lblSpeciality.Location = new Point(46, 90);
            lblSpeciality.Name = "lblSpeciality";
            lblSpeciality.Size = new Size(73, 20);
            lblSpeciality.TabIndex = 1;
            lblSpeciality.Text = "Speciality";

            // btnAdd
            btnAdd.Location = new Point(421, 70);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            // btnDisplay
            btnDisplay.Location = new Point(421, 110);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(94, 29);
            btnDisplay.TabIndex = 3;
            btnDisplay.Text = "Display";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;

            // lblLevel
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(46, 130);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(108, 20);
            lblLevel.TabIndex = 4;
            lblLevel.Text = "Level Of Magic";

            // comboBox1
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(173, 87);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            // comboBox2
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(173, 127);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 6;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

            // txtName
            txtName.Location = new Point(173, 47);
            txtName.Name = "txtName";
            txtName.Size = new Size(151, 27);
            txtName.TabIndex = 7;
            txtName.TextChanged += txtName_TextChanged;

            // dataGridViewClients
            dataGridViewClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClients.Location = new Point(0, 180);
            dataGridViewClients.Name = "dataGridViewClients";
            dataGridViewClients.RowHeadersWidth = 51;
            dataGridViewClients.Size = new Size(800, 400);
            dataGridViewClients.TabIndex = 8;
            dataGridViewClients.CellContentClick += dataGridViewClients_CellContentClick;
            dataGridViewClients.Visible = false;

            // btnReturn
            btnReturn.Location = new Point(677, 580);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(94, 29);
            btnReturn.TabIndex = 9;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;

            // btnBack
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(36, 29);
            btnBack.TabIndex = 10;
            btnBack.Text = "<";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;

            // btnEditSelected
            btnEditSelected.Location = new Point(550, 40);
            btnEditSelected.Name = "btnEditSelected";
            btnEditSelected.Size = new Size(120, 29);
            btnEditSelected.TabIndex = 11;
            btnEditSelected.Text = "Edit Selected";
            btnEditSelected.UseVisualStyleBackColor = true;
            btnEditSelected.Click += btnEditSelected_Click;
            btnEditSelected.Visible = false;

            // btnDeleteSelected
            btnDeleteSelected.Location = new Point(550, 80);
            btnDeleteSelected.Name = "btnDeleteSelected";
            btnDeleteSelected.Size = new Size(120, 29);
            btnDeleteSelected.TabIndex = 12;
            btnDeleteSelected.Text = "Delete Selected";
            btnDeleteSelected.UseVisualStyleBackColor = true;
            btnDeleteSelected.Click += btnDeleteSelected_Click;
            btnDeleteSelected.Visible = false;

            // btnSaveChanges
            btnSaveChanges.Location = new Point(550, 120);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(120, 29);
            btnSaveChanges.TabIndex = 13;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            btnSaveChanges.Visible = false;

            // ClientForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 633);
            Controls.Add(btnSaveChanges);
            Controls.Add(btnDeleteSelected);
            Controls.Add(btnEditSelected);
            Controls.Add(btnBack);
            Controls.Add(btnReturn);
            Controls.Add(txtName);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(lblLevel);
            Controls.Add(btnDisplay);
            Controls.Add(btnAdd);
            Controls.Add(lblSpeciality);
            Controls.Add(lblName);
            Controls.Add(dataGridViewClients);
            Name = "ClientForm";
            Text = "ClientForm";
            Load += ClientForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewClients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblSpeciality;
        private Button btnAdd;
        private Button btnDisplay;
        private Label lblLevel;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private TextBox txtName;
        private DataGridView dataGridViewClients;
        private Button btnReturn;
        private Button btnBack;
        private Button btnEditSelected;
        private Button btnDeleteSelected;
        private Button btnSaveChanges;
    }
}