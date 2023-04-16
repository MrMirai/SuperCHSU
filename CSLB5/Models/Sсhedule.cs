using System;
using System.Collections.Generic;

namespace CSLB5.Models;

public partial class Sсhedule
{
    public long GroupId { get; set; }

    public long LectureId { get; set; }

    public long TutorId { get; set; }

    public long ClassroomId { get; set; }

    public string Abbrevation { get; set; } = null!;

    public string StartTime { get; set; } = null!;

    public string EndTime { get; set; } = null!;

    public string Data { get; set; } = null!;

    public virtual TypesOfLecture AbbrevationNavigation { get; set; } = null!;

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;

    public virtual Lecture Lecture { get; set; } = null!;

    public virtual Tutor Tutor { get; set; } = null!;
}
