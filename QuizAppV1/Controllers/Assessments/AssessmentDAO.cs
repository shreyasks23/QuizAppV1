using System;
using System.Collections.Generic;
using System.Linq;
using QuizAppDAO;

namespace QuizAppV1.Controllers.Assessments
{
    public class AssessmentDAO : IAssessmentDAO
    {
        private readonly QuizAppEntities entities = new QuizAppEntities();

        public int AddQuestionsToAssessment(int AssessmentID, int QuestionID)
        {
            using (entities)
            {
                var AssessmentQuestion = new AssessmentQuestion()
                {
                    AssessmentID = AssessmentID,
                    QuestionID = QuestionID,
                    Isdeleted = false
                };
                entities.AssessmentQuestions.Add(AssessmentQuestion);
                entities.SaveChanges();
                return AssessmentQuestion.Id;
            }
            
        }

        public ICollection<Models.Assessment> GetAllAssessments()
        {
            ICollection<Models.Assessment> assessments = new List<Models.Assessment>();


            using (entities)
            {
                var DBAssessments = entities.Assessments.ToList();
                foreach (var a in DBAssessments)
                {
                    Models.Assessment assessment = new Models.Assessment
                    {
                        AssessmentID = a.AssessmentID,
                        AssessmentName = a.AssessmentName,
                        MaxMarks = a.MaxMarks,
                        IsDeleted = (Boolean)a.Isdeleted
                    };
                    assessments.Add(assessment);
                }

            }
            return assessments;
        }

        public Models.Assessment GetAssessment(int ID)
        {
            List<Models.Question> Questions = new List<Models.Question>();          


            using (entities)
            {
                var assessments = entities.Assessments.FirstOrDefault(a => a.AssessmentID == ID);

                var DbAssessmentQuestions = from aq in entities.AssessmentQuestions
                                            join a in entities.Assessments on aq.AssessmentID equals a.AssessmentID
                                            join q in entities.Questions on aq.QuestionID equals q.QuestionID
                                            where aq.AssessmentID == ID
                                            select new Models.Question
                                            {
                                                QuestionID = q.QuestionID,
                                                QuestionText = q.QuestionText,
                                                MaxMarks = (float)q.MaxMarks,
                                                IsDeleted = (bool)q.Isdeleted
                                            };
                Questions = DbAssessmentQuestions.ToList();
                foreach (var q in Questions)
                {
                    
                    q.Choices = entities.Choices.Where(c => c.QuestionID == q.QuestionID)
                        .Select(c => new Models.Choice()
                        {
                            ChoiceID = c.ChoiceID,
                            ChoiceText = c.ChoiceText,
                            IsCorrect = (bool)c.IsCorrect,
                            IsDeleted = (bool)c.Isdeleted,
                            QuestionID = (int)c.QuestionID
                        }).ToList();
                }               


                return new Models.Assessment
                {
                    AssessmentID = assessments.AssessmentID,
                    AssessmentName = assessments.AssessmentName,
                    MaxMarks = assessments.MaxMarks,
                    IsDeleted = (bool)assessments.Isdeleted,
                    AssessmentQuestions = Questions
                };

            }
        }
    }
}