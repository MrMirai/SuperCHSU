using SuperCHSU.MainModule.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;

namespace SuperCHSU.MainModule.DataBase.Registrator
{
     public static class DbRegistrator
    {
        public static IServiceCollection AddDatabese(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<Context.ScheduleContext>(opt =>
        {
            opt.UseSqlite(configuration.GetConnectionString("SQLiteDatabase"));
        })
           .AddRepositories();
    }
}
