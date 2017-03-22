using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.Infrastracture.Helpers {
    public class ApplicationHelper: IApplicationHelper {
        private object _lock = new object();

        private object _doubleLock = new object();

        private IDictionary<string, string> _cache;

        public ApplicationHelper()
        {
            _cache = new Dictionary<string, string>();
        }

        public string GetQuery(string sqlName)
        {

            if (_cache.ContainsKey(sqlName))
            {
                return _cache[sqlName];
            }

            lock (_lock)
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = string.Format("Businessmall.Application.SqlQueries.{0}", sqlName);

               
                var result = string.Empty;
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                        reader.Close();
                    }
                    stream.Close();
                }

                lock (_doubleLock)
                {
                    if (!_cache.ContainsKey(sqlName))
                    {
                        _cache.Add(sqlName, result);
                    }
                }
                return result;
            }
        }
    }
}
