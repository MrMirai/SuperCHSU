using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SuperCHSU.MainModule.DataBase.Entities.Base;

namespace SuperCHSU.MainModule.DataBase.Entities;

[Table("Tutors")]
public partial class Tutor : Entity
{
    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronimic { get; set; }
}
