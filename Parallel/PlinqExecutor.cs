using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel
{
    public class PlinqExecutor : IExecutor
    {
        
        public long CalculateSum(int m)
        {
            return Enumerable.Range(0, m + 1)
                .AsParallel()
                .WithDegreeOfParallelism(Environment.ProcessorCount)
                .Sum(x => (long)x);
        }
    }
}
