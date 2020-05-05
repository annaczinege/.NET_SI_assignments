using System;
using System.Collections.Generic;
using System.Text;

namespace MinHeap
{
    public class MinIntHeap
    {
        private static int _capacity = 10;
        private int _size = 0;

        private int[] items = new int[_capacity];

        private int getLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int getRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private int getParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private bool hasLeftChild(int index)
        {
            return getLeftChildIndex(index) < _size;
        }

        private bool hasRightChild(int index)
        {
            return getRightChildIndex(index) < _size;
        }

        private bool hasParent(int index)
        {
            return getParentIndex(index) >= 0;
        }

        private int LeftChild(int index)
        {
            return items[getLeftChildIndex(index)];
        }

        private int RightChild(int index)
        {
            return items[getRightChildIndex(index)];
        }

        private int Parent(int index)
        {
            return items[getParentIndex(index)];
        }

        private void Swap(int indexOne, int indexTwo)
        {
            int temp = items[indexOne];
            items[indexOne] = items[indexTwo];
            items[indexTwo] = temp;
        }

        private void EnsureExtraCapacity()
        {
            if (_size == _capacity)
            {
                Array.Resize(ref items, _capacity * 2);
                _capacity *= 2;
            }
        }

        /// <summary>
        /// Returns the minimum (root) element from the heap.
        /// </summary>
        /// <returns></returns>
        public int Peek()
        {
            if (_size == 0) throw new NullReferenceException();
            return items[0];
        }

        /// <summary>
        /// Removes and returns the minimum (root) element from the heap.
        /// </summary>
        /// <returns></returns>
        public int Poll()
        {
            if (_size == 0) throw new NullReferenceException();
            int item = items[0];
            items[0] = items[_size - 1];
            _size--;
            BubbleDown();
            return item;
        }

        public void Add(int item)
        {
            EnsureExtraCapacity();
            items[_size] = item;
            _size++;
            BubbleUp();
        }

        private void BubbleUp()
        {
            int index = _size - 1;

            while (hasParent(index) && Parent(index) > items[index])
            {
                Swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }

        private void BubbleDown()
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int smallerChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && RightChild(index) < LeftChild(index))
                {
                    smallerChildIndex = getRightChildIndex(index);
                }

                if (items[index] < items[smallerChildIndex])
                {
                    break;
                }
                else
                {
                    Swap(index, smallerChildIndex);
                }
                index = smallerChildIndex;
            }
        }
    }
}
