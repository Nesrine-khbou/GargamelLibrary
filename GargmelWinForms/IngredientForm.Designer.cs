namespace GargmelWinForms
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvIngredients;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Button btnAddIngredient;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblColor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvIngredients = new DataGridView();
            txtName = new TextBox();
            txtType = new TextBox();
            txtLocation = new TextBox();
            txtColor = new TextBox();
            btnAddIngredient = new Button();
            lblName = new Label();
            lblType = new Label();
            lblLocation = new Label();
            lblColor = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvIngredients).BeginInit();
            SuspendLayout();
            // 
            // dgvIngredients
            // 
            dgvIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIngredients.Location = new Point(20, 180);
            dgvIngredients.Name = "dgvIngredients";
            dgvIngredients.RowHeadersWidth = 51;
            dgvIngredients.Size = new Size(400, 200);
            dgvIngredients.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(100, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 27);
            txtName.TabIndex = 1;
            // 
            // txtType
            // 
            txtType.Location = new Point(100, 50);
            txtType.Name = "txtType";
            txtType.Size = new Size(200, 27);
            txtType.TabIndex = 2;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(100, 80);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(200, 27);
            txtLocation.TabIndex = 3;
            // 
            // txtColor
            // 
            txtColor.Location = new Point(100, 110);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(200, 27);
            txtColor.TabIndex = 4;
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.Location = new Point(100, 140);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(100, 30);
            btnAddIngredient.TabIndex = 5;
            btnAddIngredient.Text = "Ajouter";
            btnAddIngredient.Click += btnAddIngredient_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 6;
            lblName.Text = "Nom :";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(20, 50);
            lblType.Name = "lblType";
            lblType.Size = new Size(47, 20);
            lblType.TabIndex = 7;
            lblType.Text = "Type :";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(20, 80);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(95, 20);
            lblLocation.TabIndex = 8;
            lblLocation.Text = "Localisation :";
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Location = new Point(20, 110);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(67, 20);
            lblColor.TabIndex = 9;
            lblColor.Text = "Couleur :";
            // 
            // button1
            // 
            button1.Location = new Point(-2, -2);
            button1.Name = "button1";
            button1.Size = new Size(27, 29);
            button1.TabIndex = 10;
            button1.Text = "<";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            ClientSize = new Size(450, 400);
            Controls.Add(button1);
            Controls.Add(dgvIngredients);
            Controls.Add(txtName);
            Controls.Add(txtType);
            Controls.Add(txtLocation);
            Controls.Add(txtColor);
            Controls.Add(btnAddIngredient);
            Controls.Add(lblName);
            Controls.Add(lblType);
            Controls.Add(lblLocation);
            Controls.Add(lblColor);
            Name = "Form2";
            Text = "Gestion des Ingrédients";
            ((System.ComponentModel.ISupportInitialize)dgvIngredients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button button1;
    }
}