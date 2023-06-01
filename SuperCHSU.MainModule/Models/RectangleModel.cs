using SuperCHSU.MainModule.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCHSU.MainModule.Models
{
    public  class RectangleModel
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public int Width { get; set; }
        public Schedule Schedule { get; set; }
        public RectangleModel(int xStart, int yStart, int width, Schedule schedule)
        {
            XStart = xStart;
            YStart = yStart;
            Width = width;
            Schedule = schedule;
        }
    }
}
