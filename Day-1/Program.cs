using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Input Demo in C# ===");

        // 1. Read string input
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine($"Hello, {name}!");

        // 2. Read single key
        Console.Write("Press any key: ");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.WriteLine($"\nYou pressed: {keyInfo.Key}");

        // 3. Integer input using ReadLine + Parse
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine($"You are {age} years old.");

        // 4. Safe Integer input using TryParse
        Console.Write("Enter a number (safe input): ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int number))
        {
            Console.WriteLine($"You entered valid number: {number}");
        }
        else
        {
            Console.WriteLine("Invalid number entered!");
        }

        // 5. Float input
        Console.Write("Enter your height (in meters): ");
        float height = float.Parse(Console.ReadLine());
        Console.WriteLine($"Your height is {height}m.");

        // 6. Double input
        Console.Write("Enter a decimal value: ");
        double dval = double.Parse(Console.ReadLine());
        Console.WriteLine($"Double value: {dval}");

        // 7. Boolean input
        Console.Write("Enter true/false: ");
        bool bval = bool.Parse(Console.ReadLine());
        Console.WriteLine($"Boolean value: {bval}");

        // 8. Character input
        Console.Write("Enter a single character: ");
        char ch = Console.ReadLine()[0];
        Console.WriteLine($"Character entered: {ch}");
    }
}
