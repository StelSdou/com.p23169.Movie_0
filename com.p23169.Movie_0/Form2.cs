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
    public partial class Form2 : Form
    {
        Data Data;
        int current;
        internal Form2(Data d, int c)
        {
            InitializeComponent();
            Data = d;
            current = c;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Data.LPaths[current]);
        }
    }
}
