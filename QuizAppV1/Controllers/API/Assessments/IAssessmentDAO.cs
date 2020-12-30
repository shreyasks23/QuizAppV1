using System.Collections.Generic;


namespace QuizAppV1.Controllers.Assessments
{
    interface IAssessmentDAO
    {
        ICollection<Models.Assessment> GetAllAssessments();
        Models.Assessment GetAssessment(int ID);
        int AddQuestionsToAssessment(int AssessmentID , int QuestionID);
    }
}
