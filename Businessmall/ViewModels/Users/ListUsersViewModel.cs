using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Businessmall.DTOs.Users;

namespace Businessmall.ViewModels.Users
{
    public class ListUsersViewModel
    {
        public List<ListUserItem> UsersList {get;set;}

        public ListUsersViewModel() {
            this.UsersList = new List<ListUserItem>();
            using (var context = new BusinessmallEntities())
            {
                var allUsersDetails = context.Users.ToList();
                foreach (User user in allUsersDetails){
                    this.UsersList.Add(
                        new ListUserItem{
                           FirstName = user.first_name,
                           LastName = user.last_name,
                           Username = user.username
                        } 
                    );
                }
            }
        }
    }
}