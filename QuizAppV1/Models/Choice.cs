using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizAppV1.Models
{
    public class Choice
    {
        public int ChoiceID { get; set; }
        public string ChoiceText { get; set; }
        public int QuestionID { get; set; }
        public Boolean IsDeleted { get; set; }
        public Boolean IsCorrect { get; set; }
    }
}