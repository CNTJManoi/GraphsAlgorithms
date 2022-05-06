using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GraphsAlgorithms.Command;
using GraphsAlgorithms.Model;
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
    }

    public ObservableCollection<GraphElipse> Elipses { get; set; }
    public List<int[]> DataMatrix { get; set; }

    public ObservableCollection<Edge> Edges => _graph.Edges;

    public bool InLineMode { get; private set; }

    private GraphElipse OneGraphElipseMemory { get; set; }

    private GraphElipse TwoGraphElipseMemory { get; set; }

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
                }
                else
                {
                    if (Elipse == OneGraphElipseMemory) return;

                    TwoGraphElipseMemory = Elipse;
                    _graph.AddEdge(OneGraphElipseMemory.MainVertex, TwoGraphElipseMemory.MainVertex, 0);
                    ClearMemory();
                    Service.mw.FillMatrix();
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