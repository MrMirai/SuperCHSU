using SuperCHSU.MainModule.DataBase.Entities;
using SuperCHSU.MainModule.DataBase.Interfaces;
using SuperCHSU.MainModule.DataBase.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;

namespace SuperCHSU.MainModule.DataBase.Registrator;

public static class RepositoryRegistrator
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) => services
        .AddTransient<IRepository<Classroom>, DbRepository<Classroom>>()
        .AddTransient<IRepository<Group>, DbRepository<Group>>()
        .AddTransient<IRepository<Lecture>, DbRepository<Lecture>>()
        .AddTransient<IRepository<Tutor>, DbRepository<Tutor>>()
        .AddTransient<IRepository<TypesOfLecture>, DbRepository<TypesOfLecture>>()
        .AddTransient<IRepository<Schedule>, ScheduleRepository>()
    ;

    //public static IContainerRegistry AddRepositories(this IContainerRegistry services) => services
    //    .Register(typeof(IRepository<Classroom>), typeof(DbRepository<Classroom>))
    //    .Register(typeof(IRepository<Group>), typeof(DbRepository<Group>))
    //    .Register(typeof(IRepository<Lecture>), typeof(DbRepository<Lecture>))
    //    .Register(typeof(IRepository<Tutor>), typeof(DbRepository<Tutor>))
    //    .Register(typeof(IRepository<TypesOfLecture>), typeof(DbRepository<TypesOfLecture>))
    //    .Register(typeof(IRepository<Schedule>), typeof(ScheduleRepository))


    //.Register<IRepository<Classroom>, DbRepository<Classroom>>()
    //.Register<IRepository<Group>, DbRepository<Group>>()
    //.Register<IRepository<Lecture>, DbRepository<Lecture>>()
    //.Register<IRepository<Tutor>, DbRepository<Tutor>>()
    //.Register<IRepository<TypesOfLecture>, DbRepository<TypesOfLecture>>()
    //.Register<IRepository<Schedule>, ScheduleRepository>()
    //;
}