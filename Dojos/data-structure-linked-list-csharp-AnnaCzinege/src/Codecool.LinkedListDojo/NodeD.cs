using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.LinkedListDojo
{
    public class NodeD<T>
    {
        public T Data { get; set; }
        public NodeD<T> Next { get; set; }
        public NodeD<T> Previous { get; set; }

        public NodeD(T data)
        {
            Data = data;
        }

        internal void AddToEnd(T data)
        {
            if (Next == null)
            {
                Next = new NodeD<T>(data);
            }
            else
            {
                Next.AddToEnd(data);
            }
        }
    }

}
