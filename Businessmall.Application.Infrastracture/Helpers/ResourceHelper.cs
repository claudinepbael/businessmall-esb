using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.Infrastracture.Helpers {
    public static class ResourceHelper {

         public static string GetResourceString (this AppDomain domains, string resourceName){
            var assemblies = domains.GetAssemblies();

            foreach( var assembly in assemblies){
                 using ( var resource  = assembly.GetManifestResourceStream(resourceName)){
                     if( resource == null)
                         continue;

                     using (var reader = new StreamReader (resource)){
                         return reader.ReadToEnd();
                     }
                 }
            }
            return string.Empty;

        }
    }
}
