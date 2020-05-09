using System;
using System.Collections.Generic;

namespace myTrie
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.Insert("amazon");
            trie.Insert("amazon prime");
            trie.Insert("amazing");
            trie.Insert("amazing spider man");
            trie.Insert("amazed");
            trie.Insert("alibaba");
            trie.Insert("ali express");
            trie.Insert("ebay");
            trie.Insert("walmart");
            List<string> a = trie.AutoComplete("amaz");
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }
    }
}
