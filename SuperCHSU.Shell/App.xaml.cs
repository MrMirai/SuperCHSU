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
using Microsoft.EntityFrameworkCore;
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
using SuperCHSU.MainModule.DataBase.Context;
using SuperCHSU.MainModule.DataBase.Entities;
using SuperCHSU.MainModule.DataBase.Interfaces;
using SuperCHSU.MainModule.DataBase.Repositories;

namespace SuperCHSU.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        //private IConfiguration _configuration;
        public static bool IsDesignMode { get; set; } = true;

        //private static IHost _host;

        //public static IHost Host => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        //public static IServiceProvider Services => Host.Services;

        //protected override async void OnStartup(StartupEventArgs e)
        //{
        //    IsDesignMode = false;
        //    var host = Host;
        //    base.OnStartup(e);
        //    await host.StartAsync().ConfigureAwait(false);
        //}

        //protected override async void OnExit(ExitEventArgs e)
        //{
        //    var host = Host;
        //    base.OnExit(e);
        //    await host.StopAsync().ConfigureAwait(false);
        //    host.Dispose();
        //    _host = null;
        //}

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindowView>();
        }



        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //    var builder = new ConfigurationBuilder().SetBasePath(CurrentDirectory)
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        //    _configuration = builder.Build();
        //}

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(CurrentDirectory)
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddJsonFile("appsettings.Development.json", optional: true);

            //IConfiguration configuration = builder.Build();

            //var databaseSettings = _configuration.GetSection("ConnectionStrings").Get<DatabaseSettings>();
            //containerRegistry.RegisterSingleton<ScheduleContext>(serviceProvider =>
            //{
            //    var dbContextOptionsBuilder =
            //        new DbContextOptionsBuilder<ScheduleContext>().UseSqlite(_configuration.GetConnectionString("SQLiteDatabase"));
            //    return new ScheduleContext(dbContextOptionsBuilder.Options);
            //});
            //containerRegistry.AddDatabese(configuration);
            //var optionBuilder = new DbContextOptionsBuilder<ScheduleContext>();
            //var option = optionBuilder.UseSqlite(_configuration.GetConnectionString("SQLiteDatabase")).Options;
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            containerRegistry.RegisterSingleton<ScheduleContext>();
            containerRegistry.RegisterInstance(new DbContextOptionsBuilder<ScheduleContext>().UseSqlite(configuration.GetConnectionString("SQLiteDatabase")).Options);

            //containerRegistry.Register<ScheduleContext>(() => new ScheduleContext(option));
            containerRegistry.Register<IRepository<Classroom>, DbRepository<Classroom>>()
                .Register<IRepository<Group>, DbRepository<Group>>()
                .Register<IRepository<Lecture>, DbRepository<Lecture>>()
                .Register<IRepository<Tutor>, DbRepository<Tutor>>()
                .Register<IRepository<TypesOfLecture>, DbRepository<TypesOfLecture>>()
                .Register<IRepository<Schedule>, ScheduleRepository>();

            // Регистрация MainWindowViewModel с его зависимостями
            containerRegistry.RegisterForNavigation<MainWindowView>();
            containerRegistry.RegisterForNavigation<ReservationObserverByClassroomView>(nameof(ReservationObserverByClassroomView));
            containerRegistry.RegisterForNavigation<ReservationObserverByGroupView>(nameof(ReservationObserverByGroupView));
            containerRegistry.RegisterForNavigation<ReservationObserverByTutorView>(nameof(ReservationObserverByTutorView));
            containerRegistry.RegisterForNavigation<ReservationObserverGanttChartView>(nameof(ReservationObserverGanttChartView));
            containerRegistry.AddServices();
            containerRegistry.AddViewModels();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<MainModule.MainModule>();
        }

        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);
            Application.Current.MainWindow = shell;
            Application.Current.MainWindow.Show();
        }

        /////

        //public static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
        //    .AddDatabese(host.Configuration.GetSection("Database"));

        public static string? CurrentDirectory => IsDesignMode
            ? Path.GetDirectoryName(GetSourceCodePath())
            : Environment.CurrentDirectory;

        private static string GetSourceCodePath([CallerFilePath] string path = null) => path;

    }
}
