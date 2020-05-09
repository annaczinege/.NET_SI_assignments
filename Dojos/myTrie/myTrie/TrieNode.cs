using System;
using System.Collections.Generic;
using System.Text;

namespace myTrie
{
    public class TrieNode
    {
        public char Data { get; set; }
        public LinkedList<TrieNode> Children { get; set; }
        public TrieNode Parent { get; set; }
        public bool IsWord { get; set; }

        public TrieNode(char c)
        {
            Data = c;
            Children = new LinkedList<TrieNode>();
            IsWord = false;
        }

        public TrieNode GetChild(char c)
        {
            if (Children != null)
            {
                foreach (TrieNode child in Children)
                {
                    if (child.Data.Equals(c))
                    {
                        return child;
                    }
                }
            }
            return null;
        }

        public List<string> GetWords()
        {
            List<string> listOfWords = new List<string>();
            if (IsWord)
            {
                listOfWords.Add(ToString());
            }
            if (Children != null)
            {
                foreach (var child in Children)
                {
                    if (child != null)
                    {
                        listOfWords.AddRange(child.GetWords());
                    }
                }
            }
            return listOfWords;
        }

        public override string ToString()
        {
            if (Parent == null)
            {
                return "";
            } else
            {
                return Parent.ToString() + new string(new char[] { Data });
            }
        }
    }
}
