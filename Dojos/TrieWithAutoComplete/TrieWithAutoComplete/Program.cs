using System;
using System.Collections.Generic;

public class TrieDataNode
{
    public bool IsTerminating { get; set; }
    public List<TrieDataNode> Children { get; private set; } = new List<TrieDataNode>();

    /// <summary>
    /// Stores the Data id this instance
    /// </summary>
    public char Data
    {
        get; private set;
    }

    /// <summary>
    /// Initializes a TrieDataNode with its data
    /// </summary>
    /// <param name="data">The data in this node</param>
    public TrieDataNode(char data)
    {
        Data = data;
    }

    public void AddChild(TrieDataNode newNode)
    {
        Children.Add(newNode);
    }

    public TrieDataNode GetChildWithChar(char c)
    {
        foreach (var child in Children)
        {
            if (Char.ToLower(child.Data) == Char.ToLower(c))
            {
                return child;
            }
        }
        return null;
    }

    /// <summary>
    /// Converts the value of this instance to its string representation of its Data property. 
    /// </summary>
    /// <returns>The string representation of the Data property of this instance.</returns>
    public override String ToString()
    {
        return Data.ToString();
    }
}

public class AutoComplete
{
    private TrieDataNode _root;

    public AutoComplete()
    {
        _root = new TrieDataNode('-');
    }


    public void AddWord(string wordToAdd)
    {
        if (SearchWord(wordToAdd) == true)
        {
            return;
        }

        TrieDataNode currentNode = _root;

        foreach (var ch in wordToAdd.ToCharArray())
        {
            TrieDataNode child = currentNode.GetChildWithChar(ch);
            if (child != null)
            {
                currentNode = child;
            }
            else
            {
                currentNode.AddChild(new TrieDataNode(ch));
                currentNode = currentNode.GetChildWithChar(ch);
            }
        }
        currentNode.IsTerminating = true;

    }

    private bool SearchWord(string wordToSearch)
    {
        TrieDataNode currentNode = _root;

        foreach (var ch in wordToSearch.ToCharArray())
        {
            if (currentNode.GetChildWithChar(ch) == null)
            {
                return false;
            }
            else
            {
                currentNode = currentNode.GetChildWithChar(ch);
            }
        }

        if (currentNode.IsTerminating == true)
        {
            return true;
        }
        return false;
    }

    public List<string> Complete(string baseChars)
    {
        TrieDataNode lastNode = _root;
        for (int i = 0; i < baseChars.Length; i++)
        {
            lastNode = lastNode.GetChildWithChar(baseChars[i]);
            if (lastNode == null)
            {
                return new List<string>();
            }
        }
        List<string> listOfwords = GetListOfWords(lastNode, baseChars);
        listOfwords.Sort();
        return listOfwords;
    }

    private List<string> GetListOfWords(TrieDataNode node, string prefix)
    {
        List<string> listOfWords = new List<string>();

        if (node.IsTerminating)
        {
            listOfWords.Add(GetWord(node, prefix));
        }

        if (node.Children != null)
        {
            foreach (var child in node.Children)
            {
                if (child != null)
                {
                    string currentPrefix = prefix;
                    currentPrefix += child.ToString();
                    listOfWords.AddRange(GetListOfWords(child, currentPrefix));
                }
            }
        }
        return listOfWords;
    }

    private string GetWord(TrieDataNode node, string prefix)
    {
        TrieDataNode currentNode = _root;
        string result = "";
        while (currentNode != node)
        {
            for (int i = 0; i < prefix.Length; i++)
            {
                currentNode = currentNode.GetChildWithChar(prefix[i]);
                result += currentNode.ToString();
            }
        }
        return result;
    }

}

public class Solution
{
    public static void Main(String[] args)
    {
        AutoComplete autoComplete = new AutoComplete();
        string line;

        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
        {
            string[] parts = line.Split(' ');
            string command = parts[0];
            string param = parts[1];

            if (command == "ADD")
            {
                autoComplete.AddWord(param);
            }
            else if (command == "TEST")
            {
                List<string> words = autoComplete.Complete(param);
                foreach (var word in words)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}