using System.Diagnostics;

class Program
{
    static string ProcessData(string dataName)
    {
        var sw = Stopwatch.StartNew();
        Thread.Sleep(3000);
        sw.Stop();
        return $"Обработка '{dataName}' завершена за {sw.Elapsed.TotalSeconds} секунды";
    }

    static async Task<string> ProcessDataAsync(string dataName)
    {
        var sw = Stopwatch.StartNew();
        await Task.Delay(3000);
        sw.Stop();
        return $"Обработка '{dataName}' завершена за {sw.Elapsed.TotalSeconds} секунды";
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Синхронная обработка");
        var swSync = Stopwatch.StartNew();

        Console.WriteLine(ProcessData("Файл 1"));
        Console.WriteLine(ProcessData("Файл 2"));
        Console.WriteLine(ProcessData("Файл 3"));

        swSync.Stop();
        Console.WriteLine($"Синхронная обработка заняла: {swSync.Elapsed.TotalSeconds} сек.\n");

        Console.WriteLine("Асинхронная обработка");
        var swAsync = Stopwatch.StartNew();

        var task1 = ProcessDataAsync("Файл 1");
        var task2 = ProcessDataAsync("Файл 2");
        var task3 = ProcessDataAsync("Файл 3");

        var results = await Task.WhenAll(task1, task2, task3);

        foreach (var result in results)
        {
            Console.WriteLine(result);
        }

        swAsync.Stop();
        Console.WriteLine($"Асинхронная обработка заняла: {swAsync.Elapsed.TotalSeconds} сек.");
    }
}
