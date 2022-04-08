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
        public Edge(Vertex vertex1, Vertex vertex2)
        {
            _vertex1 = vertex1;
            _vertex2 = vertex2;
            _beginPoint = new Point(vertex1.X, vertex1.Y);
            _endPoint = new Point(vertex2.X, vertex2.Y);
        }
        public Vertex Vertex1 { get { return _vertex1; } }
        public Vertex Vertex2 { get { return _vertex2;} }
        public Point BeginPoint { get { return _beginPoint; } }
        public Point EndPoint { get { return _endPoint; } }
    }
}
