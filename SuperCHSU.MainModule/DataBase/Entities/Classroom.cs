using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SuperCHSU.MainModule.DataBase.Entities.Base;

namespace SuperCHSU.MainModule.DataBase.Entities;

[Table("Classrooms")]
public partial class Classroom : Entity
{
    
    public long Number { get; set; }

    public string? Letter { get; set; }

    public override string ToString()
    {
        return $"{Number}{Letter ?? ""}";
    }
}
