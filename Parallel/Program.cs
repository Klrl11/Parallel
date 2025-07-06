using Parallel;
using System.Diagnostics;


var executors = new IExecutor[]
{
    new ThreadExecutor(),
    new PlinqExecutor(),
};
//int[] sizes = { 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000 };

int[] sizes = {100_000, 1_000_000, 10_000_000};
var sw = Stopwatch.StartNew();


Console.WriteLine("Последовательное выполнение");
foreach (var size in sizes)
{
    sw.Restart();
    long result = CalculateSequential(size);
    sw.Stop();

    var time = sw.ElapsedMilliseconds;
    Console.WriteLine($"Size: {size}, Sum: {result}, ExecutionTime: {time}ms");
}


//Console.WriteLine("Параллельное (для реализации использовать Thread, например List)");
Console.WriteLine("ProcessorCount: " + Environment.ProcessorCount);

foreach (var executor in executors)
{
    Console.WriteLine(executor.GetType().Name);
    foreach (int size in sizes)
    {
        sw.Restart();
        long parallelSum = executor.CalculateSum(size);
        sw.Stop();
        var parallelTime = sw.ElapsedMilliseconds;
        Console.WriteLine($"Size: {size}, ParallelSum: {parallelSum}, ExecutionTime: {parallelTime}ms");
    }
}
static long CalculateSequential(int m)
{
    long sum = 0;
    for (int i = 0; i <= m; i++)
    {       
        sum += i;
    }
    return sum;
}