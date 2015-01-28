using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WaterMark
{
    public class WatermarkItem
    {
        public Image Image { get; private set; }
        public ContentAlignment ContentAlignment { get; private set; }


        public WatermarkItem(string imagePath, ContentAlignment contentAlignment)
            : this(Image.FromFile(imagePath), contentAlignment)
        {
        }

        public WatermarkItem(Image image, ContentAlignment contentAlignment )
        {
            Image = image;
            ContentAlignment = contentAlignment;
        }
    }
}
