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
        public Models.Question GetQuestion(int ID)
        {

            var question = QuestionsDAO.GetQuestion(ID);
            if (question == null)
            {
                var res = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Question with ID = {0} is not found", ID)),
                    ReasonPhrase = "Question not found"
                };
                throw new HttpResponseException(res);
            }
            return question;
        }


        [Route("createQuestion")]
        [HttpPost]
        public HttpResponseMessage CreateQuestion([FromBody]Models.Question question)
        {
            if (question != null)
            {
                var createdQuestion = QuestionsDAO.CreateQuestion(question);
                var response = Request.CreateResponse(HttpStatusCode.Created, createdQuestion);
                return response;
            }
            else
            {
                var res = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Add Question text and choices"),
                    ReasonPhrase = "Add Question item"
                };
                throw new HttpResponseException(res);
            }

        }

        [Route("updateQuestion")]
        [HttpPut]
        public HttpResponseMessage UpdateQuestion([FromUri]int questionId, [FromBody]Question question)
        {

            if (question != null)
            {
                var updatedQuestion = QuestionsDAO.UpdateQuestion(questionId, question);
                return Request.CreateResponse(HttpStatusCode.Accepted, updatedQuestion);
            }
            else
            {
                var res = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Add Question text and choices"),
                    ReasonPhrase = "Add Question item"
                };
                throw new HttpResponseException(res);
            }

        }
    }
}
