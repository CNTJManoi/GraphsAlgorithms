using System.Collections.Generic;

namespace GraphsAlgorithms.Algorithms;

internal interface IAlgorithm
{
    public string GetResult();
    public void Perform(int BeginList, List<List<int>> Data, int EndList);
}