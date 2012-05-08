using System;
using System.Configuration;
using System.Reflection;

namespace MyLib
{
    public class AssemblySettings
    {
        private KeyValueConfigurationCollection _settings;

        public AssemblySettings(Assembly asmb)
        {
            LoadSettings(asmb);
        }

        private void LoadSettings(Assembly asmb)
        {
            ExeConfigurationFileMap cfgFileMap = new ExeConfigurationFileMap();
            Uri codeBaseUri = new Uri(asmb.CodeBase);
            cfgFileMap.ExeConfigFilename = codeBaseUri.AbsolutePath + ".config";

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(cfgFileMap, ConfigurationUserLevel.None);

            AppSettingsSection section = (config.GetSection("appSettings") as AppSettingsSection);
            if (section == null)
            {
                throw new Exception(String.Format("Section 'appSettings' not found in config '{0}'", config.FilePath));
            }
            _settings = section.Settings;
        }

        public string this[string key]
        {
            get
            {
                return _settings[key].Value;
            }
        }
    }
}