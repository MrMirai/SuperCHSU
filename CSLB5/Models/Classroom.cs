using System;
using System.Collections.Generic;

namespace CSLB5.Models;

public partial class Classroom
{
    public long ClassroomId { get; set; }

    public long Number { get; set; }

    public string? Letter { get; set; }
}
