using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using QuizAppV1;
using QuizAppDAO;
using User = QuizAppDAO.User;
using System.Web.Http;

namespace QuizAppV1.Controllers.Users
{
    public class UserDAO : IUserDAO
    {


        public List<Models.User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (QuizAppEntities entities = new QuizAppEntities())
            {
                return entities.Users.Select(x => new Models.User
                {
                    UserID = x.UserID,
                    UserName = x.UserName,
                    Password = x.Password,
                    IsDeleted = (Boolean)x.Isdeleted
                }).ToList();                
            }

        }
        public Models.User GetUser(int UserID)
        {
            using (QuizAppEntities entities = new QuizAppEntities())
            {
                var user = entities.Users.FirstOrDefault(u => u.UserID == UserID);
                return new Models.User
                {
                    UserID = user.UserID,
                    UserName = user.UserName,
                    Password = user.Password,
                    IsDeleted = (Boolean)user.Isdeleted                  
                   
                }; 
            }           
        }
        
        public Models.User CreateUser(Models.User user)
        {
            using (QuizAppEntities entities = new QuizAppEntities())
            {
                QuizAppDAO.User DBuser = new User()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Isdeleted = user.IsDeleted
                };
                entities.Users.Add(DBuser);
                entities.SaveChanges();

                return new Models.User
                {
                    UserID = DBuser.UserID,
                    UserName = DBuser.UserName,
                    Password = DBuser.Password,
                    IsDeleted = (Boolean)DBuser.Isdeleted
                };
            }
            
        }
    }
}