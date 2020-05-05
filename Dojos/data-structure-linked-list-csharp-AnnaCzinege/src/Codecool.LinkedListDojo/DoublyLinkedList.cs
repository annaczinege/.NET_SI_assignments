using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.LinkedListDojo
{
    public class DoublyLinkedList<T>
    {
        private NodeD<T> _head;

        public void Append(T data)
        {
            if (_head == null)
            {
                _head = new NodeD<T>(data);
            }
            else
            {
                _head.AddToEnd(data);
            }
        }

        public void Insert(int index, T data)
        {
            NodeD<T> currentNodeOnIndex = GetItem(index);
            NodeD<T> currentNodeOnPrevIndex = currentNodeOnIndex.Previous;

            if (currentNodeOnIndex == null)
            {
                _head = new NodeD<T>(data);
            }
            else if (currentNodeOnIndex == _head)
            {
                NodeD<T> temp = new NodeD<T>(data);
                temp.Next = currentNodeOnIndex;
                _head = temp;
            }
            else
            {
                NodeD<T> temp = new NodeD<T>(data);
                temp.Next = currentNodeOnIndex;
                currentNodeOnPrevIndex.Next = temp;
            }

        }

        public NodeD<T> GetItem(int index)
        {
            int counter = 0;
            NodeD<T> node = _head;

            if (index < 0)
            {
                return GetTail();
            }

            while (node != null && counter != index)
            {
                if (counter != index)
                {
                    node = node.Next;
                    counter++;
                }
            }

            if (counter != index)
            {
                return null;
            }

            return node;
        }

        private NodeD<T> GetTail()
        {
            NodeD<T> node = _head;

            while (node != null)
            {
                node = node.Next;
            }

            return node;
        }

        public int GetLength()
        {
            int length = 0;
            NodeD<T> node = _head;

            while (node != null)
            {
                node = node.Next;
                length++;
            }

            return length;
        }

        public void Remove(int index)
        {
            NodeD<T> currentNodeOnIndex = GetItem(index);
            NodeD<T> currentNodeOnPrevIndex = currentNodeOnIndex.Previous;

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
