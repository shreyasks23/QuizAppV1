using QuizAppV1.Filters;
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
        [BasicAuth]
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

            var assessment = assessmentDAO.GetAssessment(ID);
            if(assessment == null)
            {
                var res = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Assessment with ID = {0} not found", ID)),
                    ReasonPhrase = "Assessment Not Found"
                };
                throw new HttpResponseException(res);
            }
            return assessment;
        }

        [HttpPost]
        [Route("addQuestionToAssessment")]
        public HttpResponseMessage AddQuestionsToAssessment([FromUri]int AssessmentID , int QuestionID)
        {
            var result = assessmentDAO.AddQuestionsToAssessment(AssessmentID, QuestionID);
            var response = Request.CreateResponse(HttpStatusCode.Created, result);
            return response;
        }

        [HttpPost]
        [Route("createAssessment")]
        public HttpResponseMessage CreateAssessment([FromBody] Models.Assessment assessment)
        {
            if(assessment == null)
            {
                var res = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Provide Assessment Details"))
                };
                throw new HttpResponseException(res);
            }

            var result = assessmentDAO.CreateAssessment(assessment);

            return Request.CreateResponse(HttpStatusCode.Created, result);
        }

        [HttpPut]
        [Route("updateAssessment")]
        public HttpResponseMessage UpdateAssessment([FromUri]int Id ,[FromBody]Models.Assessment assessment)
        {
            if(assessment == null)
            {
                var res = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Provide Assessment Details")),
                    ReasonPhrase = "Invalid details"
                };
                throw new HttpResponseException(res);
            }
            var result = assessmentDAO.UpdateAssessment(Id , assessment);

            return Request.CreateResponse(HttpStatusCode.Accepted, result);
        }
    }
}
 