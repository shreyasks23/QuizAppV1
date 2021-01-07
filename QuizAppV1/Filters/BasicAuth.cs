using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using QuizAppDAO;
using System.Linq;

namespace QuizAppV1.Filters
{
    public class BasicAuth : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null) {
                var authToken = actionContext.Request.Headers.Authorization.Parameter;

                var decodeAuthToken = System.Text.Encoding.UTF8.GetString(
                    Convert.FromBase64String(authToken));

                var userNameAndPasswordArr = decodeAuthToken.Split(':');

                if (IsAuthorizedUser(userNameAndPasswordArr[0], userNameAndPasswordArr[1])) {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userNameAndPasswordArr[0]), null);
                }
                else {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        private static bool IsAuthorizedUser(string userName, string password)
        {

            using (QuizAppEntities entities = new QuizAppEntities()) {
                return entities.Users.Any(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)
                && u.Password == password);
            }
        }
    }
}