using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizAppV1.Controllers.Assessments
{
    public class AssessmentController : ApiController
    {
        private readonly AssessmentDAO assessmentDAO = new AssessmentDAO();

        [HttpGet]
        public List<Models.Assessment> GetAssessments()
        {            
            return assessmentDAO.GetAllAssessments().ToList();
        }

        [HttpGet]
        public Models.Assessment GetAssessment(int ID)
        {
            return assessmentDAO.GetAssessment(ID);
        }

        [HttpPost]
        public HttpResponseMessage AddQuestionsToAssessment([FromUri]int AssessmentID , int QuestionID)
        {
            var result = assessmentDAO.AddQuestionsToAssessment(AssessmentID, QuestionID);

            var response = Request.CreateResponse(HttpStatusCode.Created, result);

            return response;
        }
    }
}
