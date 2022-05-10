using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using GraphsAlgorithms.Algorithms;
using GraphsAlgorithms.Command;
using GraphsAlgorithms.Model;
using GraphsAlgorithms.Model.Graph;

namespace GraphsAlgorithms.ViewModel;

internal class MainViewModel : INotifyPropertyChanged
{
    private readonly AlgorithmsList _algorithms;
    private DelegateCommand _buttonClick;

    public MainViewModel()
    {
        Service.mw = this;
        _algorithms = new AlgorithmsList();
        graphModel = new GraphModel();
        DataMatrix = new List<List<int>>();
        ComboBoxList = new ObservableCollection<int>();
    }

    public List<List<int>> DataMatrix { get; set; }
    public ObservableCollection<int> ComboBoxList { get; set; }
    public int SelectedIndexMenu { get; set; }
    public object SelectedItemCombo { get; set; }
    public object SelectedItemDijkstraOne { get; set; }
    public object SelectedItemDijkstraTwo { get; set; }
    public string Width { get; set; }
    public string Depth { get; set; }

    public DelegateCommand ButtonBegins => _buttonClick ?? (_buttonClick = new DelegateCommand(ButtonBegin));

    public GraphModel graphModel { get; private set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void FillMatrix()
    {
        ComboBoxList.Clear();
        var matrix = new int[graphModel.Vertexs.Count, graphModel.Vertexs.Count];
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            ComboBoxList.Add(i + 1);
            for (var j = 0; j < matrix.GetLength(1); j++) matrix[i, j] = 0;
        }

        foreach (var edge in graphModel.Edges)
        {
            if (SelectedIndexMenu != 0)
            {

                var one = graphModel.Vertexs.IndexOf(edge.Vertex1);
                var two = graphModel.Vertexs.IndexOf(edge.Vertex2);
                int weight = int.Parse(edge.Weight);
                matrix[one, two] = int.Parse(edge.Weight);
            }
            else
            {

                var one = graphModel.Vertexs.IndexOf(edge.Vertex1);
                var two = graphModel.Vertexs.IndexOf(edge.Vertex2);
                int weight = int.Parse(edge.Weight);
                matrix[one, two] = 1;
                matrix[two, one] = 1;
            }
        }

        DataMatrix = new List<List<int>>();
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            var Row = new List<int>();
            for (var j = 0; j < matrix.GetLength(1); j++) Row.Add(matrix[i, j]);
            DataMatrix.Add(Row);
        }

        OnPropertyChanged(nameof(DataMatrix));
        OnPropertyChanged(nameof(ComboBoxList));
    }

    private void ButtonBegin(object obj)
    {
        if (SelectedIndexMenu == 0)
        {
            Width = "";
            Depth = "";
            if (SelectedItemCombo == null)
            {
                Width = "Выберите вершину!";
                OnPropertyChanged(nameof(Width));
                OnPropertyChanged(nameof(Depth));
                return;
            }

            var BeginList = int.Parse(SelectedItemCombo.ToString());


            FillMatrix();
            Width = WidthGo(BeginList, DataMatrix);
            OnPropertyChanged(nameof(Width));

            Depth = DepthGo(BeginList, DataMatrix);
            OnPropertyChanged(nameof(Depth));
        }else if(SelectedIndexMenu == 1)
        {
            var BeginList = int.Parse(SelectedItemDijkstraOne.ToString());
            int EndList = int.Parse(SelectedItemDijkstraTwo.ToString());
            FillMatrix();
            string p = Dijkstra(BeginList, DataMatrix, EndList);
            MessageBox.Show(p);
        }
    }

    private string WidthGo(int BeginList, List<List<int>> Data)
    {
        _algorithms.BypassInWidth.Perform(BeginList, Data, 0);
        return _algorithms.BypassInWidth.GetResult();
    }

    private string DepthGo(int BeginList, List<List<int>> Data)
    {
        _algorithms.DetourToTheDepth.Perform(BeginList, Data, 0);
        return _algorithms.DetourToTheDepth.GetResult();
    }
    private string Dijkstra(int BeginList, List<List<int>> Data, int EndList)
    {
        _algorithms.Dijkstra.Perform(BeginList, Data, EndList);
        return _algorithms.Dijkstra.GetResult();
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}