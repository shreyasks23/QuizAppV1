//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuizAppDAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssessmentUser
    {
        public int Id { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> AssessmentID { get; set; }
        public Nullable<bool> IsAttempted { get; set; }
        public Nullable<bool> Isdeleted { get; set; }
    
        public virtual Assessment Assessment { get; set; }
        public virtual User User { get; set; }
    }
}
