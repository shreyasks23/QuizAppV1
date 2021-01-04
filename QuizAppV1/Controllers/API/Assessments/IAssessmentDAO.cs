using System.Collections.Generic;
using System.Linq;

namespace QuizAppV1.Controllers.Assessments
{
    interface IAssessmentDAO
    {
        IQueryable<Models.Assessment> GetAllAssessments();
        Models.Assessment GetAssessment(int ID);
        int AddQuestionsToAssessment(int AssessmentID , int QuestionID);
    }
}
