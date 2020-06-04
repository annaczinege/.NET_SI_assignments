using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    public class CustomQueue
    {
        private Node _head;
        private Node _tail;

        public CustomQueue()
        {
           
        }

        public void Enqueue(string value)
        {
            if (_head == null)
            {
                _head = new Node(value);
                _tail = new Node(value);
            }
            else
            {
                _tail.NextNode = new Node(value);
                _tail = _tail.NextNode;
            }
        }

        public string Peek()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("The queue is empty!");
            }
            return _head.Value;
        }

        public string Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The queue is empty!");
            }
            Node first = _head;
            _head = _head.NextNode;
            return first.Value;
        }

        public bool IsEmpty()
        {
            if (_head == null)
            {
                return true;
            }
            return false;
        }
    }
}
