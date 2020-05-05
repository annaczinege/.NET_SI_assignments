using System;

namespace Codecool.LinkedListDojo
{
    public class SinglyLinkedList<T>
    {
        private Node<T> _head;
        //private int _length = 0;
        // I could use this private field to count length,
        // But here I have the GetLength method for it.
        // Similarly I could have a private field to the tail but I have a method for that.

        /// <summary>
        /// Add a new element to the LinkedList. The new element is appended to the current last item.
        /// </summary>
        /// <param name="data"></param>
        public void Append(T data)
        {
            if (_head == null)
            {
                _head = new Node<T>(data);
            }
            else
            {
                _head.AddToEnd(data);
            }
        }

        /// <summary>
        /// Inserts 'data' at 'index' into the list shifting elements if necessary.
        /// e.g. the result of inserting 42 at index 3 into [0, 1, 2, 3, 4] is [0, 1, 2, 42, 3, 4]
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void Insert(int index, T data)
        {
            Node<T> currentNodeOnIndex = GetItem(index);
            Node<T> currentNodeOnPrevIndex = GetItem(index - 1);

            if (currentNodeOnIndex == null)
            {
                _head = new Node<T>(data);
            }
            else if (currentNodeOnIndex == _head)
            {
                Node<T> temp = new Node<T>(data);
                temp.Next = currentNodeOnIndex;
                _head = temp;
            }
            else
            {
                Node<T> temp = new Node<T>(data);
                temp.Next = currentNodeOnIndex;
                currentNodeOnPrevIndex.Next = temp;
            }

        }

        /// <summary>
        /// Gets the item in the index.
        /// </summary>
        /// <param name="index">Index of desired element. If index is -1 gets the last item.</param>
        /// <returns></returns>
        public Node<T> GetItem(int index)
        {
            int counter = 0;
            Node<T> node = _head;

            if (index < 0)
            {
                return GetTail();
            }

            while (node != null && counter != index)
            {
                node = node.Next;
                counter++;
            }

            if ( counter != index)
            {
                return null;
            }

            return node;
        }

        private Node<T> GetTail()
        {
            Node<T> node = _head;

            while (node != null)
            {
                node = node.Next;
            }

            return node;
        }

        /// <summary>
        /// Returns the amount of elements stored in the Linked list
        /// </summary>
        /// <returns>Amount of elements</returns>
        public int GetLength()
        {
            int length = 0;
            Node<T> node = _head;

            while (node != null)
            {
                node = node.Next;
                length++;
            }

            return length;
        }

        /// <summary>
        /// Deletes the element at 'index' from the array.
        /// e.g. the result of deleting index 2 from [0, 1, 2, 3, 4] is [0, 1, 3, 4]
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            Node<T> currentNodeOnIndex = GetItem(index);
            Node<T> currentNodeOnPrevIndex = GetItem(index - 1);

            if (currentNodeOnIndex == null)
            {
                throw new IndexOutOfRangeException("Tried to remove an invalid item!");
            }
            else if (currentNodeOnIndex == _head)
            {
                _head = _head.Next;
            }
            else
            {
                currentNodeOnPrevIndex.Next = currentNodeOnIndex.Next;
            }
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
