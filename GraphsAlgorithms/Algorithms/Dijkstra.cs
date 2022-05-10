using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAlgorithms.Algorithms
{
    class Dijkstra : IAlgorithm
    {
        private string _result;
        private int MatrixSize;
        public string GetResult()
        {
            if (_result != null) return _result;
            else return null;
        }

        public void Perform(int BeginList, List<List<int>> Data, int EndList)
        {
            MatrixSize = Data.Count();
            var dist = new int[Data.Count];

            var checkPoint = new bool[Data.Count];

            for (int i = 0; i < Data.Count; i++) //Заполняем масив кратчайших путей и посещенных точек
            {
                dist[i] = int.MaxValue;
                checkPoint[i] = false;
            }

            dist[BeginList - 1] = 0;

            for (int i = 0; i < Data.Count - 1; i++)
            {

                var minDist = MinDistance(dist, checkPoint);

                checkPoint[minDist] = true;

                for (int j = 0; j < MatrixSize; j++)

                    if (!checkPoint[j] && Data[minDist][j] != 0 && dist[minDist] != int.MaxValue && dist[minDist] + Data[minDist][j] < dist[j])
                        dist[j] = dist[minDist] + Data[minDist][j];
            }
            string res = "";
            if(EndList != 0)
            {
                res = "Из " + BeginList + " в " + EndList + " = " + dist[EndList - 1];
            }
            _result = res;
        }
        private int MinDistance(int[] dist, bool[] sptSet)
        {
            var min = int.MaxValue;
            var minIndex = -1;

            for (int i = 0; i < MatrixSize; i++)
            {
                if (sptSet[i] == false && dist[i] <= min)
                {
                    min = dist[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }
}
