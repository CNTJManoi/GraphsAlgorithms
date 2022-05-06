using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAlgorithms.Algorithms
{
    interface IAlgorithm
    {
        public string GetResult();
        public void Perform(int BeginList, List<List<int>> Data);

    }
}
