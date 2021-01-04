using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuizAppV1.Models;


namespace QuizAppV1.Controllers.Questions
{
    [RoutePrefix("api/questions")]
    public class QuestionController : ApiController
    {
         QuestionDAO QuestionsDAO = new QuestionDAO();

        [Route("")]
        public List<Question> GetQuestions()
        {
            return QuestionsDAO.GetQuestions().ToList();
        }

        [Route("getQuestion/{id}")]
        public Question GetQuestion(int ID)
        {
            return QuestionsDAO.GetQuestion(ID);
        }
        [Route("createQuestion")]
        [HttpPost]
        public HttpResponseMessage CreateQuestion([FromBody]Models.Question question)
        {
            var createdUser = QuestionsDAO.CreateQuestion(question);
            var response = Request.CreateResponse(HttpStatusCode.Created, createdUser);
            return response;
        }
        [Route("updateQuestion")]
        [HttpPut]        
        public HttpResponseMessage UpdateQuestion([FromUri]int questionId , [FromBody]Question question)
        {
            var updatedQuestion = QuestionsDAO.UpdateQuestion(questionId, question);
            return Request.CreateResponse(HttpStatusCode.Accepted, updatedQuestion);        
                
        }
    }
}
