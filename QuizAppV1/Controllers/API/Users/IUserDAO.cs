using QuizAppDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppV1.Controllers.Users
{
    interface IUserDAO
    {
        List<Models.User> GetAllUsers();
        Models.User GetUser(int Id);
        Models.User CreateUser(Models.User user);
    }
}
