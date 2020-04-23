using System;
using System.Collections.Generic;

namespace BinarySearchTreeDojo
{
    public class BinarySearchTree
    {
        private readonly List<int> _treeElements;
        private BinarySearchTree(List<int> intList)
        {
            _treeElements = intList;
        }

        public static BinarySearchTree Build(List<int> elements)
        {
            BinarySearchTree tree = new BinarySearchTree(elements);
            return tree;
        }
    
        public Boolean Search(int toFind) {
            
            return false;
        }

        public void Add(int toAdd) {
            // TODO adds an element. Throws an error if it exist.
        }

        public void Remove(int toRemove) {
            // TODO removes an element. Throws an error if its not on the tree.
        }     
    }
}
