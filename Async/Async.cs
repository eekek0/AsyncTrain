class Program
    {
        static string ProcessData(string dataName)
        {
            var startSync = DateTime.Now;
            Thread.Sleep(3000);
            var endSync = DateTime.Now;
            return $"Обработка '{dataName}' завершена за  {(endSync - startSync).TotalSeconds} секунды";
        }

        static async Task<string> ProcessDataAsync(string dataName)
        {
            var startAsync = DateTime.Now;
            await Task.Delay(3000);
            var endAsync = DateTime.Now;
        return $"Обработка '{dataName}' завершена за  {(endAsync - startAsync).TotalSeconds} секунды";

        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Синхронная обработка");
            var startSync = DateTime.Now;

            Console.WriteLine(ProcessData("Файл 1"));
            Console.WriteLine(ProcessData("Файл 2"));
            Console.WriteLine(ProcessData("Файл 3"));

            var endSync = DateTime.Now;
            Console.WriteLine($"Синхронная обработка заняла: {(endSync - startSync).TotalSeconds} сек.\n");

            Console.WriteLine("Асинхронная обработка");
            var startAsync = DateTime.Now;

            var task1 = ProcessDataAsync("Файл 1");
            var task2 = ProcessDataAsync("Файл 2");
            var task3 = ProcessDataAsync("Файл 3");

            var results = await Task.WhenAll(task1, task2, task3);

            foreach (var result in results)
                {
                    Console.WriteLine(result);
                }

        var endAsync = DateTime.Now;
            Console.WriteLine($"Асинхронная обработка заняла: {(endAsync - startAsync).TotalSeconds} сек.");
        }
    }