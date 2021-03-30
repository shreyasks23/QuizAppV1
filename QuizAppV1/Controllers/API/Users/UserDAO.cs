using System;
using System.Collections.Generic;
using System.Linq;
using QuizAppDAO;
using QuizAppV1.Helpers;
using User = QuizAppDAO.User;


namespace QuizAppV1.Controllers.Users
{
    public class UserDAO : IUserDAO
    {
        private readonly QuizAppEntities entities = new QuizAppEntities();

        public List<Models.User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (entities) {
                return entities.Users.Select(x => new Models.User {
                    UserID = x.UserID,
                    UserName = x.UserName,
                    Password = x.Password,
                    IsDeleted = (bool)x.Isdeleted
                }).ToList();
            }

        }
        public Models.User GetUser(int UserID)
        {
            using (entities) {
                var user = entities.Users.FirstOrDefault(u => u.UserID == UserID);

                if (user != null) {

                    return new Models.User {
                        UserID = user.UserID,
                        UserName = user.UserName,
                        Password = user.Password,
                        IsDeleted = (bool)user.Isdeleted
                    };
                }
                return null;
            }

        }

        public Models.User CreateUser(Models.User user)
        {
            using (entities) {
                User DBuser = new User() {
                    UserName = user.UserName,
                    Password = user.Password,
                    Isdeleted = user.IsDeleted
                };
                entities.Users.Add(DBuser);
                entities.SaveChanges();

                return new Models.User {
                    UserID = DBuser.UserID,
                    UserName = DBuser.UserName,
                    Password = DBuser.Password,
                    IsDeleted = (bool)DBuser.Isdeleted
                };
            }

        }

        public Models.User UpdateUser(int id, Models.User user)
        {
            if (id < 0) {
                return null;
            }
            else {
                using (entities) {
                    var dbUser = entities.Users.FirstOrDefault(u => u.UserID == id);

                    if (dbUser != null) {
                        dbUser.UserName = user.UserName;
                        dbUser.Password = user.Password;
                        dbUser.Isdeleted = user.IsDeleted;
                        entities.SaveChanges();

                        return new Models.User() {
                            UserID = dbUser.UserID,
                            UserName = dbUser.UserName,
                            Password = dbUser.Password,
                            IsDeleted = (bool)dbUser.Isdeleted
                        };
                    }
                    else {
                        return null;
                    }

                }
            }
        }

        public Models.User AuthenticatedUser(string userName, string password)
        {
            using (entities) {
                var user = entities.Users.Where(x => x.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) && x.Password == password).Select(u => new Models.User() {
                    UserName = u.UserName,
                    Password = u.Password,
                    IsDeleted = (bool)u.Isdeleted
                }).FirstOrDefault();

                if (user != null) {
                    return user.WithoutPassword();
                }
                else return null;
            }   

        }
    }
}