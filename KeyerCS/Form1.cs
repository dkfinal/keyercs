using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyerCS
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = ofd.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap input = new Bitmap(tbPath.Text);
            Bitmap output = new Bitmap(input.Width, input.Height);
            for (int y = 0; y < output.Height; y++) {
                for (int x = 0; x < output.Width; x++) {
                    Color color = input.GetPixel(x, y);
                    byte max = Math.Max(Math.Max(color.R, color.G), color.B);
                    byte min = Math.Min(Math.Min(color.R, color.G), color.B);
                    if (color.G != min && (color.G == max || max - color.G < 10) && (max - min) > 50) {
                        output.SetPixel(x, y, Color.Transparent);
                    }
                    else {
                        output.SetPixel(x, y, color);
                    }
                }
            }
            Image img = output;
            img.Save(tbPath.Text.Substring(0, tbPath.Text.LastIndexOf('.')) + "_RESULT.png");
        }

        private Color CustomColor(int r, int g, int b, int a = 255)
        {
            Color color = Color.FromArgb(a, r, g, b);
            return color;
        }
    }
}
