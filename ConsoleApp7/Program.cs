class Program
{
    static void fun1()
    {
        Console.WriteLine("Function 1 starting.");
        Thread.Sleep(2000);
        Console.WriteLine("Function 1 finished.");
    }
    static async Task fun2()
    {
        Console.WriteLine("Function 2 starting.");
        await Task.Delay(2000);
        Console.WriteLine("Function 2 finished.");
    }
    static async Task fun3()
    {
        Console.WriteLine("Function 3 starting.");
        await Task.Run(() =>
        {
            Thread.Sleep(2000);
        });
        Console.WriteLine("Function 3 finished.");
    }
    static async void fun4()
    {
        Console.WriteLine("Function 4 starting.");
        Thread.Sleep(1000);
        fun1();
        Console.WriteLine("Function 4 finished.");
    }
    static async Task fun5(object arg)
    {
        Console.WriteLine($"Function 5 starting with {arg}...");
        await Task.Delay(2000);
        Console.WriteLine($"Function 5 finished with {arg}.");
    }
    static async Task fun6()
    {
        Console.WriteLine("Function 6 starting.");
        await Task.Delay(1000);
        await fun2();
        Console.WriteLine("Function 6 finished.");
    }
    static void Main(string[] args)
    {
        fun1();

        Console.WriteLine();

        fun2().Wait();

        Console.WriteLine();

        fun3().Wait();

        Console.WriteLine();

        fun4();

        Console.WriteLine();

        fun5("aboba");

        Console.WriteLine();

        fun6().Wait();

        Console.ReadKey();
    }
}