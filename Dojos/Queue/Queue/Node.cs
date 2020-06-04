using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    public class Node
    {
        public string Value { get; set; }
        public Node NextNode { get; set; }

        public Node(string value)
        {
            Value = value;
        }
    }
}
