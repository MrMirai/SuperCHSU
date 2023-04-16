using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CSLB5.DataBase.Entities.Base;

namespace CSLB5.DataBase.Entities;

[Table("TypeOfLectures")]
public partial class TypesOfLecture : Entity
{
    public string Abbrevation { get; set; } = null!;

    public string? Name { get; set; }
}
