using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphsAlgorithms.Model.Graph
{
    class Edge
    {
        Vertex _vertex1;
        Point _beginPoint;
        Vertex _vertex2;
        Point _endPoint;
        Thickness _thickness;
        string _weight;
        public Edge(Vertex vertex1, Vertex vertex2, float weight = float.MinValue)
        {
            _vertex1 = vertex1;
            _vertex2 = vertex2;
            _beginPoint = new Point(vertex1.X, vertex1.Y);
            _endPoint = new Point(vertex2.X, vertex2.Y);
            _thickness = new Thickness();
            _thickness.Left = (_vertex1.X + _vertex2.X) / 2;
            _thickness.Top = (_vertex1.Y + _vertex2.Y) / 2;
            _thickness.Bottom = 0;
            _thickness.Right = 0;
            _weight = weight.ToString();

        }
        public Vertex Vertex1 { get { return _vertex1; } }
        public Vertex Vertex2 { get { return _vertex2; } }
        public Point BeginPoint { get { return _beginPoint; } }
        public Point EndPoint { get { return _endPoint; } }
        public Thickness GetMarginCenter { get { return _thickness; } }
        public string Weight
        {
            get { return _weight; }
            set
            {
                if (value != null) _weight = value;
            }
        }
    }
}
