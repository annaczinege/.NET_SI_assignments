using System;
using System.Collections.Generic;

namespace BinarySearchTreeDojo
{
    public class BinarySearchTree
    {
        private Node _rootNode;
        public Node RootNode { get { return _rootNode; } set { _rootNode = value; } }
        private BinarySearchTree()
        {
        }

        public static BinarySearchTree Build(List<int> elements)
        {
            BinarySearchTree tree = new BinarySearchTree();

            tree.RootNode = tree.BuildTree(elements, 0, elements.Count - 1);

            return tree;
        }

        public Boolean Search(int toFind)
        {
            if (_rootNode != null)
            {
                return _rootNode.Search(toFind);
            }
            return false;
        }

        public void Add(int toAdd)
        {
            if (_rootNode != null)
            {
                _rootNode.Add(toAdd);
            }
            else
            {
                _rootNode = new Node(toAdd);
            }
        }

        public void Remove(int toRemove)
        {
            Node currentNode = _rootNode;
            Node parentNode = _rootNode;

            while (currentNode != null && currentNode.Data != toRemove)
            {
                parentNode = currentNode;

                if (toRemove < currentNode.Data)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            if (currentNode == null)
            {
                return;
            }
        }

        private Node BuildTree(List<int> listOfNumbers, int startIndex, int endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            Node node = new Node(listOfNumbers[midIndex]);

            node.Left = BuildTree(listOfNumbers, startIndex, midIndex - 1);
            node.Right = BuildTree(listOfNumbers, midIndex + 1, endIndex);

            return node;
        }
    }
}
