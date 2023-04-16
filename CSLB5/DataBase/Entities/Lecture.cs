using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CSLB5.DataBase.Entities.Base;

namespace CSLB5.DataBase.Entities;

[Table("Lecture")]
public partial class Lecture : Entity
{
    public string Name { get; set; } = null!;
}
