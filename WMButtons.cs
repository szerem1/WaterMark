using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace WaterMark
{
    public class WMButtons
    {
        public string BottomCenter_8 { get; set; }
        public string BottomLeft_7 { get; set; }
        public string BottomRight_9 { get; set; }
        public string MiddleCenter_5 { get; set; }
        public string MiddleLeft_4 { get; set; }
        public string MiddleRight_6 { get; set; }
        public string TopCenter_2 { get; set; }
        public string TopLeft_1 { get; set; }
        public string TopRight_3 { get; set; }


        public WMButtons()
        {
            setDefaultValues();
        }

        public void setDefaultValues()
        {
            TopLeft_1 = AppConfig.TopLeft_1;
            TopCenter_2 = AppConfig.TopCenter_2;
            TopRight_3 = AppConfig.TopRight_3;
            MiddleLeft_4 = AppConfig.MiddleLeft_4;
            MiddleCenter_5 = AppConfig.MiddleCenter_5;
            MiddleRight_6 = AppConfig.MiddleRight_6;
            BottomLeft_7 = AppConfig.BottomLeft_7;
            BottomCenter_8 = AppConfig.BottomCenter_8;
            BottomRight_9 = AppConfig.BottomRight_9;
        }


        public List<WatermarkItem> getWotermarks()
        {
            List<WatermarkItem> result = new List<WatermarkItem>();
            
            addIfOk(ref result, TopLeft_1, ContentAlignment.TopLeft);
            addIfOk(ref result, TopCenter_2, ContentAlignment.TopCenter);
            addIfOk(ref result, TopRight_3, ContentAlignment.TopRight);

            addIfOk(ref result, MiddleLeft_4, ContentAlignment.MiddleLeft);
            addIfOk(ref result, MiddleCenter_5, ContentAlignment.MiddleCenter);
            addIfOk(ref result, MiddleRight_6, ContentAlignment.MiddleRight);

            addIfOk(ref result, BottomLeft_7, ContentAlignment.BottomLeft);
            addIfOk(ref result, BottomCenter_8, ContentAlignment.BottomCenter);
            addIfOk(ref result, BottomRight_9, ContentAlignment.BottomRight);

            return result;
        }

        private void addIfOk(ref List<WatermarkItem> collection, string file, ContentAlignment alignment)
        {
            if (isOk(file)) collection.Add(new WatermarkItem(file, alignment));
        }

        private bool isOk(string file)
        {
            return !String.IsNullOrEmpty(file) && File.Exists(file);
        }
    }
}

