using System;
using System.Drawing;
using System.Windows.Forms;

namespace GargmelWinForms
{
    public partial class WelcomeForm : Form
    {
        private Image backgroundImage;

        public WelcomeForm()
        {
            InitializeComponent();
            LoadBackgroundImage();
            ApplySpookyTheme();
        }

        private void LoadBackgroundImage()
        {
            try
            {
                backgroundImage = Image.FromFile(@"E:\neeeeesss\2eme ing\2eme_semestre\net\GargamelLibrary1\GargamelLibrary1\bg1.jpg");
                this.BackgroundImage = backgroundImage;
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
            this.ForeColor = Color.GhostWhite;
            this.Font = new Font("Papyrus", 10, FontStyle.Regular);

            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.FromArgb(201, 57, 28); ;
            label1.Font = new Font("Old English Text MT", 18, FontStyle.Bold);
            label1.Text = "Welcome To Gargamel's Forbidden Library!";
            label1.AutoSize = true;
            label1.Location = new Point((this.ClientSize.Width - label1.Width) / 2, 60);

            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = Color.FromArgb(120, 70, 20, 70);
                    button.ForeColor = Color.AntiqueWhite;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.Black;
                    button.FlatAppearance.BorderSize = 2;
                    button.Font = new Font("Lucida Handwriting", 10, FontStyle.Bold);
                    button.Size = new Size(200, 45);
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
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (backgroundImage == null)
            {
                DrawCobweb(e.Graphics, new Point(10, 10), 40);
                DrawCobweb(e.Graphics, new Point(this.Width - 50, 10), 40);
                DrawCobweb(e.Graphics, new Point(10, this.Height - 50), 40);
                DrawCobweb(e.Graphics, new Point(this.Width - 50, this.Height - 50), 40);

                using (Pen magicPen = new Pen(Color.DarkRed, 2))
                {
                    e.Graphics.DrawEllipse(magicPen, this.Width / 2 - 120, this.Height / 2 - 120, 240, 240);
                }
                DrawPentagram(e.Graphics, this.Width / 2, this.Height / 2, 60);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, 0, 0, 0)), this.ClientRectangle);
            }
        }

        private void DrawCobweb(Graphics g, Point center, int size)
        {
            using (Pen webPen = new Pen(Color.Gray, 1))
            {
                for (int i = 0; i < 8; i++)
                {
                    double angle = i * Math.PI / 4;
                    int x = (int)(center.X + size * Math.Cos(angle));
                    int y = (int)(center.Y + size * Math.Sin(angle));
                    g.DrawLine(webPen, center.X, center.Y, x, y);
                }

                for (int r = 5; r < size; r += 5)
                {
                    List<Point> points = new List<Point>();
                    for (double angle = 0; angle < Math.PI * 2; angle += 0.1)
                    {
                        int x = (int)(center.X + r * Math.Cos(angle));
                        int y = (int)(center.Y + r * Math.Sin(angle));
                        points.Add(new Point(x, y));
                    }
                    if (points.Count > 1)
                    {
                        g.DrawLines(webPen, points.ToArray());
                    }
                }
            }
        }

        private void DrawPentagram(Graphics g, int centerX, int centerY, int radius)
        {
            Point[] points = new Point[5];
            for (int i = 0; i < 5; i++)
            {
                double angle = Math.PI / 2 + i * 2 * Math.PI / 5;
                points[i] = new Point(
                    (int)(centerX + radius * Math.Cos(angle)),
                    (int)(centerY - radius * Math.Sin(angle))
                );
            }

            using (Pen pentagramPen = new Pen(Color.Crimson, 2))
            {
                g.DrawLine(pentagramPen, points[0], points[2]);
                g.DrawLine(pentagramPen, points[2], points[4]);
                g.DrawLine(pentagramPen, points[4], points[1]);
                g.DrawLine(pentagramPen, points[1], points[3]);
                g.DrawLine(pentagramPen, points[3], points[0]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientForm ClientForm = new ClientForm();
            ClientForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SmurfForm SmurfForm = new SmurfForm();
            SmurfForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IngredientsForm ingredientForm = new IngredientsForm();
            ingredientForm.Show();
            this.Hide();
        }

    }
}