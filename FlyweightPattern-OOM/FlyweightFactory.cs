using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FlyweightPattern_OOM
{
    class FlyweightFactory
    {
        public Dictionary<string, Image> images = new Dictionary<string, Image>();
        public Image getImage2(PictureBox picture, bool deleted = false)
        {
            int flag = 0;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (f.ShowDialog() == DialogResult.OK)
            {
                string directoryName;
                Image value = null;
                directoryName = Path.GetFullPath(f.FileName);
                //console writeline napravljen radi testa, da vidim da li je path tocan
                Console.WriteLine("path to that current picture is: {0}", directoryName);
                if (images.ContainsKey(directoryName))
                {
                        flag = 1;
                        value = images[directoryName];
                        return value;
                }
                if (deleted)
                {
                    return null;
                }
                value = Image.FromFile(f.FileName);
                if (flag == 0)
                {
                    using (Image image = Image.FromFile(directoryName))
                    {
                        value = new Bitmap(image);
                        images.Add(directoryName, value);
                        return value;
                    }
                }
            }
            //ovaj return se nece nikada izvrsiti
            return null;
        }

    }
}
