using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace SimpleCalculator
{
    class Program
    {
        // Regex pattern for numbers 0-4
        private static Regex _ArithmeticPat = new Regex(@"^[0-4]");

        /// <summary>
        /// This app can calculate arithmetic operations for two numbers. The user must first select what arithmetic operation to execute. 
        /// Then input two numbers one by one. 
        /// </summary>
        static void Main(string[] args)
        {
            double a = 0;
            double b = 0;
            string choice = null;

            Console.WriteLine("Hello, This is a simple Calculator created in C# Console app !");

            // While is used to be able to continue when an invalid number is input or break when 0 is selected
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("*****  Choice 1 for addition; 2 for subtraction; 3 for multiplication; 4 for division; 0 to quit *******  ");
                Console.WriteLine("Enter your choice : ");
                choice = Console.ReadLine();

                // Check user selected valid arithmetic choice. 
                while (!_ArithmeticPat.IsMatch(choice))
                {
                    Console.WriteLine("Please choose a valid option from list above (0-4)");
                    choice = Console.ReadLine();
                }

                if (choice == "0") { break; }

                if (choice == "1")
                {
                    AddNums();
                }
                else
                {
                    //TODO: Handle when user tries dividing by 0
                    Console.WriteLine("Enter value for the first number : ");

                    // Will not continue the process until a valid number is entered
                    while (!IsNumeric(Console.ReadLine(), out a))
                    {
                        Console.WriteLine("invalid input for first number please try again: ");
                        continue;
                    }

                    Console.WriteLine("Enter value for the second number : ");
                    while (!IsNumeric(Console.ReadLine(), out b))
                    {
                        Console.WriteLine("invalid input for second number please try again: ");
                        continue;
                    }

                    Calculate(choice, a, b);
                }
                
            }

        }

        /// <summary>Used when 'addition' operation is selected. Will print to console the sum of numbers entered. There is no limit on how many numbers can be added</summary>
        static void AddNums()
        {
            List<double> numToAdd = new List<double>();
            double totalSum = 0;
          
            while (true)
            {
                // Asking user to enter next number. Also displaying integer with its ordinal for how many numbers they already entered 
                string numOrdinal = AddOrdinal(numToAdd.Count + 1);
                Console.WriteLine("\nEnter the {0} number to add,\nenter a non-numeric character when you are ready to sum the numbers entered", numOrdinal);

                // Pulling input and either adding it to a list or computing the sum of list
                double inputNum = 0;
                if (double.TryParse(Console.ReadLine(), out inputNum))
                {
                    numToAdd.Add(inputNum);
                }
                else
                {
                    numToAdd.ForEach(x => totalSum += x);
                    Console.WriteLine("**Result = {0:F2} ", totalSum);
                    break;
                }
              
            }

            

        }

        /// <summary>Used to pull ordinal string based on number entered</summary>
        /// <param name="num">Integer that you want to find an ordinal for</param>
        public static string AddOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }

        /// <summary>Calulates the result of arithmetic operaton and prints result to the console.</summary>
        /// <param name="choice">Value for what arithmetic operation to exexcute.</param>
        static void Calculate(string choice,double a = 0,double b = 0)
        {
            switch(choice)
            {
                /* 
                Not needed since we have a seperate function that is executed when 'adding'

                case "1":                    
                    Console.WriteLine("**Result = {0:F2} ", a+b );
                    break;
                */
                case "2":
                    //F2 formats result to include 2 decimals regardless of result
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
        /// <summary>Checks if an string input is a number.</summary>
        /// <param name="input">String that will be checked. </param>
        /// <returns>True If teh string is a number and the input as a double value. Otherwise it returns false.</returns>
        static public bool IsNumeric(string input, out double number)
        {
            return Double.TryParse(input, out number);
        }

        
    }

}
