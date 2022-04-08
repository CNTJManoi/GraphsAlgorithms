using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAlgorithms.Model.Graph
{
    class Vertex
    {
        double _x, _y;
        public Vertex(double x, double y)
        {
            _x = x;
            _y = y;
        }
        public double X { get { return _x;} }
        public double Y { get { return _y;} }
    }
}
