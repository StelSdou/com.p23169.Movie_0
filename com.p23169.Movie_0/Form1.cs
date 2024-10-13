using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace com.p23169.Movie_0
{
    public partial class Form1 : Form
    {
        string path = @"img\movies\";
        private Data data;
        private int corrent = 0;
        public Form1()
        {
            data = new Data(path);
            InitializeComponent();
        }

        private List<PictureBox> pictureBoxes = new List<PictureBox>() { new PictureBox(), new PictureBox(), new PictureBox() };

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"img\arrowL.png");
            pictureBox2.Image = Image.FromFile(@"img\arrowR.png");

            label1.Text = data.LNames[corrent];

            label1.Click += new System.EventHandler(this.movie_Click);

            pictureBoxes[0].Click += new System.EventHandler(this.movie_Click);

            pictureBoxes[0].Dock = DockStyle.Fill;
            pictureBoxes[0].Image = Image.FromFile(data.LPaths[corrent]);
            pictureBoxes[0].SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxes[0].Cursor = Cursors.Hand;
            panel1.Controls.Add(pictureBoxes[0]);

            pictureBoxes[1].Dock = DockStyle.Fill;
            pictureBoxes[1].Image = Image.FromFile(data.LPaths[corrent+1]);
            pictureBoxes[1].SizeMode = PictureBoxSizeMode.Zoom;
            panel2.Controls.Add(pictureBoxes[1]);

            pictureBoxes[2].Dock = DockStyle.Fill;
            pictureBoxes[2].Image = Image.FromFile(data.LPaths[data.sum]);
            pictureBoxes[2].SizeMode = PictureBoxSizeMode.Zoom;
            panel3.Controls.Add(pictureBoxes[2]);
        }
        private void change(int cor)
        {
            if (cor > data.sum)
            {
                corrent = 0;
                cor = corrent;
            }else if (cor < 0)
            {
                corrent = data.sum;
                cor = corrent;
            }

            label1.Text = data.LNames[cor];
            if (cor == 0)
            {
                pictureBoxes[0].Image = Image.FromFile(data.LPaths[cor]);
                pictureBoxes[1].Image = Image.FromFile(data.LPaths[cor + 1]);
                pictureBoxes[2].Image = Image.FromFile(data.LPaths[data.sum]);
            }else if(cor == data.sum)
            {
                pictureBoxes[0].Image = Image.FromFile(data.LPaths[cor]);
                pictureBoxes[1].Image = Image.FromFile(data.LPaths[0]);
                pictureBoxes[2].Image = Image.FromFile(data.LPaths[cor - 1]);
            }
            else 
            {
                pictureBoxes[0].Image = Image.FromFile(data.LPaths[cor]);
                pictureBoxes[1].Image = Image.FromFile(data.LPaths[cor + 1]);
                pictureBoxes[2].Image = Image.FromFile(data.LPaths[cor - 1]);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            change(++corrent);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            change(--corrent);
        }

        private void movie_Click(object sender, EventArgs e)
        {
            Form2 movie = new Form2(data, corrent);
            movie.ShowDialog();
        }
    }
}
