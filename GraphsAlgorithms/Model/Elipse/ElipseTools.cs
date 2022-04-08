using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphsAlgorithms.Model
{
    static class ElipseTools
    {
        public static bool PointInElipse(Point p, double x, double y, double R)
        {
            if ((Math.Pow((p.X - x),2)  / Math.Pow(R,2)) + (Math.Pow((p.Y - y), 2) / Math.Pow(R, 2)) < 1) return true;
            else return false;
        }
    }
}
