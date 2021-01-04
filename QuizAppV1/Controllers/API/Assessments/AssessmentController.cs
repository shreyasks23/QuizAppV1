using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizAppV1.Controllers.Assessments
{
    [RoutePrefix("api/assessments")]
    public class AssessmentController : ApiController
    {
        private readonly AssessmentDAO assessmentDAO = new AssessmentDAO();

        [HttpGet]
        [Route("")]
        public List<Models.Assessment> GetAssessments()
        {            
            return assessmentDAO.GetAllAssessments().ToList();
        }

        [HttpGet]
        [Route("getAssessmentById")]
        public Models.Assessment GetAssessment([FromUri] int ID)
        {
            return assessmentDAO.GetAssessment(ID);
        }

        [HttpPost]
        [Route("addQuestionToAssessment")]
        public HttpResponseMessage AddQuestionsToAssessment([FromUri]int AssessmentID , int QuestionID)
        {
            var result = assessmentDAO.AddQuestionsToAssessment(AssessmentID, QuestionID);
            var response = Request.CreateResponse(HttpStatusCode.Created, result);
            return response;
        }
    }
}
