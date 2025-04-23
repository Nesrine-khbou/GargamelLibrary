namespace GargmelWinForms
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbSerial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbMagicType = new System.Windows.Forms.ComboBox();
            this.dgvSpellBooks = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbNOR = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvRecipeBooks = new System.Windows.Forms.DataGridView();
            this.bAdd = new System.Windows.Forms.Button();
            this.bDisplay = new System.Windows.Forms.Button();
            this.ListBook = new System.Windows.Forms.DataGridView();
            this.btnShowSpellBooks = new System.Windows.Forms.Button();
            this.btnShowRecipeBooks = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnBackToWelcome = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvSpellBooks).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvRecipeBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.ListBook).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial :";
            // 
            // tbSerial
            // 
            this.tbSerial.Location = new System.Drawing.Point(101, 112);
            this.tbSerial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSerial.Name = "tbSerial";
            this.tbSerial.Size = new System.Drawing.Size(135, 27);
            this.tbSerial.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type : ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "SpellBook",
            "RecipeBook"});
            this.comboBox1.Location = new System.Drawing.Point(99, 43);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 28);
            this.comboBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Title :";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(99, 173);
            this.tbTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(139, 27);
            this.tbTitle.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Magic type : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbMagicType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(303, 43);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(341, 93);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spell Book";
            // 
            // cbMagicType
            // 
            this.cbMagicType.FormattingEnabled = true;
            this.cbMagicType.Location = new System.Drawing.Point(119, 25);
            this.cbMagicType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbMagicType.Name = "cbMagicType";
            this.cbMagicType.Size = new System.Drawing.Size(205, 28);
            this.cbMagicType.TabIndex = 9;
            // 
            // dgvSpellBooks
            // 
            this.dgvSpellBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpellBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpellBooks.Location = new System.Drawing.Point(0, 0);
            this.dgvSpellBooks.Name = "dgvSpellBooks";
            this.dgvSpellBooks.RowHeadersWidth = 51;
            this.dgvSpellBooks.Size = new System.Drawing.Size(758, 365);
            this.dgvSpellBooks.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbNOR);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(303, 177);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(341, 88);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recipe Book";
            // 
            // tbNOR
            // 
            this.tbNOR.Location = new System.Drawing.Point(157, 27);
            this.tbNOR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbNOR.Name = "tbNOR";
            this.tbNOR.Size = new System.Drawing.Size(78, 27);
            this.tbNOR.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Number Of Recipes :";
            // 
            // dgvRecipeBooks
            // 
            this.dgvRecipeBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipeBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecipeBooks.Location = new System.Drawing.Point(0, 0);
            this.dgvRecipeBooks.Name = "dgvRecipeBooks";
            this.dgvRecipeBooks.RowHeadersWidth = 51;
            this.dgvRecipeBooks.Size = new System.Drawing.Size(758, 365);
            this.dgvRecipeBooks.TabIndex = 17;
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(409, 316);
            this.bAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(128, 31);
            this.bAdd.TabIndex = 11;
            this.bAdd.Text = "Add ";
            this.bAdd.UseVisualStyleBackColor = true;
            // 
            // bDisplay
            // 
            this.bDisplay.Location = new System.Drawing.Point(560, 313);
            this.bDisplay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bDisplay.Name = "bDisplay";
            this.bDisplay.Size = new System.Drawing.Size(139, 33);
            this.bDisplay.TabIndex = 12;
            this.bDisplay.Text = "Display";
            this.bDisplay.UseVisualStyleBackColor = true;
            // 
            // ListBook
            // 
            this.ListBook.AllowUserToAddRows = false;
            this.ListBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBook.Location = new System.Drawing.Point(0, 0);
            this.ListBook.Name = "ListBook";
            this.ListBook.RowHeadersWidth = 51;
            this.ListBook.Size = new System.Drawing.Size(758, 365);
            this.ListBook.TabIndex = 13;
            // 
            // btnShowSpellBooks
            // 
            this.btnShowSpellBooks.Location = new System.Drawing.Point(652, 72);
            this.btnShowSpellBooks.Name = "btnShowSpellBooks";
            this.btnShowSpellBooks.Size = new System.Drawing.Size(180, 45);
            this.btnShowSpellBooks.TabIndex = 14;
            this.btnShowSpellBooks.Text = "Display SpellBook";
            this.btnShowSpellBooks.UseVisualStyleBackColor = true;
            // 
            // btnShowRecipeBooks
            // 
            this.btnShowRecipeBooks.Location = new System.Drawing.Point(652, 193);
            this.btnShowRecipeBooks.Name = "btnShowRecipeBooks";
            this.btnShowRecipeBooks.Size = new System.Drawing.Size(180, 45);
            this.btnShowRecipeBooks.TabIndex = 15;
            this.btnShowRecipeBooks.Text = "Display RecipeBook";
            this.btnShowRecipeBooks.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(28, 318);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(94, 29);
            this.btnReturn.TabIndex = 18;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            // 
            // btnBackToWelcome
            // 
            this.btnBackToWelcome.Location = new System.Drawing.Point(0, 0);
            this.btnBackToWelcome.Name = "btnBackToWelcome";
            this.btnBackToWelcome.Size = new System.Drawing.Size(35, 29);
            this.btnBackToWelcome.TabIndex = 19;
            this.btnBackToWelcome.Text = "<";
            this.btnBackToWelcome.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 365);
            this.Controls.Add(this.btnBackToWelcome);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.ListBook);
            this.Controls.Add(this.dgvSpellBooks);
            this.Controls.Add(this.dgvRecipeBooks);
            this.Controls.Add(this.btnShowRecipeBooks);
            this.Controls.Add(this.btnShowSpellBooks);
            this.Controls.Add(this.bDisplay);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSerial);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Gargmel Library";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvSpellBooks).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvRecipeBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.ListBook).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbMagicType;
        private System.Windows.Forms.TextBox tbNOR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bDisplay;
        private System.Windows.Forms.DataGridView ListBook;
        private System.Windows.Forms.Button btnShowSpellBooks;
        private System.Windows.Forms.Button btnShowRecipeBooks;
        private System.Windows.Forms.DataGridView dgvSpellBooks;
        private System.Windows.Forms.DataGridView dgvRecipeBooks;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnBackToWelcome;
    }
}