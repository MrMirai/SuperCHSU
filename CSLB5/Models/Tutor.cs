using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CSLB5.Models.Base;

namespace CSLB5.Models;

public class Tutor : NamedEntity
{
    [Required]
    public string Surname { get; set; }
    
    [Required]
    public string Patronimic { get; set; }
    
    [Required]
    public virtual ICollection<Schedule> Schedules { get; set; }
}