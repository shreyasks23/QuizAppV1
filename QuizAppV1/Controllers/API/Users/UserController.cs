using QuizAppV1.Controllers.Users;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using QuizAppV1.Filters;

namespace QuizAppV1.Controllers
{   
    
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        readonly UserDAO userDAO = new UserDAO();

        [BasicAuth]
        [HttpGet]
        [Route("")]
        public List<Models.User> GetAllUsers()
        {
            return userDAO.GetAllUsers();
        }
        [BasicAuth]
        [HttpGet]
        [Route("getUserById/{id}")]
        public HttpResponseMessage GetUser(int id)
        {

            var user = userDAO.GetUser(id);
            if (user == null) {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound) {
                    Content = new StringContent(string.Format("User with ID = {0} not found", id)),
                    ReasonPhrase = "User Not Found"
                };
                throw new HttpResponseException(response);
            }
            else {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
        }
        [BasicAuth]
        [HttpPost]
        [Route("createUser")]
        public HttpResponseMessage CreateUser([FromBody]Models.User user)
        {
            if (user == null) {
                var errRes = new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent("Provide user details")
                };
                throw new HttpResponseException(errRes);
            }
            else {
                var CreatedUser = userDAO.CreateUser(user);
                var response = Request.CreateResponse(HttpStatusCode.Created, CreatedUser);
                return response;
            }
        }
        [BasicAuth]
        [HttpPut]
        [Route("updateUser/{id}")]
        public HttpResponseMessage UpdateUser([FromUri]int id, [FromBody]Models.User user)
        {
            if(user == null) {
                var errRes = new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent("Provide user details")
                };
                throw new HttpResponseException(errRes);
            }
            else {
                var updatedUser = userDAO.UpdateUser(id, user);
                if(updatedUser == null) {
                    var errRes = new HttpResponseMessage(HttpStatusCode.NotFound) {
                        Content = new StringContent(string.Format("User with ID = {0} not found to update", id)),
                        ReasonPhrase = "User Not Found"
                    };
                    throw new HttpResponseException(errRes);
                }
                return Request.CreateResponse(HttpStatusCode.OK, updatedUser);
            }
        }

        //[HttpPost]
        //[Route("authenticate")]
        //public HttpResponseMessage Authenticate([FromBody] Models.AuthenticateModel authUser)
        //{
        //    var user = userDAO.AuthenticatedUser(authUser.Username, authUser.Password);

        //    if (user != null) {
        //        var response = new Models.AuthenticateModel() {
        //            Username = user.UserName,
        //            Password = user.Password
        //        };
        //        return Request.CreateResponse(HttpStatusCode.OK, response);
        //    }

        //    else {
        //        var errRes = new HttpResponseMessage(HttpStatusCode.BadRequest) {
        //            Content = new StringContent("Provide user details")
        //        };

        //        throw new HttpResponseException(errRes);
        //    } 
        //}

    }
}
