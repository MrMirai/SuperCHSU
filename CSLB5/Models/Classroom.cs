using System.Collections.Generic;
using CSLB5.Models.Base;

namespace CSLB5.Models;

public class Classroom : Entity
{
    public int Number { get; set; }
    
    public string Letter { get; set; }
    
    public virtual ICollection<Schedule> Schedules { get; set; }
}