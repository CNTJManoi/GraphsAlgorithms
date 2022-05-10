using System.Windows;
using GraphsAlgorithms.Model.Graph;

namespace GraphsAlgorithms.Model;

class GraphElipse
{
    public GraphElipse(Vertex v, double x, double y, string text, double radius = 15)
    {
        MainVertex = v;

        Radius = radius;

        CenterPoint = new Point(x, y);

        var p = new Thickness();
        p.Left = x - Radius / 2.5;
        p.Top = y - Radius / 2;
        p.Bottom = 0;
        p.Right = 0;
        GetMargin = p;
        Text = text;
    }

    public Vertex MainVertex { get; set; }
    public Point CenterPoint { get; set; }
    public Thickness GetMargin { get; set; }
    public string Text { get; set; }
    public double Radius { get; set; }
}