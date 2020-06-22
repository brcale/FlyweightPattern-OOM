using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace FlyweightPattern_OOM
{
    public partial class Form1 : Form
    {
        FlyweightFactory image = new FlyweightFactory();
        short id;
        public Form1()
        {
            InitializeComponent();
        }

        private void getImage(short id, bool deleted=false)
        {
            switch (id) {
                case 1:
                pictureBox1.Image = image.getImage2(pictureBox1,deleted);
                    break;
                case 2:
                pictureBox2.Image = image.getImage2(pictureBox2,deleted);
                    break;
                case 3:
                    pictureBox3.Image = image.getImage2(pictureBox3,deleted);
                    break;
                case 4:
                    pictureBox4.Image = image.getImage2(pictureBox4,deleted);
                    break;
                case 5:
                    pictureBox5.Image = image.getImage2(pictureBox5, deleted);
                    break;
                case 6:
                    pictureBox6.Image = image.getImage2(pictureBox6,deleted);
                    break;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            getImage(1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getImage(1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            getImage(2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getImage(2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            getImage(3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getImage(3);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            getImage(4);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getImage(4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            getImage(5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getImage(5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            getImage(6);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            getImage(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //clear button
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //refresh button
            short i = 0;
            foreach (var item in image.images)
            {
                if (!File.Exists(item.Key))
                {
                    image.images.Remove(item.Key);
                    getImage(i, true);

                }
                else
                {
                    Bitmap i1 = new Bitmap(item.Value);
                    Image img1 = Image.FromFile(item.Key);
                    Bitmap i2 = new Bitmap(img1);
                    if (!compareImages(i1, i2))
                    {
                        image.images.Remove(item.Key);
                        image.images.Add(item.Key, img1);
                        refresh();
                    }

                }
                i++;
            }
        }
        private bool compareImages(Bitmap i1, Bitmap i2)
        {
            if (i1.Size != i2.Size)
                return false;
            for (int y = 0; y < i1.Height; y++)
            {
                for (int x = 0; x < i1.Width; x++)
                {
                    Color pixel1 = i1.GetPixel(x,y);
                    Color pixel2 = i2.GetPixel(x, y);
                    if (pixel1 != pixel2)
                        return false;
                }
               
            }
            return true;
        }
        public void refresh()
        {
            int i = 0;
            foreach(var item in image.images)
            {
                PictureBox[] boxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
                boxes[i].Image = item.Value;
                i++;
            }

        }
    }
}
