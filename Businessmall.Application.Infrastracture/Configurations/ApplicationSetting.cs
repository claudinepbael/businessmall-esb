using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.Infrastracture.Configurations {
    public class ApplicationSetting : ConfigurationElement {

        const string KEY ="key";
        const string VALUE = "value";

        public string Key{
            get{
                return this[KEY].ToString();
            }
        }

        public string Value {
            get {
                return this[VALUE].ToString();
            }
        }
    }
}
