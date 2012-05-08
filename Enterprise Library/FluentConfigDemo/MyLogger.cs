using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace FluentConfigDemo
{
    public static class MyLogger
    {
        static MyLogger()
        {
            Initialize();
        }

        private static void Initialize()
        {
            var cfgBuilder = new ConfigurationSourceBuilder();

            cfgBuilder.ConfigureLogging().WithOptions
                .DoNotRevertImpersonation()
                .LogToCategoryNamed("EventLog")
                .SpecialSources.AllEventsCategory
                .SendTo.EventLog("Event Log Listener")
                .FormatWith(new FormatterBuilder()
                    .TextFormatterNamed("Text Formatter")
                    .UsingTemplate("時間: {timestamp}{newline}訊息: {message}{newline}訊息分類: {category}"))
                .ToLog("Application")
                .UsingEventLogSource("FluentConfigDemo");

            var configSource = new DictionaryConfigurationSource();
            cfgBuilder.UpdateConfigurationWithReplace(configSource);
            EnterpriseLibraryContainer.Current
              = EnterpriseLibraryContainer.CreateDefaultContainer(configSource);
        }

        public static void Write(string message, string category)
        {
            Logger.Write(message, category);
        }
    }
}