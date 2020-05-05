using System;

namespace Codecool.LinkedListDojo
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> singlyLinkedList = new SinglyLinkedList<int>();
            singlyLinkedList.Append(9);
            singlyLinkedList.Append(5);
            singlyLinkedList.Append(7);
            singlyLinkedList.Append(11);
            Console.ReadKey();
        }
    }
}
