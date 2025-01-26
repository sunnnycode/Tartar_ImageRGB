using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRGB
{
    public partial class Form1 : Form
    {
        double ToothPixelCount;
        double TartarPixelCount;
        double result;

        public Form1()
        {

            InitializeComponent();
            
        }


        private Bitmap PictureBoxReset()

        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        
            Bitmap tmp = pictureBox1.Image as Bitmap;

            //픽셀정보를 알아오기 위하여 비트맵을 얻어온다.         

            return tmp;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap tmp = PictureBoxReset();



            int width = tmp.Width;

            int height = tmp.Height;



            Color colorData;

            for (int i = 0; i < width; i++)

            {

                for (int j = 0; j < height; j++)

                {

                    colorData = tmp.GetPixel(i, j);

                    RColorConvert(ref colorData);

                    tmp.SetPixel(i, j, colorData);

                }

            }
            result = (TartarPixelCount / (ToothPixelCount + TartarPixelCount)) * 100;
            label7.Text = (Math.Round(result, 1)).ToString() + "%";

            if (result < 0.5)
                label8.Text = "0단계";
            else if (result < 3)
                label8.Text = "1단계";
            else if (result < 8)
                label8.Text = "2단계";
            else
                label8.Text = "3단계";

        }

        private void RColorConvert(ref Color src)

        {

            /* 
            if (src.R < 70)
            {

                int res = (src.R + src.G + src.B) / 3;

                src = Color.FromArgb(res, res, res);

            }
            */
            if (src.B > 85)
            {
                src = Color.FromArgb(255, 255, 255);
                ToothPixelCount++;
            }

            else if (src.G > 130)
            {
                src = Color.FromArgb(255, 51, 153);
                TartarPixelCount++;
            }
            else
            {

                int res = (src.R + src.G + src.B) / 3;

                src = Color.FromArgb(res, res, res);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
