using System.Collections.Generic;
using System.Linq;
using QuizAppDAO;


namespace QuizAppV1.Controllers.Questions
{
    public class QuestionDAO : IQuestionDAO
    {
        private readonly QuizAppEntities entities = new QuizAppEntities();

        public ICollection<Models.Question> GetQuestions()
        {
            using (entities)
            {
                var allQuestions = entities.Questions.Select(x => new Models.Question
                {
                    QuestionID = x.QuestionID,
                    QuestionText = x.QuestionText,
                    MaxMarks = (float)x.MaxMarks
                }).ToList();

                foreach (var ques in allQuestions)
                {
                    ques.Choices = entities.Choices
                        .Where(x => x.QuestionID == ques.QuestionID)
                        .Select(x => new Models.Choice
                        {
                            ChoiceID = x.ChoiceID,
                            ChoiceText = x.ChoiceText,
                            IsDeleted = (bool)x.Isdeleted,
                            QuestionID = ques.QuestionID
                        }).ToList();
                }

                return allQuestions;

            }
        }

        public Models.Question GetQuestion(int id)
        {
            using (entities)
            {
                var question = entities.Questions.FirstOrDefault(x => x.QuestionID == id);
                var choices = entities.Choices
                    .Where(x => x.QuestionID == id)
                    .Select(x => new Models.Choice
                    {
                        ChoiceID = x.ChoiceID,
                        ChoiceText = x.ChoiceText,
                        IsDeleted = (bool)x.Isdeleted,
                        QuestionID = (int)x.QuestionID
                    }).ToList();


                var Question = new Models.Question
                {
                    QuestionID = question.QuestionID,
                    QuestionText = question.QuestionText,
                    //CorrectChoiceID = question.CorrectChoiceID,
                    MaxMarks = (float)question.MaxMarks,
                    Choices = choices
                };
                return Question;
            }
        }


        public Models.Question CreateQuestion(Models.Question question)
        {
            //List<Models.Choice> choices = new List<Models.Choice>();
            using (entities)
            {
                QuizAppDAO.Question DbQuestion = new QuizAppDAO.Question()
                {
                    QuestionText = question.QuestionText,
                    Isdeleted = question.IsDeleted,
                    MaxMarks = question.MaxMarks
                };
                //choices.AddRange(question.Choices);
                entities.Questions.Add(DbQuestion);
                entities.SaveChanges();

                List<QuizAppDAO.Choice> DbChoices = new List<QuizAppDAO.Choice>();
                foreach (var choice in question.Choices)    
                {
                    var Dbchoice = new QuizAppDAO.Choice()
                    {
                        ChoiceText = choice.ChoiceText,
                        Isdeleted = choice.IsDeleted,
                        IsCorrect = choice.IsCorrect,
                        QuestionID = DbQuestion.QuestionID
                    };
                    DbChoices.Add(Dbchoice);
                }
                entities.Choices.AddRange(DbChoices);
                entities.SaveChanges();

                List<Models.Choice> choices = new List<Models.Choice>();
                foreach (var dbchoice in DbChoices)
                {
                    var choice = new Models.Choice()
                    {
                        ChoiceID = dbchoice.ChoiceID,
                        ChoiceText = dbchoice.ChoiceText,
                        QuestionID = (int)dbchoice.QuestionID,
                        IsDeleted = (bool)dbchoice.Isdeleted,
                        IsCorrect = (bool)dbchoice.IsCorrect
                    };
                    choices.Add(choice);
                }

                return new Models.Question
                {
                    QuestionID = DbQuestion.QuestionID,
                    QuestionText = DbQuestion.QuestionText,
                    IsDeleted = (bool)DbQuestion.Isdeleted,
                    MaxMarks = (float)DbQuestion.MaxMarks,
                    Choices = choices
                };
            }
        }

        
    }
}
