using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CSLB5.DataBase.Entities.Base;

namespace CSLB5.DataBase.Entities;

[Table("Sсhedules")]
public partial class Schedule : Entity
{
    public long GroupId { get; set; }

    public long LectureId { get; set; }

    public long TutorId { get; set; }

    public long ClassroomId { get; set; }

    public string Abbrevation { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime Data{ get; set; }

    public virtual TypesOfLecture AbbrevationNavigation { get; set; } = null!;

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;

    public virtual Lecture Lecture { get; set; } = null!;

    public virtual Tutor Tutor { get; set; } = null!;
}
