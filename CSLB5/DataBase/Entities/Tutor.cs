using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CSLB5.DataBase.Entities.Base;

namespace CSLB5.DataBase.Entities;

[Table("Tutor")]
public partial class Tutor : Entity
{
    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronimic { get; set; }
}
