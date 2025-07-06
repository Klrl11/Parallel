using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel
{
    internal interface IExecutor
    {
        long CalculateSum(int m);
    }
}
