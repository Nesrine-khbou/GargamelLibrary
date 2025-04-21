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
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            textBox1 = new TextBox();
            dataGridViewClients = new DataGridView();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClients).BeginInit();
            SuspendLayout();

            // Label1 - Positioned below DataGridView
            label1.AutoSize = true;
            label1.Location = new Point(46, 430);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Name";

            // Label2
            label2.AutoSize = true;
            label2.Location = new Point(46, 470);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 1;
            label2.Text = "Speciality";

            // Button1 (Add)
            button1.Location = new Point(421, 450);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;

            // Button2 (Display)
            button2.Location = new Point(421, 490);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "Display";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;

            // Label3
            label3.AutoSize = true;
            label3.Location = new Point(46, 510);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 4;
            label3.Text = "Level Of Magic";
            label3.Click += label3_Click;

            // ComboBox1 (Speciality)
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(173, 467);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            // ComboBox2 (LevelOfMagic)
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(173, 507);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 6;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

            // TextBox1 (Name)
            textBox1.Location = new Point(173, 427);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(151, 27);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged;

            // DataGridView - Docked to top with specific height
            dataGridViewClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClients.Dock = DockStyle.Top;
            dataGridViewClients.Location = new Point(0, 0);
            dataGridViewClients.Name = "dataGridViewClients";
            dataGridViewClients.RowHeadersWidth = 51;
            dataGridViewClients.Size = new Size(800, 400);
            dataGridViewClients.TabIndex = 8;
            dataGridViewClients.CellContentClick += dataGridViewClients_CellContentClick;
            dataGridViewClients.Visible = false;

            // Button3 (Return)
            button3.Location = new Point(677, 580);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 9;
            button3.Text = "Return";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;

            // Button4 (Back)
            button4.Location = new Point(12, 12);
            button4.Name = "button4";
            button4.Size = new Size(36, 29);
            button4.TabIndex = 10;
            button4.Text = "<";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;

            // Button5 (Edit Selected)
            button5.Location = new Point(550, 420);
            button5.Name = "button5";
            button5.Size = new Size(120, 29);
            button5.TabIndex = 11;
            button5.Text = "Edit Selected";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            button5.Visible = false;

            // Button6 (Delete Selected)
            button6.Location = new Point(550, 460);
            button6.Name = "button6";
            button6.Size = new Size(120, 29);
            button6.TabIndex = 12;
            button6.Text = "Delete Selected";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            button6.Visible = false;

            // Button7 (Save Changes)
            button7.Location = new Point(550, 500);
            button7.Name = "button7";
            button7.Size = new Size(120, 29);
            button7.TabIndex = 13;
            button7.Text = "Save Changes";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            button7.Visible = false;

            // ClientForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 633);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewClients); // DataGridView added last so it's at the top
            Name = "ClientForm";
            Text = "ClientForm";
            Load += ClientForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewClients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Label label3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private TextBox textBox1;
        private DataGridView dataGridViewClients;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}