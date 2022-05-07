using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using GraphsAlgorithms.Command;
using GraphsAlgorithms.Model;
using GraphsAlgorithms.Model.Elipse;
using GraphsAlgorithms.Model.Graph;

namespace GraphsAlgorithms.ViewModel;

internal class GraphDisplayModel : INotifyPropertyChanged
{
    private readonly GraphModel _graph;
    private DelegateCommand _leftMouseClick;
    private DelegateCommand _rightMouseClick;


    public GraphDisplayModel()
    {
        Service.gm = this;
        _graph = Service.mw.graphModel;
        Elipses = new ObservableCollection<GraphElipse>();
        InLineMode = false;
        DataMatrix = new List<int[]>();
        Arrows = new ObservableCollection<Arrow>();
    }

    public ObservableCollection<GraphElipse> Elipses { get; set; }
    public ObservableCollection<Arrow> Arrows { get; set; }
    public List<int[]> DataMatrix { get; set; }

    public ObservableCollection<Edge> Edges => _graph.Edges;

    public bool InLineMode { get; private set; }

    private GraphElipse OneGraphElipseMemory { get; set; }

    private GraphElipse TwoGraphElipseMemory { get; set; }
    public string OneTextBox { get; set; }
    public string TwoTextBox { get; set; }

    public DelegateCommand LeftMouseClick => _leftMouseClick ?? (_leftMouseClick = new DelegateCommand(LeftMouse));

    public DelegateCommand RightMouseClick => _rightMouseClick ?? (_rightMouseClick = new DelegateCommand(RightMouse));


    public event PropertyChangedEventHandler? PropertyChanged;

    private void LeftMouse(object obj)
    {
        var mousePos = Mouse.GetPosition((IInputElement)obj);
        Edge point;
        if ((point = ElipseTools.PointInText(_graph, mousePos)) != null)
            foreach (var edge in Edges)
                if (edge.Vertex1 == point.Vertex1 && edge.Vertex2 == point.Vertex2)
                {
                    Edges.Remove(edge);
                    _graph.AddEdge(point.Vertex1, point.Vertex2, float.Parse(point.Weight));
                    OnPropertyChanged(nameof(edge.Weight));
                    Service.mw.FillMatrix();
                    return;
                }

        foreach (var Elipse in Elipses)
            if (ElipseTools.PointInElipse(mousePos, Elipse.MainVertex.X, Elipse.MainVertex.Y,
                    Elipse.Radius)) //нажали на элипс
            {
                if (!InLineMode)
                {
                    InLineMode = true;
                    OneGraphElipseMemory = Elipse;
                    OneTextBox = Elipse.Text;
                    OnPropertyChanged(nameof(OneTextBox));
                    TwoTextBox = "";
                    OnPropertyChanged(nameof(TwoTextBox));
                }
                else
                {
                    if (Elipse == OneGraphElipseMemory) return;

                    TwoGraphElipseMemory = Elipse;
                    _graph.AddEdge(OneGraphElipseMemory.MainVertex, TwoGraphElipseMemory.MainVertex, 0);

                    DrawArrow(
                        new Point(OneGraphElipseMemory.MainVertex.X, OneGraphElipseMemory.MainVertex.Y),
                        new Point(TwoGraphElipseMemory.MainVertex.X, TwoGraphElipseMemory.MainVertex.Y));
                    OnPropertyChanged(nameof(Arrows));
                    ClearMemory();
                    Service.mw.FillMatrix();
                    TwoTextBox = Elipse.Text;
                    OnPropertyChanged(nameof(TwoTextBox));
                }

                return;
            }

        var vertex = _graph.AddVertex(mousePos);
        Elipses.Add(new GraphElipse(vertex, mousePos.X, mousePos.Y, _graph.Vertexs.Count.ToString()));
        OnPropertyChanged(nameof(Elipses));
    }

    private void RightMouse(object obj)
    {
        var mousePos = Mouse.GetPosition((IInputElement)obj);
    }
    public void DrawArrow(Point a, Point b)
    {
        double HeadWidth = 20; // Ширина между ребрами стрелки
        double HeadHeight = 10; // Длина ребер стрелки

        double X1 = a.X;
        double Y1 = a.Y;

        double X2 = b.X;
        double Y2 = b.Y;

        double theta = Math.Atan2(Y1 - Y2, X1 - X2);
        double sint = Math.Sin(theta);
        double cost = Math.Cos(theta);

        Point pt3 = new Point(
            X2 + (HeadWidth * cost - HeadHeight * sint),
            Y2 + (HeadWidth * sint + HeadHeight * cost));

        Point pt4 = new Point(
            X2 + (HeadWidth * cost + HeadHeight * sint),
            Y2 - (HeadHeight * cost - HeadWidth * sint));

        Arrows.Add(new Arrow(new ObservableCollection<Point>() { b, pt3, pt4, b}));
    }

    private void ClearMemory()
    {
        OneGraphElipseMemory = null;
        TwoGraphElipseMemory = null;
        InLineMode = false;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}