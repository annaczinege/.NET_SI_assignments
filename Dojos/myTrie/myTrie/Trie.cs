using System;
using System.Collections.Generic;
using System.Text;

namespace myTrie
{
    public class Trie
    {
        private TrieNode _root;
        public Trie()
        {
            _root = new TrieNode(' '); 
        }

        public void Insert(string word)
        {
            if (Search(word) == true)
            {
                return;
            }
            TrieNode currentNode = _root;
            TrieNode prefix;
            foreach (var ch in word.ToCharArray())
            {
                prefix = currentNode;
                TrieNode child = currentNode.GetChild(ch);
                if (child != null)
                {
                    currentNode = child;
                    child.Parent = prefix;
                } else
                {
                    currentNode.Children.AddLast(new TrieNode(ch));
                    currentNode = currentNode.GetChild(ch);
                    currentNode.Parent = prefix;
                }
            }
            currentNode.IsWord = true;
        }

        public bool Search(string word)
        {
            TrieNode currentNode = _root;
            foreach (var ch in word.ToCharArray())
            {
                if (currentNode.GetChild(ch) == null)
                {
                    return false;
                }
                else
                {
                    currentNode = currentNode.GetChild(ch);
                }
            }
            if (currentNode.IsWord == true)
            {
                return true;
            }
            return false;
        }

        public List<string> AutoComplete(string prefix)
        {
            TrieNode lastNode = _root;
            for (int i = 0; i < prefix.Length; i++)
            {
                lastNode = lastNode.GetChild(prefix[i]);
                if (lastNode == null)
                {
                    return new List<string>();
                }
            }
            return lastNode.GetWords();
        }
    }
}
