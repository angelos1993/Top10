//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Top10.DAL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserGrade
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public int Grade { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
    }
}
