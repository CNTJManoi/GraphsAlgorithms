using GraphsAlgorithms.Command;
using GraphsAlgorithms.Model;
using GraphsAlgorithms.Model.Graph;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace GraphsAlgorithms.ViewModel
{
    class GraphDisplayModel : INotifyPropertyChanged
    {
        GraphModel _graph;
        DelegateCommand _leftMouseClick;
        bool _inLineMode;
        GraphElipse _g1;
        GraphElipse _g2;
        public ObservableCollection<GraphElipse> Elipses { get; set; }
        public ObservableCollection<Edge> Edges => _graph.Edges;
        public bool InLineMode
        {
            get => _inLineMode;
            private set => _inLineMode = value;
        }
        private GraphElipse OneGraphElipseMemory
        {
            get => _g1;
            set => _g1 = value;
        }
        private GraphElipse TwoGraphElipseMemory
        {
            get => _g2;
            set => _g2 = value;
        }
        public GraphDisplayModel()
        {
            _graph = new GraphModel();
            Elipses = new ObservableCollection<GraphElipse>();
            InLineMode = false;
        }
        public DelegateCommand LeftMouseClick
        {
            get { return _leftMouseClick ?? (_leftMouseClick = new DelegateCommand(LeftMouse)); }
        }
        private void LeftMouse(object obj)
        {
            Point mousePos = Mouse.GetPosition((IInputElement)obj);
            foreach (var Elipse in Elipses)
            {
                if(ElipseTools.PointInElipse(mousePos, Elipse.MainVertex.X, Elipse.MainVertex.Y, Elipse.Radius))
                {
                    if (!InLineMode)
                    {
                        InLineMode = true;
                        OneGraphElipseMemory = Elipse;
                    }
                    else
                    {
                        if(Elipse == OneGraphElipseMemory)
                        {
                            return;
                        }
                        else
                        {
                            _g2 = Elipse;
                            _graph.AddEdge(OneGraphElipseMemory.MainVertex, TwoGraphElipseMemory.MainVertex);
                            ClearMemory();
                        }
                    }
                    return;
                }
            }
            var vertex = _graph.AddVertex(mousePos);
            Elipses.Add(new GraphElipse(vertex, mousePos.X, mousePos.Y, _graph.Vertexs.Count.ToString()));
            OnPropertyChanged(nameof(Elipses));
        }
        void ClearMemory()
        {
            OneGraphElipseMemory = null;
            TwoGraphElipseMemory = null;
            InLineMode = false;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
