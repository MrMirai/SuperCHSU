using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using SuperCHSU.MainModule.DataBase.Entities;
using SuperCHSU.MainModule.DataBase.Interfaces;
using SuperCHSU.MainModule.DataBase.Repositories;
using System;

namespace SuperCHSU.MainModule
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
           
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<IRepository<Schedule>, ScheduleRepository>("ScheduleRepository");
            //containerRegistry.Register<IRepository<Tutor>, DbRepository<Tutor>>("TutorRepository");
            //containerRegistry.Register<IRepository<Classroom>, DbRepository<Classroom>>("ClassroomRepository");
            //containerRegistry.Register<IRepository<Group>, DbRepository<Group>>("GroupRepository");
        }
    }
}
