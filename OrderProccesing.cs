// Online Order Procesing System using Asynchronous Programming

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders
{
    class OrderProcessing
    {
        public static async Task Main(String[] args)
        {
            
            string orderName;

            // Taking orderName as an input from the user
            Console.Write("Hello User, Please enter the Order Name : ");
            orderName = Console.ReadLine();

            await ProcessingOrder();
            
            // Displaying the order status as ready
            Console.WriteLine($"Order for {orderName} is ready");
            
        }

        // Asynchronous Method which Processes the Order for 3 seconds
        public static async Task ProcessingOrder()
        {
            // Processing the order in 3seconds
            Console.WriteLine("Processing Order...");
            await Task.Delay(3000);

        }
    }
}
