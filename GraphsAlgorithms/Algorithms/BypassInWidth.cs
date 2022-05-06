using System.Collections.Generic;

namespace GraphsAlgorithms.Algorithms;

internal class BypassInWidth : IAlgorithm
{
    private string _result;

    public string GetResult()
    {
        return _result;
    }

    public void Perform(int BeginList, List<List<int>> Data)
    {
        var width = "";
        var que = new Queue<int>();
        que.Enqueue(BeginList);
        while (que.Count > 0)
        {
            var currentNumber = que.Dequeue();
            width += currentNumber;
            for (var i = 0; i < Data[currentNumber - 1].Count; i++)
                if (Data[currentNumber - 1][i] == 1)
                    if (width.IndexOf((i + 1).ToString()) == -1 && !que.Contains(i + 1))
                        que.Enqueue(i + 1);
        }

        _result = width;
    }
}