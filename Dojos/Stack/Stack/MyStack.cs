using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class MyStack<T>
    {
        private int _maxSize;
        private T[] _items;
        private int _topIndex = -1;

        public MyStack(int maxSize)
        {
            _maxSize = maxSize;
            _items = new T[maxSize];
        }

        public void Push(T value)
        {
            if (_topIndex == _maxSize - 1)
            {
                throw new StackOverflowException("The stack is full!");
            }
            _topIndex++;
            _items[_topIndex] = value;
        }

        public T Pop()
        {
            if (_topIndex == -1)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            T result = _items[_topIndex];
            _topIndex--;
            return result;
        }

        public T Peek()
        {
            if (_topIndex == -1)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            return _items[_topIndex];
        }

        public bool IsEmpty()
        {
            if (_topIndex < 0)
            {
                return true;
            }
            return false;
        }
    }
}
