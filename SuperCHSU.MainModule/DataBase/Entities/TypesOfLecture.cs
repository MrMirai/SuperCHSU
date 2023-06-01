using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SuperCHSU.MainModule.DataBase.Entities.Base;

namespace SuperCHSU.MainModule.DataBase.Entities;

[Table("TypesOfLecture")]
public partial class TypesOfLecture : Entity
{
    public string Abbrevation { get; set; } = null!;

    public string? Name { get; set; }
}
