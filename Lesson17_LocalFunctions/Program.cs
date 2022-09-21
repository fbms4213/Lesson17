namespace Lesson17_LocalFunctions;

#nullable disable


static class Test{}


class Program
{
    static void DoSomething(int value)
    {
        int x = 10;


        Console.WriteLine("DoSomething");


        // void Helper()
        static void Helper(int x, int y)
        {
            Console.WriteLine("local function");
            Console.WriteLine($"local function {x}");
            Console.WriteLine($"local function {y}");
        }


        Helper(x, value);
        Helper(x, value);
    }


    static void Main()
    {
        DoSomething(42);
    }
}