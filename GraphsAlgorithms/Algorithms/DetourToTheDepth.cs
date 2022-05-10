using System.Collections.Generic;

namespace GraphsAlgorithms.Algorithms;

internal class DetourToTheDepth : IAlgorithm
{
    private string _result;

    public string GetResult()
    {
        return _result;
    }

    public void Perform(int BeginList, List<List<int>> Data, int EndList = 0)
    {
        var depth = "";
        var st = new Stack<int>();
        st.Push(BeginList);
        while (st.Count > 0)
        {
            var currentNumber = st.Pop();
            depth += currentNumber;
            for (var i = 0; i < Data[currentNumber - 1].Count; i++)
                if (Data[currentNumber - 1][i] > 0)
                    if (depth.IndexOf((i + 1).ToString()) == -1 && !st.Contains(i + 1))
                        st.Push(i + 1);
        }

        _result = depth;
    }
}