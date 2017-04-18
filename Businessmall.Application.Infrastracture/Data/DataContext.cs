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

         public void Execute<TParameter>(string command, TParameter parameter) where TParameter : ICommand
         {
             using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[defaultConnection].ConnectionString))
             {
                 try
                 {
                     connection.Open();
                     connection.Execute(command, parameter);
                     connection.Close();
                     connection.Dispose();
                 }
                 catch (Exception ex)
                 {
                     throw ex;
                 }
             }
         }

         public void Execute(string command)
         {
             using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[defaultConnection].ConnectionString))
             {
                 try
                 {
                     connection.Open();
                     connection.Execute(command);
                     connection.Close();
                     connection.Dispose();

                 }
                 catch (Exception ex)
                 {
                     throw ex;
                 }
             }
         }

         public TResult ExecuteWithResult<TParameter, TResult>(string command, TParameter parameter)
             where TParameter : ICommand
         {
             using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[defaultConnection].ConnectionString))
             {
                 try
                 {
                     connection.Open();
                     var result = connection.ExecuteScalar(command,parameter);
                         //Execute(command);
                     connection.Close();
                     connection.Dispose();
                     
                     return (TResult)result;
                 }
                 catch (Exception ex)
                 {
                     throw ex;
                 }
             }
         }

    }
}
