namespace Codecool.LinkedListDojo
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public void AddToEnd(T data)
        {
            if (Next == null)
            {
                Next = new Node<T>(data);
            }
            else
            {
                Next.AddToEnd(data);
            }
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
