using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAlgorithms.Algorithms
{
    class AlgorithmsList
    {
        IAlgorithm _bypassInWidth;
        IAlgorithm _detourToTheDepth;
        public AlgorithmsList()
        {
            _bypassInWidth = new BypassInWidth();
            _detourToTheDepth = new DetourToTheDepth();
        }
        public IAlgorithm BypassInWidth { get { return _bypassInWidth; } }
        public IAlgorithm DetourToTheDepth { get { return _detourToTheDepth; } }
    }
}
