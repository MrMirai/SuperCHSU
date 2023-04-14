using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CSLB5.Models.Base;

namespace CSLB5.Models;

public class TypeOfLecture : NamedEntity
{
    [Key]
    public string Abbrevation { get; set; }
    
    public virtual ICollection<Schedule> Schedules { get; set; }
}