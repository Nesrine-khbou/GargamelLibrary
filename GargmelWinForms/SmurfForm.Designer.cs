namespace GargmelWinForms
{
    partial class SmurfForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(408, 126);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(408, 196);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "Display";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(115, 75);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 27);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(778, 12);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(10, 27);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(115, 268);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 82);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 5;
            label1.Text = "Name";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 177);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 6;
            label2.Text = "Height";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 276);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 7;
            label3.Text = "Description";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-1, -1);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(800, 450);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button3
            // 
            button3.Location = new Point(12, 12);
            button3.Name = "button3";
            button3.Size = new Size(35, 29);
            button3.TabIndex = 9;
            button3.Text = "<";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(778, 31);
            button4.Name = "button4";
            button4.Size = new Size(10, 10);
            button4.TabIndex = 10;
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(683, 398);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 11;
            button5.Text = "Return";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;

            // Modify Button
            btnModify = new Button();
            btnModify.Location = new Point(408, 266);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(94, 29);
            btnModify.TabIndex = 13;
            btnModify.Text = "Modify";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;

            // Delete Button
            btnDelete = new Button();
            btnDelete.Location = new Point(408, 336);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;


            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(115, 175);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(160, 27);
            numericUpDown1.TabIndex = 12;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // SmurfForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnModify);
            Controls.Add(btnDelete);
            Controls.Add(numericUpDown1);
            Name = "SmurfForm";
            Text = "SmurfForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button4;
        private Button button5;
        private NumericUpDown numericUpDown1;
        private Button btnModify;
        private Button btnDelete;
    }
}