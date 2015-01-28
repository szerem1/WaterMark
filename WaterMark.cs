using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace WaterMark
{
    class WaterMark
    {
        string m_WorkingDirectory, m_Copyright;
        Image _ImgPhoto, m_ImgWatermark;
        private ImageFormat _ImgFormat;
        System.Drawing.ContentAlignment m_CopyrightPosition;
        System.Drawing.ContentAlignment m_ImagePosition;
        System.Drawing.Font m_CopyrightFont;


        public WaterMark(string ImgPhoto)
        {
            _ImgFormat = GetImageFormat(ImgPhoto);
            _ImgPhoto = Image.FromFile(ImgPhoto);
        }


        public WaterMark(string WorkingDirectory, string Copyright, System.Drawing.ContentAlignment CopyrightPos, System.Drawing.Font CopyrightFont, Image ImgWatermark, System.Drawing.ContentAlignment WaterMarkImagePos)
        {
            m_WorkingDirectory = WorkingDirectory;
            m_Copyright = Copyright;
            m_CopyrightPosition = CopyrightPos;
            m_CopyrightFont = CopyrightFont;
            m_ImgWatermark = ImgWatermark;
            m_ImagePosition = WaterMarkImagePos;
        }

        public WaterMark(string WorkingDirectory, string Copyright, System.Drawing.ContentAlignment CopyrightPos, System.Drawing.Font CopyrightFont)
        {
            m_WorkingDirectory = WorkingDirectory;
            m_Copyright = Copyright;
            m_CopyrightPosition = CopyrightPos;
            m_CopyrightFont = CopyrightFont;
            m_ImgWatermark = null;
        }

        public void SaveImage(List<WatermarkItem> watermarkCollection, string fileName)
        {

            //using (Stream inStream = new MemoryStream())
            using (Stream outStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] file = MarkImage(watermarkCollection);
                outStream.Write(file, 0, file.Length);
            }
        }

        public Image GetImage(List<WatermarkItem> watermarkCollection)
        {
            return Bitmap.FromStream(new MemoryStream(MarkImage(watermarkCollection)));
        }

        public byte[] MarkImage(List<WatermarkItem> watermarkCollection)
        {
            byte[] file = null;
            using (Stream inStream = new MemoryStream())

            using (Image image = resizeImage(_ImgPhoto, ScaleImage(_ImgPhoto, 640, 480)))
            {
                for (int i = 0; i < watermarkCollection.Count; i++)
                {
                    WatermarkItem item = watermarkCollection[i];

                    using (Image watermarkImage = item.Image)
                    using (Graphics imageGraphics = Graphics.FromImage(image))
                    using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
                    {
                        //item.Update(resizeImage(_ImgPhoto, ScaleImage(watermarkCollection[i].Image, 640 / 4, 480 / 4)));

                        WatermarkPoint point = new WatermarkPoint(watermarkCollection[i], image.Width, image.Height);
                        int x = point.X;
                        int y = point.Y;

                        watermarkBrush.TranslateTransform(x, y);
                        imageGraphics.FillRectangle(watermarkBrush,
                            new Rectangle(new Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));
                    }
                }

                image.Save(inStream, _ImgFormat);
                file = Helper.ToByteArray(inStream);
            }
            return file;
        }

        /// <summary>
        /// 4912x3264 
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>

        private Size GetNewSize(Image image)
        {
            bool isVertical = (image.Width < image.Height) ;
            int width = isVertical ? 640 : 480;
            int height =isVertical ? 480 : 640 ;
            return new Size(width, height);
        }

        public static Size ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            return new Size(newWidth, newHeight);
            //var newImage = new Bitmap(newWidth, newHeight);
            //Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            //return newImage;
        }


        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));

        }


        public Image MarkImage(List<WatermarkItem> watermarkCollection, int aa)
        {


            int phWidth = _ImgPhoto.Width;
            int phHeight = _ImgPhoto.Height;

            //create a Bitmap the Size of the original photograph
            Bitmap bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(_ImgPhoto.HorizontalResolution, _ImgPhoto.VerticalResolution);

            //load the Bitmap into a Graphics object 
            Graphics grPhoto = Graphics.FromImage(bmPhoto);


            //------------------------------------------------------------
            //Step #2 - Insert Watermark image
            //------------------------------------------------------------

            //Create a Bitmap based on the previously modified photograph Bitmap
            Bitmap bmWatermark = new Bitmap(bmPhoto);
            bmWatermark.SetResolution(_ImgPhoto.HorizontalResolution, _ImgPhoto.VerticalResolution);
            //Load this Bitmap into a new Graphic Object
            Graphics grWatermark = Graphics.FromImage(bmWatermark);

            //To achieve a transulcent watermark we will apply (2) color 
            //manipulations by defineing a ImageAttributes object and 
            //seting (2) of its properties.
            ImageAttributes imageAttributes = new ImageAttributes();

            ////The first step in manipulating the watermark image is to replace 
            ////the background color with one that is trasparent (Alpha=0, R=0, G=0, B=0)
            ////to do this we will use a Colormap and use this to define a RemapTable
            //ColorMap colorMap = new ColorMap();

            ////My watermark was defined with a background of 100% Green this will
            ////be the color we search for and replace with transparency
            //colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            //colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);

            //ColorMap[] remapTable = {colorMap};

            //imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            ////The second color manipulation is used to change the opacity of the 
            ////watermark.  This is done by applying a 5x5 matrix that contains the 
            ////coordinates for the RGBA space.  By setting the 3rd row and 3rd column 
            ////to 0.3f we achive a level of opacity
            //float[][] colorMatrixElements =
            //{
            //    new float[] {1.0f, 0.0f, 0.0f, 0.0f, 0.0f},
            //    new float[] {0.0f, 1.0f, 0.0f, 0.0f, 0.0f},
            //    new float[] {0.0f, 0.0f, 1.0f, 0.0f, 0.0f},
            //    new float[] {0.0f, 0.0f, 0.0f, 0.3f, 0.0f},
            //    new float[] {0.0f, 0.0f, 0.0f, 0.0f, 1.0f}
            //};
            //ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);

            //imageAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default,
            //    ColorAdjustType.Bitmap);




            foreach (WatermarkItem watermark in watermarkCollection)
            {

                //create a image object containing the watermark
                if (watermark != null)
                {
                    int wmWidth = watermark.Image.Width;
                    int wmHeight = watermark.Image.Height;

                    //For this example we will place the watermark in the upper right
                    //hand corner of the photograph. offset down 10 pixels and to the 
                    //left 10 pixles

                    int xPosOfWm = 0;
                    int yPosOfWm = 0;

                    switch (watermark.ContentAlignment)
                    {
                        case ContentAlignment.BottomCenter:
                            xPosOfWm = (phWidth / 2) - (wmWidth / 2);
                            yPosOfWm = (phHeight - wmHeight) - 10;
                            break;

                        case ContentAlignment.BottomLeft:
                            xPosOfWm = 10;
                            yPosOfWm = (phHeight - wmHeight) - 10;
                            break;

                        case ContentAlignment.BottomRight:
                            xPosOfWm = ((phWidth - wmWidth) - 10);
                            yPosOfWm = (phHeight - wmHeight) - 10;
                            break;

                        case ContentAlignment.MiddleCenter:
                            xPosOfWm = (phWidth / 2) - (wmWidth / 2);
                            yPosOfWm = (phHeight / 2) - (wmHeight / 2);
                            break;

                        case ContentAlignment.MiddleLeft:
                            xPosOfWm = 10;
                            yPosOfWm = (phHeight / 2) - (wmHeight / 2);
                            break;

                        case ContentAlignment.MiddleRight:
                            xPosOfWm = ((phWidth - wmWidth) - 10);
                            yPosOfWm = (phHeight / 2) - (wmHeight / 2);
                            break;

                        case ContentAlignment.TopCenter:
                            xPosOfWm = (phWidth / 2) - (wmWidth / 2);
                            yPosOfWm = 10;
                            break;

                        case ContentAlignment.TopLeft:
                            xPosOfWm = 10;
                            yPosOfWm = 10;
                            break;

                        case ContentAlignment.TopRight:
                            //For this example we will place the watermark in the upper right
                            //hand corner of the photograph. offset down 10 pixels and to the 
                            //left 10 pixles

                            xPosOfWm = ((phWidth - wmWidth) - 10);
                            yPosOfWm = 10;
                            break;

                    }

                    grWatermark.DrawImage(watermark.Image,
                        new Rectangle(xPosOfWm, yPosOfWm, wmWidth, wmHeight), //Set the detination Position
                        0, // x-coordinate of the portion of the source image to draw. 
                        0, // y-coordinate of the portion of the source image to draw. 
                        wmWidth, // Watermark Width
                        wmHeight, // Watermark Height
                        GraphicsUnit.Pixel, // Unit of measurment
                        imageAttributes); //ImageAttributes Object

                }
            }

            //Replace the original photgraphs bitmap with the new Bitmap
            _ImgPhoto = bmWatermark;
            //grPhoto.Dispose();
            //grWatermark.Dispose();
            //check file existence

            //byte[] result = null;
            //using (Stream inStream = new MemoryStream())
            //{         
            //    _ImgPhoto.Save(inStream, imageFormat);
            //    result = inStream.ToByteArray();
            //}
            _ImgPhoto.Save("AAAAAAAAAAAA.JPG", _ImgFormat);
            //_ImgPhoto.Dispose();
            return _ImgPhoto;

            //if (m_ImgWatermark != null) m_ImgWatermark.Dispose();
        }


        public void MarkImage(string srcPic, string dstPic)
        {
            _ImgPhoto = Image.FromFile(srcPic);

            int phWidth = _ImgPhoto.Width;
            int phHeight = _ImgPhoto.Height;

            //create a Bitmap the Size of the original photograph
            Bitmap bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(_ImgPhoto.HorizontalResolution, _ImgPhoto.VerticalResolution);

            //load the Bitmap into a Graphics object 
            Graphics grPhoto = Graphics.FromImage(bmPhoto);


            //------------------------------------------------------------
            //Step #1 - Insert m_Copyright message
            //------------------------------------------------------------

            //Set the rendering quality for this Graphics object
            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;

            //Draws the photo Image object at original size to the graphics object.
            grPhoto.DrawImage(
                _ImgPhoto,                               // Photo Image object
                new Rectangle(0, 0, phWidth, phHeight), // Rectangle structure
                0,                                      // x-coordinate of the portion of the source image to draw. 
                0,                                      // y-coordinate of the portion of the source image to draw. 
                phWidth,                                // Width of the portion of the source image to draw. 
                phHeight,                               // Height of the portion of the source image to draw. 
                GraphicsUnit.Pixel);                    // Units of measure 

            //-------------------------------------------------------
            //to maximize the size of the m_Copyright message we will 
            //test multiple Font sizes to determine the largest posible 
            //font we can use for the width of the Photograph
            //define an array of point sizes you would like to consider as possiblities
            //-------------------------------------------------------
            int[] sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };

            Font crFont = null;
            SizeF crSize = new SizeF();

            //Loop through the defined sizes checking the length of the m_Copyright string
            //If its length in pixles is less then the image width choose this Font size.
            for (int i = 0; i < 7; i++)
            {
                //set a Font object to our font object, size we will decide...
                crFont = new Font(m_CopyrightFont.Name, sizes[i], m_CopyrightFont.Style);

                //Measure the m_Copyright string in this Font
                crSize = grPhoto.MeasureString(m_Copyright, crFont);

                if ((ushort)crSize.Width < (ushort)phWidth)
                    break;
            }

            int yPixlesFromBottom = 0;
            float yPosFromBottom = 0;
            float xCenterOfImg = 0;

            switch (m_CopyrightPosition)
            {
                case ContentAlignment.BottomCenter:
                    //Since all photographs will have varying heights, determine a 
                    //position 5% from the bottom of the image
                    yPixlesFromBottom = (int)(phHeight * .05);

                    //Now that we have a point size use the m_Copyrights string height 
                    //to determine a y-coordinate to draw the string of the photograph
                    yPosFromBottom = ((phHeight - yPixlesFromBottom) - (crSize.Height / 2));

                    //Determine its x-coordinate by calculating the center of the width of the image
                    xCenterOfImg = (phWidth / 2);
                    break;

                case ContentAlignment.BottomLeft:
                    yPixlesFromBottom = (int)(phHeight * .05);
                    yPosFromBottom = ((phHeight - yPixlesFromBottom) - (crSize.Height / 2));
                    xCenterOfImg = (crSize.Width / 2) + 10;
                    break;

                case ContentAlignment.BottomRight:
                    yPixlesFromBottom = (int)(phHeight * .05);
                    yPosFromBottom = ((phHeight - yPixlesFromBottom) - (crSize.Height / 2));
                    xCenterOfImg = (phWidth - (crSize.Width / 2)) - 10;
                    break;

                case ContentAlignment.MiddleCenter:
                    yPixlesFromBottom = (int)(phHeight * .50);
                    yPosFromBottom = ((phHeight - yPixlesFromBottom) - (crSize.Height / 2));
                    xCenterOfImg = (phWidth / 2);
                    break;

                case ContentAlignment.MiddleLeft:
                    yPixlesFromBottom = (int)(phHeight * .50);
                    yPosFromBottom = ((phHeight - yPixlesFromBottom) - (crSize.Height / 2));
                    xCenterOfImg = (crSize.Width / 2) + 10;
                    break;

                case ContentAlignment.MiddleRight:
                    yPixlesFromBottom = (int)(phHeight * .50);
                    yPosFromBottom = ((phHeight - yPixlesFromBottom) - (crSize.Height / 2));
                    xCenterOfImg = (phWidth - (crSize.Width / 2)) - 10;
                    break;

                case ContentAlignment.TopCenter:
                    yPixlesFromBottom = (int)(phHeight * .95);
                    yPosFromBottom = ((phHeight - yPixlesFromBottom) - (crSize.Height / 2));
                    xCenterOfImg = (phWidth / 2);
                    break;

                case ContentAlignment.TopLeft:
                    yPixlesFromBottom = (int)(phHeight * .95);
                    yPosFromBottom = ((phHeight - yPixlesFromBottom) - (crSize.Height / 2));
                    xCenterOfImg = (crSize.Width / 2) + 10;
                    break;

                case ContentAlignment.TopRight:
                    yPixlesFromBottom = (int)(phHeight * .95);
                    yPosFromBottom = ((phHeight - yPixlesFromBottom) - (crSize.Height / 2));
                    xCenterOfImg = (phWidth - (crSize.Width / 2)) - 10;
                    break;

            }

            //Define the text layout by setting the text alignment to centered
            StringFormat StrFormat = new StringFormat();
            StrFormat.Alignment = StringAlignment.Center;

            //define a Brush which is semi trasparent black (Alpha set to 153)
            SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(153, 0, 0, 0));

            //Draw the m_Copyright string
            grPhoto.DrawString(m_Copyright,                 //string of text
                crFont,                                   //font
                semiTransBrush2,                           //Brush
                new PointF(xCenterOfImg + 1, yPosFromBottom + 1),  //Position
                StrFormat);

            //define a Brush which is semi trasparent white (Alpha set to 153)
            SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));

            //Draw the m_Copyright string a second time to create a shadow effect
            //Make sure to move this text 1 pixel to the right and down 1 pixel
            grPhoto.DrawString(m_Copyright,                 //string of text
                crFont,                                   //font
                semiTransBrush,                           //Brush
                new PointF(xCenterOfImg, yPosFromBottom),  //Position
                StrFormat);                               //Text alignment



            //------------------------------------------------------------
            //Step #2 - Insert Watermark image
            //------------------------------------------------------------

            //Create a Bitmap based on the previously modified photograph Bitmap
            Bitmap bmWatermark = new Bitmap(bmPhoto);
            bmWatermark.SetResolution(_ImgPhoto.HorizontalResolution, _ImgPhoto.VerticalResolution);
            //Load this Bitmap into a new Graphic Object
            Graphics grWatermark = Graphics.FromImage(bmWatermark);

            //To achieve a transulcent watermark we will apply (2) color 
            //manipulations by defineing a ImageAttributes object and 
            //seting (2) of its properties.
            ImageAttributes imageAttributes = new ImageAttributes();

            //The first step in manipulating the watermark image is to replace 
            //the background color with one that is trasparent (Alpha=0, R=0, G=0, B=0)
            //to do this we will use a Colormap and use this to define a RemapTable
            ColorMap colorMap = new ColorMap();

            //My watermark was defined with a background of 100% Green this will
            //be the color we search for and replace with transparency
            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);

            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            //The second color manipulation is used to change the opacity of the 
            //watermark.  This is done by applying a 5x5 matrix that contains the 
            //coordinates for the RGBA space.  By setting the 3rd row and 3rd column 
            //to 0.3f we achive a level of opacity
            float[][] colorMatrixElements = { 
												new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},       
												new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},        
												new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},        
												new float[] {0.0f,  0.0f,  0.0f,  0.3f, 0.0f},        
												new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}};
            ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);


            //create a image object containing the watermark
            if (m_ImgWatermark != null)
            {
                int wmWidth = m_ImgWatermark.Width;
                int wmHeight = m_ImgWatermark.Height;

                //For this example we will place the watermark in the upper right
                //hand corner of the photograph. offset down 10 pixels and to the 
                //left 10 pixles

                int xPosOfWm = 0;
                int yPosOfWm = 0;

                switch (m_ImagePosition)
                {
                    case ContentAlignment.BottomCenter:
                        xPosOfWm = (phWidth / 2) - (wmWidth / 2);
                        yPosOfWm = (phHeight - wmHeight) - 10;
                        break;

                    case ContentAlignment.BottomLeft:
                        xPosOfWm = 10;
                        yPosOfWm = (phHeight - wmHeight) - 10;
                        break;

                    case ContentAlignment.BottomRight:
                        xPosOfWm = ((phWidth - wmWidth) - 10);
                        yPosOfWm = (phHeight - wmHeight) - 10;
                        break;

                    case ContentAlignment.MiddleCenter:
                        xPosOfWm = (phWidth / 2) - (wmWidth / 2);
                        yPosOfWm = (phHeight / 2) - (wmHeight / 2);
                        break;

                    case ContentAlignment.MiddleLeft:
                        xPosOfWm = 10;
                        yPosOfWm = (phHeight / 2) - (wmHeight / 2);
                        break;

                    case ContentAlignment.MiddleRight:
                        xPosOfWm = ((phWidth - wmWidth) - 10);
                        yPosOfWm = (phHeight / 2) - (wmHeight / 2);
                        break;

                    case ContentAlignment.TopCenter:
                        xPosOfWm = (phWidth / 2) - (wmWidth / 2);
                        yPosOfWm = 10;
                        break;

                    case ContentAlignment.TopLeft:
                        xPosOfWm = 10;
                        yPosOfWm = 10;
                        break;

                    case ContentAlignment.TopRight:
                        //For this example we will place the watermark in the upper right
                        //hand corner of the photograph. offset down 10 pixels and to the 
                        //left 10 pixles

                        xPosOfWm = ((phWidth - wmWidth) - 10);
                        yPosOfWm = 10;
                        break;

                }

                grWatermark.DrawImage(m_ImgWatermark,
                    new Rectangle(xPosOfWm, yPosOfWm, wmWidth, wmHeight),  //Set the detination Position
                    0,                  // x-coordinate of the portion of the source image to draw. 
                    0,                  // y-coordinate of the portion of the source image to draw. 
                    wmWidth,            // Watermark Width
                    wmHeight,		    // Watermark Height
                    GraphicsUnit.Pixel, // Unit of measurment
                    imageAttributes);   //ImageAttributes Object

            }
            //Replace the original photgraphs bitmap with the new Bitmap
            _ImgPhoto = bmWatermark;
            grPhoto.Dispose();
            grWatermark.Dispose();

            //check file existence

            if (File.Exists(dstPic))
                File.Delete(dstPic);

            //save new image to file system.
            _ImgPhoto.Save(dstPic, GetImageFormat(srcPic));
            _ImgPhoto.Dispose();
            //if (m_ImgWatermark != null) m_ImgWatermark.Dispose();

        }





        public static ImageFormat GetImageFormat(string strFileName)
        {
            Console.WriteLine(strFileName.Substring(strFileName.LastIndexOf(".")));
            switch (strFileName.Substring(strFileName.LastIndexOf(".")).ToLower())
            {
                case ".bmp": return ImageFormat.Bmp;
                case ".jpg": return ImageFormat.Jpeg;
                case ".jpeg": return ImageFormat.Jpeg;
                default: return ImageFormat.Jpeg;
            }

        }
    }
}
