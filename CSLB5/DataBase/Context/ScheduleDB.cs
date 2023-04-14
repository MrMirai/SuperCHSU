using CSLB5.Models;
using Microsoft.EntityFrameworkCore;

namespace CSLB5.DataBase.Context;

public class ScheduleDB : DbContext
{
    public DbSet<Group> Groups { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Tutor> Tutors { get; set; }
    public DbSet<TypeOfLecture> TypesOfLecture { get; set; }
    public DbSet<Schedule> Schedules { get; set; }

    public ScheduleDB(DbContextOptions<ScheduleDB> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}