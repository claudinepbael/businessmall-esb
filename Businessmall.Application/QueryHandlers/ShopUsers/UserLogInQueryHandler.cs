using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businessmall.Application.Infrastracture.Contracts;
using Businessmall.Application.Queries.ShopUser;
using Businessmall.Application.QueryResults.ShopUsers;
using Businessmall.Application.Infrastracture.Helpers;
namespace Businessmall.Application.QueryHandlers
{
    public class UserLogInQueryHandler:IQueryHandler<UserLoginQuery,LoggedInUser> {
        private IDataContext _dataContext;

        private IApplicationHelper _helper;

        public UserLogInQueryHandler (IDataContext context, IApplicationHelper helper){
            _dataContext = context;
            _helper = helper;
        }

        public LoggedInUser Retrieve(UserLoginQuery query){
          
            query._password = Encryptor.MD5Hash(query._password);
            return _dataContext.FindOne<UserLoginQuery,LoggedInUser>(GetSelectQuery(), query);
        }

        public string GetSelectQuery(){
           
            
            return AppDomain.CurrentDomain.GetResourceString("Businessmall.Application.SqlQueries.UserLoginQuery.sql");
        }


        
    }
}
