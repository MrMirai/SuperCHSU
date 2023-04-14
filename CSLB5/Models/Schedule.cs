using System;
using System.ComponentModel.DataAnnotations.Schema;
using CSLB5.Models.Base;

namespace CSLB5.Models;

public class Schedule : Entity
{
    public virtual Lecture Lecture { get; set; }
    
    public virtual TypeOfLecture TypeOfLecture { get; set; }
    
    public virtual Tutor Tutor { get; set; }
    
    public virtual Classroom Classroom { get; set; }
    
    public virtual Group Group { get; set; }
    
    [Column(TypeName = "TimeOnly")]
    public TimeOnly StartTime { get; set; }
    
    public TimeOnly EndTime { get; set; }
    
    public DateOnly Date { get; set; }
}