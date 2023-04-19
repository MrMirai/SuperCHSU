using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CSLB5.DataBase.Entities.Base;

namespace CSLB5.DataBase.Entities;

[Table("Classrooms")]
public partial class Classroom : Entity
{
    
    public long Number { get; set; }

    public string? Letter { get; set; }
}
