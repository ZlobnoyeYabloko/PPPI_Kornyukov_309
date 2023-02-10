using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1
{
    internal class Menu
    {
        int n;
        public Menu(int n)
        {
            this.n = n;
        }
        //Run program that allows user choose case
        public void MenuChoise()
        {
            switch (n)
            {
                case 0:
                    Console.WriteLine("Name of File: ");
                    try
                    {
                        Console.WriteLine("Number of words in text in file: " +
                            Menu.Count(File.ReadAllText(Console.ReadLine())));
                    }
                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;
                case 1:
                    Console.Write("Enter the number A: ");
                    double a = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the number B: ");
                    double b = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter the operation (+, -, *, /): ");
                    char operation = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine(Menu.Calculator(a, b, operation));
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
        }
        // Count words in text in file
        public static int Count(string words)
        {
            return words.Split(' ').Length;
        }
        //Calculate 2 numbers with operation that user choose
        public static double Calculator(double a, double b, char operation)
        {
            switch (operation)
            {
                case '+':
                    Console.WriteLine("{0}+{1}={2}", a, b, a + b);
                    return a + b;
                    break;
                case '-':
                    Console.WriteLine("{0}-{1}={2}", a, b, a - b);
                    return a - b;
                    break;
                case '*':
                    Console.WriteLine("{0}*{1}={2}", a, b, a * b);
                    return a * b;
                    break;
                case '/':
                    Console.WriteLine("{0}/{1}={2}", a, b, a / b);
                    return a / b;
                    break;
                default:
                    Console.WriteLine("Ошибка");
                    return 0;
                    break;
            }
        }
    }
}
