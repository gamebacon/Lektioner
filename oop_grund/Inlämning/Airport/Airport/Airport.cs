using System;
using System.Collections.Generic;

namespace Airport
{
    internal class Airport
    {
        private List<Terminal> terminals = new List<Terminal>();
        private string name;

        public static void Main(string[] args)
        {
            while (true)
            {
                
                Console.WriteLine("Hello traveler!");

                Console.WriteLine("Where would you like to travel?!");
                string input = Console.ReadLine();

                if (input.Equals("NO"))
                {
                    break;
                }
            }
            
        }

        public string GetName()
        {
            return name;
        }
    }
}