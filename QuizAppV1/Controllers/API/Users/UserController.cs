using QuizAppV1.Controllers.Users;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;

namespace QuizAppV1.Controllers
{
    public class UserController : ApiController
    {
        readonly UserDAO userDAO = new UserDAO();

        public List<Models.User> GetAllUsers()
        {
            return userDAO.GetAllUsers();
        }

        public Models.User GetUser(int id)
        {
            return userDAO.GetUser(id);
        }

        [HttpPost]
        public HttpResponseMessage CreateUser([FromBody]Models.User user)
        {
            var CreatedUser = userDAO.CreateUser(user);
            var response =  Request.CreateResponse(System.Net.HttpStatusCode.Created, CreatedUser);
            return response;
        }

    }
}
