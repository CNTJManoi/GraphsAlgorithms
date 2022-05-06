using GraphsAlgorithms.Command;
using GraphsAlgorithms.Model;
using GraphsAlgorithms.Model.Graph;
using GraphsAlgorithms.Algorithms;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAlgorithms.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        GraphModel _graph;
        AlgorithmsList _algorithms;
        DelegateCommand _buttonClick;
        public List<List<int>> DataMatrix { get; set; }
        public ObservableCollection<int> ComboBoxList { get; set; }
        public object SelectedItemCombo { get; set; }
        public string Width { get; set; }
        public string Depth { get; set; }
        public MainViewModel()
        {
            Service.mw = this;
            _algorithms = new AlgorithmsList();
            graphModel = new GraphModel();
            DataMatrix = new List<List<int>>();
            ComboBoxList = new ObservableCollection<int>();
        }
        public void FillMatrix()
        {
            ComboBoxList.Clear();
            int[,] matrix = new int[_graph.Vertexs.Count, _graph.Vertexs.Count];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                ComboBoxList.Add(i + 1);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }
            foreach (var edge in _graph.Edges)
            {
                int one = _graph.Vertexs.IndexOf(edge.Vertex1);
                int two = _graph.Vertexs.IndexOf(edge.Vertex2);
                matrix[one, two] = 1;
                matrix[two, one] = 1;
            }
            DataMatrix = new List<List<int>>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                List<int> Row = new List<int>();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Row.Add( matrix[i, j]);
                }
                    DataMatrix.Add(Row);
            }
            OnPropertyChanged(nameof(DataMatrix));
            OnPropertyChanged(nameof(ComboBoxList));
        }
        public DelegateCommand ButtonBegins
        {
            get { return _buttonClick ?? (_buttonClick = new DelegateCommand(ButtonBegin)); }
        }
        private void ButtonBegin(object obj)
        {
            Width = "";
            Depth = "";
            if(SelectedItemCombo == null)
            {
                Width = "Выберите вершину!";
                OnPropertyChanged(nameof(Width));
                OnPropertyChanged(nameof(Depth));
                return;
            }
            var BeginList = int.Parse(SelectedItemCombo.ToString());
            
            
            Width = WidthGo(BeginList, DataMatrix);
            OnPropertyChanged(nameof(Width));
            
            Depth = DepthGo(BeginList, DataMatrix);
            OnPropertyChanged(nameof(Depth));
        }
        string WidthGo(int BeginList, List<List<int>> Data)
        {
            _algorithms.BypassInWidth.Perform(BeginList, Data);
            return _algorithms.BypassInWidth.GetResult();
        }
        string DepthGo(int BeginList, List<List<int>> Data)
        {
            _algorithms.DetourToTheDepth.Perform(BeginList, Data);
            return _algorithms.DetourToTheDepth.GetResult();
        }
        public GraphModel graphModel { get { return _graph; } private set { _graph = value; } }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
