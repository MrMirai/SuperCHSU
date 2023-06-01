using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Configuration;

namespace SuperCHSU.Shell;

public class Program
{
    //[STAThread]
    //public static void Main()
    //{
    //    var app = new App();
    //    //app.InitializeComponent();
    //    app.Run();
    //}

    //public static IHostBuilder CreateHostBuilder(string[] args) =>
    //    Host.CreateDefaultBuilder(args)
    //        .UseContentRoot(App.CurrentDirectory)
    //        .ConfigureAppConfiguration((host, cfg) => cfg
    //            .SetBasePath(App.CurrentDirectory)
    //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //            .AddJsonFile("appsettings.Development.json", optional: true))
    //        .ConfigureServices(App.ConfigureServices);
}