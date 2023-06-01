using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperCHSU.MainModule.DataBase.Context;

namespace SuperCHSU.MainModule.ViewModels
{
     public class ClassViewModel
     {

         public ClassViewModel()
        {
        }

        public string _title = "Hiiiiiiii";
        public string Title
        {
            get => _title;
            set => _title = value;
        }
    }
}
