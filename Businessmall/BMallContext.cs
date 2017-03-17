using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Businessmall.Interfaces;
using Businessmall.Repositories;

namespace Businessmall
{
    /// <summary>
    /// Static factory for all implementation-specific dependencies.
    /// </summary>
    public static class BMallContext
    {
        public static Func<IDBContext> InProcessMallContext = () => DefaultBMallContextInstance;

        #region private members

        /// <summary>
        /// Ensures thread safety on a block of code.
        /// </summary>
        /// <param name="target"></param>
        private static void EnsureThreadSafety(Action target)
        {
            lock (synclock)
            {
                target();
            }
        }

        private static IDBContext _defaultBMallContextInstance = null;

        private static IDBContext DefaultBMallContextInstance
        {
            get
            {
                if (_defaultBMallContextInstance == null)
                    EnsureThreadSafety(() => _defaultBMallContextInstance = new DBContext());
                return new DBContext();
            }
        }


        private static object synclock = new object();

        #endregion
    }
}