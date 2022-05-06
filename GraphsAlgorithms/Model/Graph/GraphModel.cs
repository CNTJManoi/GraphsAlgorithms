using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace GraphsAlgorithms.Model.Graph;

internal class GraphModel
{
    public GraphModel()
    {
        Vertexs = new List<Vertex>();
        Edges = new ObservableCollection<Edge>();
    }

    public List<Vertex> Vertexs { get; }

    public ObservableCollection<Edge> Edges { get; }

    public Vertex AddVertex(Point point)
    {
        Vertexs.Add(new Vertex(point.X, point.Y));
        return Vertexs.Last();
    }

    public Edge AddEdge(Vertex v1, Vertex v2, float weight)
    {
        Edges.Add(new Edge(v1, v2, weight));
        return Edges.Last();
    }
}