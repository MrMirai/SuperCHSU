using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CSLB5.DataBase.Entities.Base;

namespace CSLB5.DataBase.Entities;

[Table("Group")]
public partial class Group : Entity
{
    public string GroupNumber { get; set; } = null!;
}
