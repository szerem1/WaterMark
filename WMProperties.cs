using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WaterMark
{
	/// <summary>
	/// Customer class to be displayed in the property grid
	/// </summary>
	/// 
	[DefaultPropertyAttribute("TextPosition")]	
	public class WMProperties
	{		
		private		string								_copyright;		
		private		System.Drawing.ContentAlignment		_textposition;
		private		System.Drawing.Image				_copyrightimage;
		private		System.Drawing.ContentAlignment		_imageposition;
		private		System.Drawing.Font					_font;
		private		bool								_bestfitfontsize;



        

        //[CategoryAttribute("Copyright Tekst - Ustawienia"),
        //DisplayName("Copyright tekst"),
        //DescriptionAttribute("Twój copyright tekst..."), 
        //DefaultValueAttribute("Copyright © 2014 Konrad Wróbel")]
        //public		string		CopyrightText
        //{
        //    get
        //    {				
        //        return _copyright;
        //    }

        //    set
        //    {
        //        _copyright = value;
        //    }
        //}

        //[CategoryAttribute("Copyright Tekst - Ustawienia"), 
        //DisplayName("Pozycja tekstu"),
        //DescriptionAttribute("Copyright Tekst pozycja na obrazku."), 
        //DefaultValueAttribute(ContentAlignment.MiddleCenter)
        //]
        //public		ContentAlignment	TextPosition
        //{
        //    get
        //    {
        //        return _textposition;
        //    }

        //    set
        //    {
        //        _textposition = value;
        //    }
        //}

        //[CategoryAttribute("Copyright Tekst - Ustawienia"),
        //DisplayName("Czcionka"),
        //DescriptionAttribute("Copyright text font."),
        //DefaultValueAttribute(typeof(Font), "Arial, 18.0pt, style=Bold")]
        //public		System.Drawing.Font		Font
        //{
        //    get
        //    {
        //        return _font;
        //    }

        //    set
        //    {
        //        _font = value;
        //    }
        //}

        //[CategoryAttribute("Copyright Tekst - Ustawienia"), DescriptionAttribute("Copyright text font."), DefaultValueAttribute(true)]
        //[ReadOnly(true)]
        //public		bool		FontSizeBestFit
        //{
        //    get
        //    {
        //        return _bestfitfontsize;
        //    }

        //    set
        //    {
        //        _bestfitfontsize = value;
        //    }
        //}

        //[CategoryAttribute("Copyright Obraz - Ustawienia"), DescriptionAttribute("Copyright image."), DefaultValueAttribute(null)]
        //public System.Drawing.Image CopyrightImage
        //{
        //    get
        //    {
        //        return _copyrightimage;
        //    }

        //    set
        //    {
        //        _copyrightimage = value;
        //    }
        //}

        [CategoryAttribute("Obraz - Ustawienia"),  DefaultValueAttribute(ContentAlignment.TopRight)]
        public ContentAlignment ImagePosition
        {
            get
            {
                return _imageposition;
            }

            set
            {
                _imageposition = value;
            }
        }


		public WMProperties()
		{
		}

		public void setDefaultValues()
		{
			PropertyInfo[] props = this.GetType().GetProperties();
			for (int i=0; i<props.Length; i++)
			{
				object[] attrs = props[i].GetCustomAttributes(typeof(DefaultValueAttribute),false);
				if (attrs.Length > 0)
				{
					DefaultValueAttribute attr = (DefaultValueAttribute)attrs[0];
					props[i].SetValue(this,attr.Value,null);
				}
			}

		}
	}
}

