using CSLB5.DataBase.Entities;
using CSLB5.DataBase.Interfaces;
using CSLB5.DataBase.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CSLB5.DataBase.Registrator;

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