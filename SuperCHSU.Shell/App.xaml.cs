using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using SuperCHSU.MainModule.DataBase.Registrator;
using SuperCHSU.MainModule.Services.Registrator;
using SuperCHSU.MainModule.ViewModels;
using SuperCHSU.MainModule.Views;
using SuperCHSU.MainModule.ViewModels.Registrator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prism.Ioc;
using Prism.Unity;
using Prism.Modularity;
using SuperCHSU.MainModule.DataBase.Entities;
using SuperCHSU.MainModule.DataBase.Interfaces;
using SuperCHSU.MainModule.DataBase.Repositories;

namespace SuperCHSU.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static bool IsDesignMode { get; set; } = true;
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindowView> ();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            //containerRegistry.AddDbContext<ScheduleContext>(options =>
            //{
            //    options.UseSqlite("Data Source = ..\\..\\..\\DataBase\\schedule.db"); // Замените "connection_string" на вашу строку подключения к базе данных
            //});

            // Регистрация репозитория и других зависимостей
            containerRegistry.Register<DbRepository<Schedule>>();

            containerRegistry.Register<IRepository<Schedule>, ScheduleRepository>();
            containerRegistry.Register<IRepository<Tutor>, DbRepository<Tutor>>();
            containerRegistry.Register<IRepository<Classroom>, DbRepository<Classroom>>();
            containerRegistry.Register<IRepository<Group>, DbRepository<Group>>();

            // Регистрация MainWindowViewModel с его зависимостями
            containerRegistry.Register<MainWindowViewModel>();
            containerRegistry.RegisterForNavigation<MainWindowView>();

            //var builder = new ConfigurationBuilder()
            //   .SetBasePath(CurrentDirectory)
            //   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //   .AddJsonFile("appsettings.Development.json", optional: true);

            //IConfiguration configuration = builder.Build();

            //containerRegistry
            //    .AddDatabese(configuration)
            //    .AddServices()
            //    .AddViewModels();


        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<MainModule.MainModule>();
        }


        /////

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
           .AddServices()
           .AddViewModels()
           .AddDatabese(host.Configuration.GetSection("Database"));

        //public static string? CurrentDirectory => IsDesignMode
        //    ? Path.GetDirectoryName(GetSourceCodePath())
        //    : Environment.CurrentDirectory;

        //private static string GetSourceCodePath([CallerFilePath] string path = null) => path;

    }
}
