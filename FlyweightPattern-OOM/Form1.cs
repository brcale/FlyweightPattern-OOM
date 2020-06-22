using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace FlyweightPattern_OOM
{
    public partial class Form1 : Form
    {
        FlyweightFactory imageMap = new FlyweightFactory();
        public Form1()
        {
            InitializeComponent();
        }

        private void GetImage(short id)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (f.ShowDialog() == DialogResult.OK)
            {
                string directoryName = Path.GetFullPath(f.FileName);
                switch (id)
                {
                    case 1:
                        pictureBox1.Image = imageMap.GetImage(directoryName);
                        pictureBox1.Key = directoryName;
                        break;
                    case 2:
                        pictureBox2.Image = imageMap.GetImage(directoryName);
                        pictureBox2.Key = directoryName;
                        break;
                    case 3:
                        pictureBox3.Image = imageMap.GetImage(directoryName);
                        pictureBox3.Key = directoryName;
                        break;
                    case 4:
                        pictureBox4.Image = imageMap.GetImage(directoryName);
                        pictureBox4.Key = directoryName;
                        break;
                    case 5:
                        pictureBox5.Image = imageMap.GetImage(directoryName);
                        pictureBox5.Key = directoryName;
                        break;
                    case 6:
                        pictureBox6.Image = imageMap.GetImage(directoryName);
                        pictureBox6.Key = directoryName;
                        break;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GetImage(1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetImage(1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GetImage(2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetImage(2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            GetImage(3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetImage(3);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            GetImage(4);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetImage(4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            GetImage(5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetImage(5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            GetImage(6);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GetImage(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //clear button
            pictureBox1.Image = null;
            pictureBox1.Key = null;
            pictureBox2.Image = null;
            pictureBox2.Key = null;
            pictureBox3.Image = null;
            pictureBox3.Key = null;
            pictureBox4.Image = null;
            pictureBox4.Key = null;
            pictureBox5.Image = null;
            pictureBox5.Key = null;
            pictureBox6.Image = null;
            pictureBox6.Key = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //refresh button
            Cursor.Current = Cursors.WaitCursor;
            imageMap.Refresh();
            foreach (Control control in Controls)
            {
                KeyPictureBox pictureBox = control as KeyPictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = imageMap.GetImage(pictureBox.Key);
                }
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
