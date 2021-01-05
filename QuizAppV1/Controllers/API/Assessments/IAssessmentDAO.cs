using System.Collections.Generic;
using System.Linq;

namespace QuizAppV1.Controllers.Assessments
{
    interface IAssessmentDAO
    {
        ICollection<Models.Assessment> GetAllAssessments();
        Models.Assessment GetAssessment(int ID);
        int AddQuestionsToAssessment(int AssessmentID , int QuestionID);
        Models.Assessment CreateAssessment(Models.Assessment assessment);
        Models.Assessment UpdateAssessment(int ID , Models.Assessment assessment);
    }
}
