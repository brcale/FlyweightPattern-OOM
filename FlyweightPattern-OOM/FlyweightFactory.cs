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
        public Dictionary<string, Image> images = new Dictionary<string, Image>();
        Image imgfile;
        string directoryName;
        int flag=0;
        public Image getImage2(PictureBox picture)
        {
            Image value = null;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (f.ShowDialog() == DialogResult.OK)
            {
                value = Image.FromFile(f.FileName);
                directoryName = Path.GetFullPath(f.FileName);
                //console writeline napravljen radi testa, da vidim da li je path tocan
                Console.WriteLine("path to that current picture is: {0}", directoryName);
                for (int i = 0; i < images.Count; i++)
                {
                    if (images.ContainsKey(directoryName))
                    {
                        flag = 1;
                        value = images[directoryName];
                        return value;
                    }
                }
                if (flag == 0)
                {
                    //value = imgfile;
                    images.Add(directoryName, value);
                    foreach(var item in images)
                    {
                        Console.WriteLine(item.Key);
                    }
                    return value;
                }
            }
            //ovaj return se nece nikada izvrsiti
            return value;

        }
    }
}
