using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAlgorithms.Algorithms
{
    class BypassInWidth : IAlgorithm
    {
        string _result;
        public string GetResult()
        {
            return _result;
        }

        public void Perform(int BeginList, List<List<int>> Data)
        {
            string width = "";
            Queue<int> que = new Queue<int>();
            que.Enqueue(BeginList);
            while (que.Count > 0)
            {
                int currentNumber = que.Dequeue();
                width += currentNumber;
                for (int i = 0; i < Data[currentNumber - 1].Count; i++)
                {
                    if (Data[currentNumber - 1][i] == 1)
                    {
                        if (width.IndexOf((i + 1).ToString()) == -1 && !que.Contains(i + 1)) que.Enqueue(i + 1);
                    }
                }
            }
            _result = width;
        }
    }
}
