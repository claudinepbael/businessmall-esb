﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Businessmall.SB.Subscriber.Order.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=NB-BAEL-PH\\MSSQL2014;Initial Catalog=esb.businessmall;User ID=adminbm" +
            ";Password=admin")]
        public string BackOfficeDBConnection {
            get {
                return ((string)(this["BackOfficeDBConnection"]));
            }
            set {
                this["BackOfficeDBConnection"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=NB-BAEL-PH\\MSSQL2014;Initial Catalog=esb.shop;User ID=adminbm;Passwor" +
            "d=admin")]
        public string ShopDBConnection {
            get {
                return ((string)(this["ShopDBConnection"]));
            }
            set {
                this["ShopDBConnection"] = value;
            }
        }
    }
}
