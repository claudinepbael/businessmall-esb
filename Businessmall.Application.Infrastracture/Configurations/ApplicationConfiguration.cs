using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Businessmall.Application.Infrastracture.Configurations;
using Businessmall.Application.Infrastracture.Helpers;

namespace Businessmall.Application.Infrastracture.Constants {
    public class ApplicationConfiguration : ConfigurationElement  {

        //configuration naming

        const string CURRENT_ENVIRONMENT ="environment";
        const string DATABASE_CONNECTION_NAME = "databaseConnectionName";
       
        
        static ApplicationConfiguration() {
            lock (_sync) {
                Current = GetEnvironmentConfiguration(string.Empty);
            }
        }
        private ApplicationConfiguration InitializeWith (ApplicationConfigurationHandler configSection){
            _configSection = configSection;
            return this;
        }

        public static ApplicationConfiguration GetEnvironmentConfiguration (string key){
            var configSection = ApplicationConfigurationHandler.GetInstance();
            string selectedEnvironment = key.IsNullOrEmpty() ? configSection.ActiveEnvironment :key;

            return configSection.Environments[selectedEnvironment].InitializeWith(configSection);
        }
         private ApplicationConfigurationHandler _configSection;

        public static ApplicationConfiguration Current {get; private set; }

        static object _sync = new object();

        [ConfigurationProperty(CURRENT_ENVIRONMENT, IsRequired = true)]
        public string Environment {
            get {
                return this[CURRENT_ENVIRONMENT].ToString();
            }
        }

        [ConfigurationProperty(DATABASE_CONNECTION_NAME, IsRequired = true)]
        public string DatabaseConnectionStringName {
            get {
                return this[DATABASE_CONNECTION_NAME].ToString();
            }
        }
    }
}