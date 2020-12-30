using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizAppV1.Models
{
    public class Assessment
    {
        public int AssessmentID { get; set; }
        public string AssessmentName { get; set; }
        public float MaxMarks { get; set; }
        public Boolean IsDeleted { get; set; }
        public List<Question> AssessmentQuestions { get; set; }
    }
}