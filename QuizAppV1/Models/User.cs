using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizAppV1.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}