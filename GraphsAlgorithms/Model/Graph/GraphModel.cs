using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphsAlgorithms.Model.Graph
{
    class GraphModel
    {
        List<Vertex> _vertexs;
        ObservableCollection<Edge> _edges;
        public GraphModel()
        {
            _vertexs = new List<Vertex>();
            _edges = new ObservableCollection<Edge>();
        }
        public Vertex AddVertex(Point point)
        {
            _vertexs.Add(new Vertex(point.X, point.Y));
            return Vertexs.Last();
        }
        public Edge AddEdge(Vertex v1, Vertex v2, float weight)
        {
            _edges.Add(new Edge(v1, v2, weight));
            return Edges.Last();
        }
        public List<Vertex> Vertexs { get { return _vertexs; } }
        public ObservableCollection<Edge> Edges { get { return _edges; } }
    }
}
