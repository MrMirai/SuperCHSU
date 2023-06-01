using System.Linq;
using SuperCHSU.MainModule.DataBase.Context;
using SuperCHSU.MainModule.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace SuperCHSU.MainModule.DataBase.Repositories;

public class ScheduleRepository : DbRepository<Schedule>
{
    public override IQueryable<Schedule> Items => base.Items
        .Include(item => item.Group)
        .Include(item => item.Lecture)
        .Include(item => item.Classroom)
        .Include(item => item.Tutor);

    public ScheduleRepository(ScheduleContext db) : base(db) { }
}