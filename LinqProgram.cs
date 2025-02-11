using System;
using System.Collections.Generic;



namespace Programs
{
    class LinqProgram
    {
        // Storing the numbers in the list l
        public static  List<int> l=new();
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter the element {i}");
                int x = Convert.ToInt32(Console.ReadLine());
                l.Add(x);

            }
            Console.WriteLine("Below are the numbers entered");
            foreach (int x in l)
            {
                Console.WriteLine(x);
            }

            // Query one -- Numbers greater then 50
            var result = from num in l
                         where num > 50
                         select num;


            Console.WriteLine("\n\nQuery one result");
            Console.WriteLine("Numbers greater then 50 are :");
            foreach (var res in result)
            {
                Console.WriteLine(res);
            }


            // Query two sorts the number in ascending order
            l.Sort();
            Console.WriteLine("\n\nQuery two results ");
            Console.Write("Sorted Numbers are : ");
            foreach (var res in l)
            {
                Console.Write($"{res} ");
            }



            // Query three using lambda Function to compute square of each number
            var squaredNumbers = l.Select(x=> x * x);
            Console.WriteLine("\n\nQuery three results");
            Console.WriteLine("Square of the numbers are : ");

            foreach (var res in squaredNumbers)
            {
                Console.Write($"{res} ");
            }
            Console.WriteLine();

            
        }
        


    }
}
