using System;

namespace Codecool.LinkedListDojo
{
    public class SinglyLinkedList<T>
    {
        private Node<T> _head;

        /// <summary>
        /// Add a new element to the LinkedList. The new element is appended to the current last item.
        /// </summary>
        /// <param name="data"></param>
        public void Append(T data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts 'data' at 'index' into the list shifting elements if necessary.
        /// e.g. the result of inserting 42 at index 3 into [0, 1, 2, 3, 4] is [0, 1, 2, 42, 3, 4]
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void Insert(int index, T data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the item in the index.
        /// </summary>
        /// <param name="index">Index of desired element. If index is -1 gets the last item.</param>
        /// <returns></returns>
        public Node<T> GetItem(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the amount of elements stored in the Linked list
        /// </summary>
        /// <returns>Amount of elements</returns>
        public int GetLength()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the element at 'index' from the array.
        /// e.g. the result of deleting index 2 from [0, 1, 2, 3, 4] is [0, 1, 3, 4]
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            if (index == 0)
            {
                _head = _head.Next;
                return;
            }

            var currentNode = _head;
            var counter = 0;
            while (counter < index - 1)
            {
                currentNode = currentNode.Next;
                ++counter;

                if (currentNode.Next == null)
                {
                    throw new IndexOutOfRangeException("Tried to remove an invalid item!");
                }
            }
            currentNode.Next = currentNode.Next.Next;
        }

        /// <summary>
        /// Gives back the string representation of the LinkedList
        /// e.g. A LinkedList which contains the following elements: [2,5,543,21]
        /// results the following string "2,5,543,21"
        /// </summary>
        /// <returns>String representation of LinkedList</returns>
        public override string ToString()
        {
            var currentNode = _head;
            if (currentNode == null)
            {
                return "";
            }
            var result = currentNode.ToString();
            do
            {
                currentNode = currentNode.Next;
                result += " " + currentNode;
            } while (currentNode.Next != null);

            return result;
        }
    }
}
