using System.Configuration;

namespace WaterMark
{
    public class AppConfig
    {



        public static string TopLeft_1 = ConfigurationManager.AppSettings["1"];
        public static string TopCenter_2 = ConfigurationManager.AppSettings["2"];
        public static string TopRight_3 = ConfigurationManager.AppSettings["3"];
        public static string MiddleLeft_4 = ConfigurationManager.AppSettings["4"];
        public static string MiddleCenter_5 = ConfigurationManager.AppSettings["5"];
        public static string MiddleRight_6 = ConfigurationManager.AppSettings["6"];
        public static string BottomLeft_7 = ConfigurationManager.AppSettings["7"];
        public static string BottomCenter_8 = ConfigurationManager.AppSettings["8"];
        public static string BottomRight_9 = ConfigurationManager.AppSettings["9"];
        public static string IN 
        {
            get { return  ConfigurationManager.AppSettings["IN"];}
            set { AddUpdateAppSettings("IN", value); }
        }
        public static string OUT
        {
            get { return ConfigurationManager.AppSettings["OUT"]; }
            set { AddUpdateAppSettings("OUT", value); }
        }

        public static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
             
            }
        }
    }
}