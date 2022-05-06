namespace GraphsAlgorithms.Algorithms;

class AlgorithmsList
{
    public AlgorithmsList()
    {
        BypassInWidth = new BypassInWidth();
        DetourToTheDepth = new DetourToTheDepth();
    }

    public IAlgorithm BypassInWidth { get; }

    public IAlgorithm DetourToTheDepth { get; }
}