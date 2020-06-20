using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void getImage(short id)
        {
            switch (id) {
                case 1:
                pictureBox1.Image = image.getImage2(pictureBox1);
                    break;
                case 2:
                pictureBox2.Image = image.getImage2(pictureBox2);
                    break;
                case 3:
                    pictureBox3.Image = image.getImage2(pictureBox3);
                    break;
                case 4:
                    pictureBox4.Image = image.getImage2(pictureBox4);
                    break;
                case 5:
                    pictureBox5.Image = image.getImage2(pictureBox5);
                    break;
                case 6:
                    pictureBox6.Image = image.getImage2(pictureBox6);
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

        private void button9_Click(object sender, EventArgs e)
        {
            //memory open button
            if (Directory.Exists(@"D:\ImagesOOM"))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = @"D:\ImagesOOM",
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
            else
            {
                MessageBox.Show(string.Format("{0} directory does not exist!", @"D:\ImagesOOM"));
            }
        }
    }
}
