using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;

namespace PlayStream
{
    public class Config
    {
        public string lang { get; set; }

        public static TraceSource logger = new TraceSource("PlayStream");

        private static Config _instance;

        private Config() {
          
            InitDefaults();

        }

        public static Config GetInstance()
        {
            if (_instance == null) 
            {
                _instance = new Config();
            }
            return _instance;
        }

        public void InitDefaults()
        {
            lang = "es-ES";
        }

        public void Load()
        {

            logger.TraceEvent(TraceEventType.Information, 1, "Config: cargando configuración");

            lang = Read("lang");

            logger.TraceEvent(TraceEventType.Information, 1, "Config: idioma leído: '" + lang + "'");
        }

        private string Read(string key) 
        {
            return ConfigurationManager.AppSettings[key];
        }

        private void Write(Configuration configFile, string key, string value) 
        {
            var settings = configFile.AppSettings.Settings;

            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else 
            {
                settings[key].Value = value;
            }
        }

        public void save() 
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Write(configFile, "lang", lang);

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

    }
}
