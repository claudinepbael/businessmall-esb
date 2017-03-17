using Businessmall.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Businessmall.Exceptions;
using Businessmall.Interfaces;
using Businessmall.Services;
using System.Web.Security;

namespace Businessmall.Repositories
{
    public partial class BusinessmallService : IBusinessmallService
    {
       

        public User AddUser(AddUserCommand addUserCommand)
        {
            User newlyAddedUser = GetNewUserInstance(addUserCommand);
            using (var db = new BusinessmallEntities())
            {
                db.Users.AddObject(newlyAddedUser);
                db.SaveChanges();
            }
            return newlyAddedUser;
        }

        public User GetNewUserInstance(AddUserCommand addUserCommand)
        {
            return new User
            {
                first_name = addUserCommand.FirstName,
                last_name = addUserCommand.LastName,
                username = addUserCommand.UserName,
                password = EncryptUserPassword(addUserCommand.Password),
                is_admin = true
                //TO-DO: add encryption of password
            };
        }

        public List<ListUserItem> GetListOfUsers() {
            List<ListUserItem> usersList = new List<ListUserItem>();
            return usersList;

        }

        public bool IsUserAuthorized(string username, string password, bool isAdmin)
        {

            User userToLogin = (from user in _dbContext.GetDBContext().Users
                                where user.username == username
                                select user).FirstOrDefault();
            if (userToLogin == null)
            {
                throw new InvalidLoginCredentialsException("Username not found");
            }

            string encryptedPassword = EncryptUserPassword(password);
               

            if (userToLogin.password != encryptedPassword)
            {
                throw new InvalidLoginCredentialsException("Invalid password");
            }

            if (isAdmin && userToLogin.is_admin != isAdmin)
            {
                throw new UnauthorizedAccessException();
            }


            return true;
        }

        public string EncryptUserPassword(string rawPassword)
        {
            return Encryptor.MD5Hash(rawPassword); ;
        }

        public void Login(LoginCommand loginCommand)
        {
            bool isAuthorized = false;
            try
            {
                isAuthorized = IsUserAuthorized(loginCommand.Username, loginCommand.Password, true);
            }
            catch (Exception e)
            {
                throw;
            }

            if (isAuthorized) {
                FormsAuthentication.SetAuthCookie(loginCommand.Username, false);
            }
            
        }
    }
}