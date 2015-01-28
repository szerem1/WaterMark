using System.Drawing;

namespace WaterMark
{
    public class WatermarkPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public WatermarkPoint(WatermarkItem watermark)
            : this(watermark,800,600)
        {
        }

        public WatermarkPoint(WatermarkItem watermark, int phWidth, int phHeight)
        {
            int wmWidth = watermark.Image.Width;
            int wmHeight = watermark.Image.Height;

            switch (watermark.ContentAlignment)
            {
                case ContentAlignment.BottomCenter:
                    X = (phWidth / 2) - (wmWidth / 2);
                    Y = (phHeight - wmHeight) - 10;
                    break;

                case ContentAlignment.BottomLeft:
                    X = 10;
                    Y = (phHeight - wmHeight) - 10;
                    break;

                case ContentAlignment.BottomRight:
                    X = ((phWidth - wmWidth) - 10);
                    Y = (phHeight - wmHeight) - 10;
                    break;

                case ContentAlignment.MiddleCenter:
                    X = (phWidth / 2) - (wmWidth / 2);
                    Y = (phHeight / 2) - (wmHeight / 2);
                    break;

                case ContentAlignment.MiddleLeft:
                    X = 10;
                    Y = (phHeight / 2) - (wmHeight / 2);
                    break;

                case ContentAlignment.MiddleRight:
                    X = ((phWidth - wmWidth) - 10);
                    Y = (phHeight / 2) - (wmHeight / 2);
                    break;

                case ContentAlignment.TopCenter:
                    X = (phWidth / 2) - (wmWidth / 2);
                    Y = 10;
                    break;

                case ContentAlignment.TopLeft:
                    X = 10;
                    Y = 10;
                    break;

                case ContentAlignment.TopRight:
                    X = ((phWidth - wmWidth) - 10);
                    Y = 10;
                    break;
            }
        }
    }
}