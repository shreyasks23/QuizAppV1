using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuizAppV1.Models;


namespace QuizAppV1.Controllers.Questions
{
    public class QuestionController : ApiController
    {
         QuestionDAO QuestionsDAO = new QuestionDAO();

        public List<Question> GetQuestions()
        {
            return QuestionsDAO.GetQuestions().ToList();
        }

        public Question GetQuestion(int ID)
        {
            return QuestionsDAO.GetQuestion(ID);
        }
        [HttpPost]
        public HttpResponseMessage CreateQuestions([FromBody]Models.Question question)
        {
            var createdUser = QuestionsDAO.CreateQuestion(question);
            var response = Request.CreateResponse(HttpStatusCode.Created, createdUser);
            return response;
        }
    }
}
