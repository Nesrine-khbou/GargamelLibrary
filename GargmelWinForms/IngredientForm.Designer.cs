namespace GargmelWinForms
{
    partial class IngredientsForm
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
            label1 = new Label();
            label2 = new Label();
            btnAdd = new Button();
            btnDisplay = new Button();
            label3 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            dataGridViewIngredients = new DataGridView();
            btnReturn = new Button();
            btnBack = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            txtType = new TextBox();
            txtLocation = new TextBox();
            txtColor = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngredients).BeginInit();
            SuspendLayout();

            // Label1 (Name)
            label1.AutoSize = true;
            label1.Location = new Point(46, 50);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Name";

            // Label2 (Type)
            label2.AutoSize = true;
            label2.Location = new Point(46, 90);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 1;
            label2.Text = "Type";

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

            // Label3 (Location)
            label3.AutoSize = true;
            label3.Location = new Point(46, 130);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 4;
            label3.Text = "Location";

            // Label4 (Color)
            label4.AutoSize = true;
            label4.Location = new Point(46, 170);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 5;
            label4.Text = "Color";

            // txtName
            txtName.Location = new Point(173, 47);
            txtName.Name = "txtName";
            txtName.Size = new Size(151, 27);
            txtName.TabIndex = 7;

            // dataGridViewIngredients
            dataGridViewIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIngredients.Location = new Point(0, 220);
            dataGridViewIngredients.Name = "dataGridViewIngredients";
            dataGridViewIngredients.RowHeadersWidth = 51;
            dataGridViewIngredients.Size = new Size(800, 400);
            dataGridViewIngredients.TabIndex = 8;
            dataGridViewIngredients.Visible = false;

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

            // btnEdit
            btnEdit.Location = new Point(550, 40);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 29);
            btnEdit.TabIndex = 11;
            btnEdit.Text = "Edit Selected";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            btnEdit.Visible = false;

            // btnDelete
            btnDelete.Location = new Point(550, 80);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 29);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete Selected";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            btnDelete.Visible = false;

            // btnSave
            btnSave.Location = new Point(550, 120);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 29);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save Changes";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            btnSave.Visible = false;

            // txtType
            txtType.Location = new Point(173, 87);
            txtType.Name = "txtType";
            txtType.Size = new Size(151, 27);
            txtType.TabIndex = 14;

            // txtLocation
            txtLocation.Location = new Point(173, 127);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(151, 27);
            txtLocation.TabIndex = 15;

            // txtColor
            txtColor.Location = new Point(173, 167);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(151, 27);
            txtColor.TabIndex = 16;

            // IngredientsForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 633);
            Controls.Add(txtColor);
            Controls.Add(txtLocation);
            Controls.Add(txtType);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnBack);
            Controls.Add(btnReturn);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnDisplay);
            Controls.Add(btnAdd);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewIngredients);
            Name = "IngredientsForm";
            Text = "Ingredients Management";
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngredients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnAdd;
        private Button btnDisplay;
        private Label label3;
        private Label label4;
        private TextBox txtName;
        private DataGridView dataGridViewIngredients;
        private Button btnReturn;
        private Button btnBack;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSave;
        private TextBox txtType;
        private TextBox txtLocation;
        private TextBox txtColor;
    }
}