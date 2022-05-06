using GraphsAlgorithms.Model.Graph;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GraphsAlgorithms.Model
{
    class GraphElipse
    {
        public Vertex MainVertex { get; set; }
        public Point CenterPoint { get; set; }
        public Thickness GetMargin { get; set; }
        public string Text { get; set; }
        public double Radius { get; set; }
        public GraphElipse(Vertex v, double x, double y, string text, double radius = 15)
        {
            MainVertex = v;

            Radius = radius;

            CenterPoint = new Point(x, y);

            Thickness p = new Thickness();
            p.Left = x - Radius / 2.5;
            p.Top = y - Radius / 2;
            p.Bottom = 0;
            p.Right = 0;
            GetMargin = p;
            Text = text;

        }
    }
}
