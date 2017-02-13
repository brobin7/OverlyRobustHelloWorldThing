using System;
using System.Configuration;
using System.Diagnostics;
using HelloWorld.Interfaces;

namespace HelloWorld
{
    public class BasicApplicationSettings : ISqlCommunicationSettings
    {
        public string BasicTableConnectionString { get; } = GetConnectionString(Connection.BasicConnectionString);

        private static string GetConnectionString(string key)
        {
            return GetConfigValue(() => ConfigurationManager.AppSettings[key]);
        }

        protected static T GetConfigValue<T>(Func<T> getConfigurationValue)
        {
            Debug.Assert(getConfigurationValue != null, "getConfigurationValue != null");
            try
            {
                return getConfigurationValue();
            }
            catch (Exception exception)
            {
                throw new ConfigurationErrorsException("Invalid configuration", exception);
            }
        }
    }
}
