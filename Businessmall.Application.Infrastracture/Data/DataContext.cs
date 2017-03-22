using Businessmall.Application.Infrastracture.Constants;
using Businessmall.Application.Infrastracture.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;

namespace Businessmall.Application.Infrastracture.Data {

     public class DataContext:IDataContext {
         private string defaultConnection = ApplicationConfiguration.Current.DatabaseConnectionStringName;
          public void SetDBName(string dbConnection){
            defaultConnection = dbConnection;
        }

        public IList<TResult> Find<TResult>(string query) where TResult:IQueryResult{
            using (var connection = new SqlConnection (ConfigurationManager.ConnectionStrings[defaultConnection].ConnectionString)){
                try{
                    if(connection.State == ConnectionState.Closed){
                        connection.Open();
                    }
                    return connection.Query<TResult>(query).ToList();
                }catch(Exception e){
                    throw e;
                }finally{
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public IList<T> Query<TParameter, T>(string query,TParameter parameter){
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[defaultConnection].ConnectionString)){
                try{
                    if(connection.State == ConnectionState.Closed){
                        connection.Open();
                    }
                    return connection.Query<T>(query,parameter).ToList();
                }catch(Exception e){
                    throw e;
                }finally{
                    connection.Close();
                    connection.Dispose();
                }

            }
        }


         public TResult FindOne<TParameter, TResult> (string query, TParameter parameter) where TParameter: IQuery where TResult:IQueryResult{
             using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[defaultConnection].ConnectionString)){
                 try{
                     if(connection.State == ConnectionState.Closed){
                         connection.Open();
                     }
                     var result = connection.Query<TResult>(query,parameter).ToList();

                     return result.FirstOrDefault();
                 }catch(Exception e){
                     throw e;
                 }finally{
                    connection.Close();
                    connection.Dispose();
                        

                 }
             }
         }
    }
}
