using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLB5.Models
{
    public  class RectangleModel
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public int Width { get; set; }
        public RectangleModel(int xStart, int yStart, int width)
        {
            XStart = xStart;
            YStart = yStart;
            Width = width;
        }
    }
}
