using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Calculate(string choice,double a = 0,double b = 0)
        {
            switch(choice)
            {
                case "1":
                    Console.WriteLine("**Result = {0:F2} ", a+b );
                    break;
                case "2":
                    Console.WriteLine("**Result = {0:F2} ", a - b);
                    break;
                case "3":
                    Console.WriteLine("**Result = {0:F2} ", a * b);
                    break;
                case "4":
                    Console.WriteLine("**Result = {0:F2} ", a/b);
                    break;
                default:
                    Console.WriteLine("Unknown choice");
                    break;
            }
        }

        static public bool IsNumeric(string input, out double number)
        {
            return Double.TryParse(input, out number);
        }

        static void Main(string[] args)
        {          
            double a = 0;
            double b = 0;
            string choice = null;

            Console.WriteLine("Hello, This is a simple Calculator created in C# Console app !");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("*****  Choice 1 for addition; 2 for subtraction; 3 for multiplication; 4 for division; 0 to quit *******  ");
                Console.WriteLine("Enter your choice : ");
                choice = Console.ReadLine();

                if ( choice == "0") { break;  }

                Console.WriteLine("Enter value for the first number : ");
                
                if (!IsNumeric(Console.ReadLine(), out a))
                {
                    Console.WriteLine("invalid number input : ");
                    continue;
                };
                
                Console.WriteLine("Enter value for the second number : ");
                if (!IsNumeric(Console.ReadLine(), out b))
                {
                    Console.WriteLine("invalid number input : ");
                    continue;
                };

                Calculate(choice,a,b);
            }

        }
    }
}
