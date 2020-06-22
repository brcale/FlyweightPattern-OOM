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
        string iName;
        int flag=0;
        public Image getImage2(PictureBox picture)
        {
            Image value = null;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (f.ShowDialog() == DialogResult.OK)
            {
                value = Image.FromFile(f.FileName);
                iName = f.FileName;
                for (int i = 0; i < images.Count; i++)
                {
                    if (images.ContainsKey(iName))
                    {
                        flag = 1;
                        value = images[iName];
                        return value;
                    }
                }
                if (flag == 0)
                {
                    //value = imgfile;
                    images.Add(iName, value);
                    return value;
                }
            }
            //ovaj return se nece nikada izvrsiti
            return value;  
        }
    }
}
