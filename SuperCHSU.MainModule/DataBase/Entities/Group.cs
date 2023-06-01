using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SuperCHSU.MainModule.DataBase.Entities.Base;

namespace SuperCHSU.MainModule.DataBase.Entities;

[Table("Groups")]
public partial class Group : Entity
{
    public string GroupNumber { get; set; } = null!;
}
