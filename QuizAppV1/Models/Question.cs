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
        public bool IsDeleted { get; set; }
        public ICollection<Choice> Choices { get; set; }
    }
}