using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyweightPattern_OOM
{
    class FlyweightFactory
    {
        Dictionary<string, Image> images = new Dictionary<string, Image>();
        Image imgfile;
        public Image getImage2(PictureBox picture)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (f.ShowDialog() == DialogResult.OK)
            {
                imgfile = Image.FromFile(f.FileName);
                string iName = f.FileName;
                try
                {
                    File.Copy(iName, Path.Combine(@"D:\ImagesOOM", Path.GetFileName(iName)));
                }
                catch (Exception)
                {
                    MessageBox.Show("Picture already exists in internal memory!");
                }
                return imgfile;
            }
            else
            {
                return null;
            }
        }
    }
}
