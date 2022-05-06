using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAlgorithms.Algorithms
{
    class DetourToTheDepth : IAlgorithm
    {
        string _result;
        public string GetResult()
        {
            return _result;
        }

        public void Perform(int BeginList, List<List<int>> Data)
        {
            string depth = "";
            Stack<int> st = new Stack<int>();
            st.Push(BeginList);
            while (st.Count > 0)
            {
                int currentNumber = st.Pop();
                depth += currentNumber;
                for (int i = 0; i < Data[currentNumber - 1].Count; i++)
                {
                    if (Data[currentNumber - 1][i] == 1)
                    {
                        if (depth.IndexOf((i + 1).ToString()) == -1 && !st.Contains(i + 1)) st.Push(i + 1);
                    }
                }
            }
            _result = depth;
        }
    }
}
