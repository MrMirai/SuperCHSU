using System;
using System.Collections;
using System.Collections.Generic;
using CSLB5.Models.Base;

namespace CSLB5.Models;

public class Tutor : NamedEntity
{
    public string Surname { get; set; }
    
    public string Patronimic { get; set; }
    
    public virtual ICollection<Schedule> Schedules { get; set; }
}

public class Lecture : NamedEntity
{
    public virtual ICollection<Schedule> Schedules { get; set; }
}

public class Group : NamedEntity
{
    public virtual ICollection<Schedule> Schedules { get; set; }
}

public class Classroom : Entity
{
    public int Number { get; set; }
    
    public string Letter { get; set; }
    
    public virtual ICollection<Schedule> Schedules { get; set; }
}

public class TypeOfLecture : NamedEntity
{
    public string Abbrevation { get; set; }
    
    public virtual ICollection<Schedule> Schedules { get; set; }
}

public class Schedule : Entity
{
    public virtual Lecture Lecture { get; set; }
    
    public virtual TypeOfLecture TypeOfLecture { get; set; }
    
    public virtual Tutor Tutor { get; set; }
    
    public virtual Classroom Classroom { get; set; }
    
    public virtual Group Group { get; set; }
    
    public TimeOnly StartTime { get; set; }
    
    public TimeOnly EndTime { get; set; }
    
    public DateOnly Date { get; set; }
}