using System;
using System.Collections.Generic;
using System.Text;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, input integer value.");
            var strBuilder = new StringBuilder();
            var rowCount = Convert.ToInt32(Console.ReadLine());
            var output = Generate(rowCount);
            for (int i = rowCount - 1; i >= 0; i--)
            {
                output[i].ForEach(i => strBuilder.Append($"{i},"));
                Console.WriteLine(strBuilder.ToString().Remove(strBuilder.Length - 1));
                strBuilder = new StringBuilder();
            }
            Console.ReadKey();
        }

        public static List<List<int>> Generate(int numRows)
        {
            var pascalTriangle = new List<List<int>>();
            var previosValues = new List<int>();
            var currentValues = new List<int>();
            currentValues.Add(1);
            pascalTriangle.Add(currentValues);
            for (int i = 1; i < numRows; i++)
            {
                var prevItem = 0;
                foreach (var item in previosValues)
                {
                    var value = prevItem + item;
                    currentValues.Add(value);
                    prevItem = item;
                }
                previosValues = new List<int>(currentValues);
                previosValues.Add(1);
                pascalTriangle.Add(previosValues);
                currentValues = new List<int>();
            }
            return pascalTriangle;
        }
    }
}
