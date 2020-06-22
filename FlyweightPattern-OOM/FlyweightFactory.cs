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
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (f.ShowDialog() == DialogResult.OK)
            {
                string directoryName;
                directoryName = Path.GetFullPath(f.FileName);
                //console writeline napravljen radi testa, da vidim da li je path tocan
                Console.WriteLine("path to that current picture is: {0}", directoryName);
                if (images.ContainsKey(directoryName))
                {

                        return images[directoryName];
                }
                if (deleted)
                {
                    return null;
                }
                using (Image image = Image.FromFile(directoryName))
                {
                        Image value = new Bitmap(image);
                        images.Add(directoryName, value);
                        return value;
                }
            }
            //ovaj return se nece nikada izvrsiti
            return null;
        }

    }
}
