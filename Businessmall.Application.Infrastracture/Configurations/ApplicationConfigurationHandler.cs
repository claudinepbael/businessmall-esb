using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.Infrastracture.Configurations {
    public class ApplicationConfigurationHandler : ConfigurationSection {

        const string WEBSHOPCONFIGURATION_KEY ="webshop-setting";
        const string ACTIVE_ENVIRONMENT = "activeEnvironment";
        const string ENVIRONMENT ="environments";

        public static ApplicationConfigurationHandler GetInstance(){
            return (ApplicationConfigurationHandler)ConfigurationManager.GetSection(WEBSHOPCONFIGURATION_KEY)  ;
        }

        [ConfigurationProperty(ACTIVE_ENVIRONMENT,IsRequired = true)]
        public string ActiveEnvironment{
            get{ return base[ACTIVE_ENVIRONMENT].ToString();}
            set{ base[ACTIVE_ENVIRONMENT] = value;}
        }

        [ConfigurationProperty(ENVIRONMENT,IsRequired = true)]
        public ApplicationConfigurationCollection Environments {
            get{
                return base[ENVIRONMENT] as ApplicationConfigurationCollection;
            }
            
        }


    }
}
