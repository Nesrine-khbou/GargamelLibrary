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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDeleteIngredient;
        private System.Windows.Forms.Button btnClear;

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
            btnDeleteIngredient = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvIngredients).BeginInit();
            SuspendLayout();
            // 
            // dgvIngredients
            // 
            dgvIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIngredients.Location = new Point(20, 180);
            dgvIngredients.Name = "dgvIngredients";
            dgvIngredients.RowHeadersWidth = 51;
            dgvIngredients.Size = new Size(600, 250);
            dgvIngredients.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(120, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 27);
            txtName.TabIndex = 1;
            // 
            // txtType
            // 
            txtType.Location = new Point(120, 50);
            txtType.Name = "txtType";
            txtType.Size = new Size(250, 27);
            txtType.TabIndex = 2;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(120, 80);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(250, 27);
            txtLocation.TabIndex = 3;
            // 
            // txtColor
            // 
            txtColor.Location = new Point(120, 110);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(250, 27);
            txtColor.TabIndex = 4;
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.Location = new Point(120, 140);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(100, 30);
            btnAddIngredient.TabIndex = 5;
            btnAddIngredient.Text = "Add";
            btnAddIngredient.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 23);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 6;
            lblName.Text = "Name:";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(20, 53);
            lblType.Name = "lblType";
            lblType.Size = new Size(43, 20);
            lblType.TabIndex = 7;
            lblType.Text = "Type:";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(20, 83);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(69, 20);
            lblLocation.TabIndex = 8;
            lblLocation.Text = "Location:";
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Location = new Point(20, 113);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(48, 20);
            lblColor.TabIndex = 9;
            lblColor.Text = "Color:";
            // 
            // button1
            // 
            button1.Location = new Point(-2, -2);
            button1.Name = "button1";
            button1.Size = new Size(27, 29);
            button1.TabIndex = 10;
            button1.Text = "<";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnDeleteIngredient
            // 
            btnDeleteIngredient.Location = new Point(230, 140);
            btnDeleteIngredient.Name = "btnDeleteIngredient";
            btnDeleteIngredient.Size = new Size(100, 30);
            btnDeleteIngredient.TabIndex = 11;
            btnDeleteIngredient.Text = "Delete";
            btnDeleteIngredient.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(340, 140);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 30);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            ClientSize = new Size(650, 450);
            Controls.Add(btnClear);
            Controls.Add(btnDeleteIngredient);
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
            Text = "Ingredient Management";
            ((System.ComponentModel.ISupportInitialize)dgvIngredients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}