using System.Collections.Generic;
using System.Linq;

namespace QuizAppV1.Controllers.Questions
{
    interface IQuestionDAO
    {
        ICollection<Models.Question> GetQuestions();
        Models.Question GetQuestion(int questionId);
        Models.Question CreateQuestion(Models.Question question);
        Models.Question UpdateQuestion(int questionId , Models.Question question);

    }
}
