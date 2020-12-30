using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizAppV1.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }        
        public float MaxMarks { get; set; }
        //public int CorrectChoiceID { get; set; }
        public Boolean IsDeleted { get; set; }
        public List<Choice> Choices { get; set; }
    }
}