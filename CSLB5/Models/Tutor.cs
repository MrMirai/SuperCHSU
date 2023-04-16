using System;
using System.Collections.Generic;

namespace CSLB5.Models;

public partial class Tutor
{
    public long TutorId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronimic { get; set; }
}
