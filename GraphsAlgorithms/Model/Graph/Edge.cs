using System.Windows;

namespace GraphsAlgorithms.Model.Graph;

internal class Edge
{
    private readonly Thickness _thickness;
    private string _weight;

    public Edge(Vertex vertex1, Vertex vertex2, float weight = float.MinValue)
    {
        Vertex1 = vertex1;
        Vertex2 = vertex2;
        BeginPoint = new Point(vertex1.X, vertex1.Y);
        EndPoint = new Point(vertex2.X, vertex2.Y);
        _thickness = new Thickness();
        _thickness.Left = (Vertex1.X + Vertex2.X) / 2;
        _thickness.Top = (Vertex1.Y + Vertex2.Y) / 2;
        _thickness.Bottom = 0;
        _thickness.Right = 0;
        _weight = weight.ToString();
    }

    public Vertex Vertex1 { get; }

    public Vertex Vertex2 { get; }

    public Point BeginPoint { get; }

    public Point EndPoint { get; }

    public Thickness GetMarginCenter => _thickness;

    public string Weight
    {
        get => _weight;
        set
        {
            if (value != null) _weight = value;
        }
    }
}