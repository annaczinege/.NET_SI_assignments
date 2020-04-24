using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeDojo
{
    public class Node
    {
        private int _data;
        private Node _rightNode;
        private Node _leftNode;
        private bool _isDeleted;
        public int Data { get { return _data; } set { _data = value; } }
        public Node Left { get { return _leftNode; } set { _leftNode = value; } }
        public Node Right { get { return _rightNode; } set { _rightNode = value; } }
        public bool IsDeleted { get {return _isDeleted; } }

        public Node(int data)
        {
            _data = data;
            _isDeleted = false;
        }

        public bool Search(int value)
        {
            if (value == _data && IsDeleted == false)
            {
                return true;
            }
            else if (value < _data && _leftNode != null)
            {
                return _leftNode.Search(value);
            }
            else if (_rightNode != null)
            {
                return _rightNode.Search(value);
            }
            else
            {
                return false;
            }
        }

        public void Add(int value)
        {
            if (value >= _data)
            {
                if (_rightNode == null)
                {
                    _rightNode = new Node(value);
                }
                else
                {
                    _rightNode.Add(value);
                }
            }
            else
            {
                if (_leftNode == null)
                {
                    _leftNode = new Node(value);
                }
                else
                {
                    _leftNode.Add(value);
                }
            }
        }
    }
}
