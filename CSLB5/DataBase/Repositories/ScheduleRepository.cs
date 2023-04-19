using System.Linq;
using CSLB5.DataBase.Context;
using CSLB5.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSLB5.DataBase.Repositories;

public class ScheduleRepository : DbRepository<Schedule>
{
    public override IQueryable<Schedule> Items => base.Items
        .Include(item => item.Group)
        .Include(item => item.Lecture)
        .Include(item => item.Classroom)
        .Include(item => item.Tutor);

    public ScheduleRepository(ScheduleContext db) : base(db) { }
}