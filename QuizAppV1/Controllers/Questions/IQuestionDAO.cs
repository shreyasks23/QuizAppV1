using System;
using System.Collections.Generic;


namespace QuizAppV1.Controllers.Questions
{
    interface IQuestionDAO
    {
        ICollection<Models.Question> GetQuestions();
        Models.Question GetQuestion(int id);
        Models.Question CreateQuestion(Models.Question question);        

    }
}
