using Businessmall.Application.Infrastracture.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmall.Application.Infrastracture.Contracts {
    public interface IDataContext {
        

        IList<TResult> Find<TResult>(string query) where TResult : IQueryResult;

        TResult FindOne<TParameter, TResult>(string query, TParameter parameter) where TResult : IQueryResult
            where TParameter : IQuery;

        IList<T> Query<TParameter, T>(string query, TParameter parameter);
        
        void Execute<TParameter>(string command, TParameter parameter) where TParameter : ICommand;

        void Execute(string command);

        TResult ExecuteWithReturn<TParameter, TResult>(string command, TParameter parameter)
            where TParameter : ICommand
            ;

        void SetDBName(string connection);
    }
}
