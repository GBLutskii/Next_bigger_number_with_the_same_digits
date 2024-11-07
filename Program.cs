using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars_next_bigger_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long number = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine(Kata.NextBiggerNumber(number));

            Console.ReadKey();
        }
    }
}
