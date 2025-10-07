class Program
    {
        static string ProcessData(string dataName)
        {
            Thread.Sleep(3000);
            return $"Обработка '{dataName}' завершена за 3 секунды";
        }

        static async Task<string> ProcessDataAsync(string dataName)
        {
            await Task.Delay(3000);
            return $"Обработка '{dataName}' завершена за 3 секунды";
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

            var allTasks = new[] { task1, task2, task3 };

            while (allTasks.Length > 0)
            {
                var finished = await Task.WhenAny(allTasks);
                Console.WriteLine(await finished);

                allTasks = Array.FindAll(allTasks, t => !t.IsCompleted);
            }

            var endAsync = DateTime.Now;
            Console.WriteLine($"Асинхронная обработка заняла: {(endAsync - startAsync).TotalSeconds} сек.");
        }
    }