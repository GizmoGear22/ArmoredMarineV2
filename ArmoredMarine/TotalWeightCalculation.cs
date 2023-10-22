using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    public class TotalWeightEngine
    {
        List<IWeight> _separateWeights = new List<IWeight>();

        public TotalWeightEngine(IEnumerable<IWeight> separateWeights)
        {
            _separateWeights.AddRange(separateWeights);
        }
    }

    public class WeightCalculator
    {
        public void CalculateTotal(MarineChar character)
        {
            var type = typeof(IWeight);
            var weight = GetType().Assembly.GetTypes();
        }
    }
}
