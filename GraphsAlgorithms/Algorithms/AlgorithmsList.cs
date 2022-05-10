namespace GraphsAlgorithms.Algorithms;

class AlgorithmsList
{
    public AlgorithmsList()
    {
        BypassInWidth = new BypassInWidth();
        DetourToTheDepth = new DetourToTheDepth();
        Dijkstra = new Dijkstra();
    }

    public IAlgorithm BypassInWidth { get; }

    public IAlgorithm DetourToTheDepth { get; }
    public IAlgorithm Dijkstra { get; }
}