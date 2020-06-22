using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FlyweightPattern_OOM
{
    class FlyweightFactory
    {
        private Dictionary<string, Image> images = new Dictionary<string, Image>();
        public Image GetImage(string key)
        {
            if (key == null)
                return null;
            if (images.ContainsKey(key))
            {
                return images[key];
            }
            using (Image image = Image.FromFile(key))
            {
                Image value = new Bitmap(image);
                images.Add(key, value);
                return value;
            }
        }
        public void Refresh()
        {
            short i = 0;
            foreach (var key in images.Keys)
            {
                if (!File.Exists(key))
                {
                    images.Remove(key);
                }
                else
                {
                    Bitmap currentBitmap = (Bitmap)images[key];
                    using (Image diskImage = Image.FromFile(key))
                    {
                        Bitmap diskBitmap = new Bitmap(diskImage);
                        if (!compareImages(currentBitmap, diskBitmap))
                        {
                            images[key] = diskBitmap;
                        }
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
                    Color pixel1 = i1.GetPixel(x, y);
                    Color pixel2 = i2.GetPixel(x, y);
                    if (pixel1 != pixel2)
                        return false;
                }

            }
            return true;
        }

    }
}
