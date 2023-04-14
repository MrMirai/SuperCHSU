using System.Collections.Generic;
using CSLB5.Models.Base;

namespace CSLB5.Models;

public class Group : NamedEntity
{
    public virtual ICollection<Schedule> Schedules { get; set; }
}