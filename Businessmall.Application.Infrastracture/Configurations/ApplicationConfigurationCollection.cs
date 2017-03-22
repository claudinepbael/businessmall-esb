using Businessmall.Application.Infrastracture.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.Infrastracture.Configurations {
    public class ApplicationConfigurationCollection : ConfigurationElementCollection{

        public ApplicationConfiguration  this[int index]
        {
            get
            {
                return base.BaseGet(index) as ApplicationConfiguration;
            }
        }

        public new ApplicationConfiguration this[string key]
        {
            get
            {
                return base.BaseGet(key) as ApplicationConfiguration;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ApplicationConfiguration();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ApplicationConfiguration)element).Environment;
        }
    }
}
