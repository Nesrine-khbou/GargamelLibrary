namespace GargmelWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tbSerial = new TextBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            tbTitle = new TextBox();
            label5 = new Label();
            groupBox1 = new GroupBox();
            cbMagicType = new ComboBox();
            dgvSpellBooks = new DataGridView();
            groupBox2 = new GroupBox();
            tbNOR = new TextBox();
            label6 = new Label();
            dgvRecipeBooks = new DataGridView();
            bAdd = new Button();
            bDisplay = new Button();
            ListBook = new DataGridView();
            btnShowSpellBooks = new Button();
            btnShowRecipeBooks = new Button();
            btnReturn = new Button();
            btnBackToWelcome = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSpellBooks).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecipeBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ListBook).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 123);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 0;
            label1.Text = "Serial :";
            // 
            // tbSerial
            // 
            tbSerial.Location = new Point(101, 112);
            tbSerial.Margin = new Padding(3, 4, 3, 4);
            tbSerial.Name = "tbSerial";
            tbSerial.Size = new Size(135, 27);
            tbSerial.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 47);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 2;
            label2.Text = "Type : ";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "SpellBook", "RecipeBook" });
            comboBox1.Location = new Point(99, 43);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(138, 28);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 176);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 4;
            label3.Text = "Title :";
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(99, 173);
            tbTitle.Margin = new Padding(3, 4, 3, 4);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(139, 27);
            tbTitle.TabIndex = 5;
            tbTitle.TextChanged += tbTitle_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 29);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 8;
            label5.Text = "Magic type : ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbMagicType);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(303, 43);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(341, 93);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Spell Book";
            // 
            // cbMagicType
            // 
            cbMagicType.FormattingEnabled = true;
            cbMagicType.Location = new Point(119, 25);
            cbMagicType.Margin = new Padding(3, 4, 3, 4);
            cbMagicType.Name = "cbMagicType";
            cbMagicType.Size = new Size(205, 28);
            cbMagicType.TabIndex = 9;
            cbMagicType.SelectedIndexChanged += cbMagicType_SelectedIndexChanged;
            // 
            // dgvSpellBooks
            // 
            dgvSpellBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSpellBooks.Dock = DockStyle.Fill;
            dgvSpellBooks.Location = new Point(0, 0);
            dgvSpellBooks.Name = "dgvSpellBooks";
            dgvSpellBooks.RowHeadersWidth = 51;
            dgvSpellBooks.Size = new Size(758, 365);
            dgvSpellBooks.TabIndex = 16;
            dgvSpellBooks.CellContentClick += dgvSpellBooks_CellContentClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tbNOR);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(303, 177);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(341, 88);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Recipe Book";
            // 
            // tbNOR
            // 
            tbNOR.Location = new Point(157, 27);
            tbNOR.Margin = new Padding(3, 4, 3, 4);
            tbNOR.Name = "tbNOR";
            tbNOR.Size = new Size(78, 27);
            tbNOR.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 32);
            label6.Name = "label6";
            label6.Size = new Size(145, 20);
            label6.TabIndex = 0;
            label6.Text = "Number Of Recipes :";
            // 
            // dgvRecipeBooks
            // 
            dgvRecipeBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecipeBooks.Dock = DockStyle.Fill;
            dgvRecipeBooks.Location = new Point(0, 0);
            dgvRecipeBooks.Name = "dgvRecipeBooks";
            dgvRecipeBooks.RowHeadersWidth = 51;
            dgvRecipeBooks.Size = new Size(758, 365);
            dgvRecipeBooks.TabIndex = 17;
            dgvRecipeBooks.CellContentClick += dgvRecipeBooks_CellContentClick;
            // 
            // bAdd
            // 
            bAdd.Location = new Point(409, 316);
            bAdd.Margin = new Padding(3, 4, 3, 4);
            bAdd.Name = "bAdd";
            bAdd.Size = new Size(128, 31);
            bAdd.TabIndex = 11;
            bAdd.Text = "Add ";
            bAdd.UseVisualStyleBackColor = true;
            bAdd.Click += bAdd_Click;
            // 
            // bDisplay
            // 
            bDisplay.Location = new Point(560, 313);
            bDisplay.Margin = new Padding(3, 4, 3, 4);
            bDisplay.Name = "bDisplay";
            bDisplay.Size = new Size(139, 33);
            bDisplay.TabIndex = 12;
            bDisplay.Text = "Display";
            bDisplay.UseVisualStyleBackColor = true;
            bDisplay.Click += bDisplay_Click;
            // 
            // ListBook
            // 
            ListBook.AllowUserToAddRows = false;
            ListBook.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListBook.Dock = DockStyle.Fill;
            ListBook.Location = new Point(0, 0);
            ListBook.Name = "ListBook";
            ListBook.RowHeadersWidth = 51;
            ListBook.Size = new Size(758, 365);
            ListBook.TabIndex = 13;
            ListBook.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnShowSpellBooks
            // 
            btnShowSpellBooks.Location = new Point(652, 72);
            btnShowSpellBooks.Name = "btnShowSpellBooks";
            btnShowSpellBooks.Size = new Size(94, 51);
            btnShowSpellBooks.TabIndex = 14;
            btnShowSpellBooks.Text = "Display SpellBook";
            btnShowSpellBooks.UseVisualStyleBackColor = true;
            btnShowSpellBooks.Click += button1_Click;
            // 
            // btnShowRecipeBooks
            // 
            btnShowRecipeBooks.Location = new Point(652, 193);
            btnShowRecipeBooks.Name = "btnShowRecipeBooks";
            btnShowRecipeBooks.Size = new Size(99, 53);
            btnShowRecipeBooks.TabIndex = 15;
            btnShowRecipeBooks.Text = "Display RecipeBook";
            btnShowRecipeBooks.UseVisualStyleBackColor = true;
            btnShowRecipeBooks.Click += btnShowRecipeBooks_Click;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(28, 318);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(94, 29);
            btnReturn.TabIndex = 18;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnBackToWelcome
            // 
            btnBackToWelcome.Location = new Point(0, 0);
            btnBackToWelcome.Name = "btnBackToWelcome";
            btnBackToWelcome.Size = new Size(35, 29);
            btnBackToWelcome.TabIndex = 19;
            btnBackToWelcome.Text = "<";
            btnBackToWelcome.UseVisualStyleBackColor = true;
            btnBackToWelcome.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 365);
            Controls.Add(btnBackToWelcome);
            Controls.Add(btnReturn);
            Controls.Add(ListBook);
            Controls.Add(dgvSpellBooks);
            Controls.Add(dgvRecipeBooks);
            Controls.Add(btnShowRecipeBooks);
            Controls.Add(btnShowSpellBooks);
            Controls.Add(bDisplay);
            Controls.Add(bAdd);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(tbTitle);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(tbSerial);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Gargmel Library";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSpellBooks).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecipeBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)ListBook).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbSerial;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private TextBox tbTitle;
        private Label label5;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox cbMagicType;
        private TextBox tbNOR;
        private Label label6;
        private Button bAdd;
        private Button bDisplay;
        private DataGridView ListBook;
        private Button btnShowSpellBooks;
        private Button btnShowRecipeBooks;
        private DataGridView dgvSpellBooks;
        private DataGridView dgvRecipeBooks;
        private Button btnReturn;
        private Button btnBackToWelcome;
    }
}