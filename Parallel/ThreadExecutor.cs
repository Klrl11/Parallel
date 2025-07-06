using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel
{
    public class ThreadExecutor : IExecutor
    {
        public long CalculateSum(int m)
        {
            int cores = Environment.ProcessorCount;
            long chunkSize = (m) / cores;
            var threads = new List<Thread>(cores);
            long total = 0;
            object lockObj = new();

            for (int i = 0; i < cores; i++)
            {
                int start = (int)(i * chunkSize);
                int end = (i == cores - 1) ? m : (int)(start + chunkSize - 1);

                Thread t = new(() =>
                {
                    long localSum = 0;
                    for (int num = start; num <= end; num++)                        
                            localSum += num;

                    lock (lockObj) { total += localSum; }
                });

                threads.Add(t);
                t.Start();
            }
            foreach (Thread t in threads) t.Join();
            return total;
        }
    }
}
