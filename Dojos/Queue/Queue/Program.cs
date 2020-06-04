using System;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            CustomQueue customQueue = new CustomQueue();

            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                customQueue.Enqueue(line);
                Console.WriteLine(customQueue.Peek());
                Console.WriteLine(customQueue.Dequeue());
                Console.WriteLine(customQueue.Peek());
            }
        }
    }
}
