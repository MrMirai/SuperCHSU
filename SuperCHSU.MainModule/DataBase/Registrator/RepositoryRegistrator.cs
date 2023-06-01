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

}