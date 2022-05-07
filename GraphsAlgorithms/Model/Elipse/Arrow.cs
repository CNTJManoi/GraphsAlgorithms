using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GraphsAlgorithms.Model.Elipse
{
    class Arrow
    {
        public PointCollection Points { get; set; }
        public Arrow(ObservableCollection<Point> p)
        {
            Points = new PointCollection();
            foreach (var point in p)
            {
                Points.Add(point);
            }
        }
    }
}
