﻿using System;
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

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public DateOnly Data { get; set; }

    public virtual TypesOfLecture AbbrevationNavigation { get; set; } = null!;

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;

    public virtual Lecture Lecture { get; set; } = null!;

    public virtual Tutor Tutor { get; set; } = null!;
}