using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{


    public class WeightCalculator
    {
        List<IWeight> _weightList = new List<IWeight>();  
        public WeightCalculator(IEnumerable<IWeight>separateWeights) 
        {
            _weightList.AddRange(separateWeights);
        }

    }
}
