using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SuperCHSU.MainModule.DataBase.Entities.Base;

namespace SuperCHSU.MainModule.DataBase.Entities;

[Table("Lectures")]
public partial class Lecture : Entity
{
    public string Name { get; set; } = null!;
}
