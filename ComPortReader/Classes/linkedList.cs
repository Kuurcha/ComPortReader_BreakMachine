using System;
using System.CodeDom.Compiler;
using System.Runtime.Remoting.Messaging;

public class TwoCordLinkedList
{
    public class Node
    {
        private Node next;
        public Node Next
        {
            get { return next; }
            set { next = value; }
        }
        private Node prev;
        public Node Prev
        {
            get { return prev; }
            set { prev = value; }
        }
        private double x { get; set; }
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        private double y { get; set; }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public Node() { }
        public Node(double x, double y)
        {
            Y = y;
            X = x;
        }
            public Node (double x, double y,Node next, Node prev)
        {
            X = x;
            Y = y;
            Next = next;
            Prev = prev;
        }



    }
    public Node Head { get; set; }
	public TwoCordLinkedList()
	{
        Head = new Node();
        Head.Next = Head;
        Head.Prev = Head;
	}
    /// <summary>
    /// Подсчет элементов списка
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    internal int Count()
    {
        int count = 0;
        if (Head != null)
        {

            if (Head.Prev!=null)
            {
                Node temp = Head.Prev;
                while (temp != Head)
                {
                    temp = temp.Prev;
                    count++;
                }
            }
        }
            return count;
    }
    public Node ElemNumber(int index)
    {
        Node temp = null;
        if (Head!=null && Head.Prev !=null)
        {
            temp = Head.Prev;
            int counter = 0;
            while (counter < index && temp != Head)
            {
                counter++;
                temp = temp.Prev;
            }
          }
        return temp;
    }
      
    
    public void addLast(Node temp)
    {
        if (temp!= null & Head != null)
        {
            if (Head.Prev == Head)
            {
                temp.Next = Head;
                temp.Prev = Head;
                Head.Next = temp;
                Head.Prev = temp;
            }
            else
            {
                Head.Prev.Next = temp;
                temp.Prev = Head.Prev;
                temp.Next = Head;
                Head.Prev = temp;
            }

            //if (Head.Prev == Head)
            //{
            //    temp.Prev = Head;
            //    temp.Next = Head;
            //    Head.Prev = temp;
            //    Head.Next = temp;
            //}
            //else
            //{
            //    temp.Next = Head; 
            //    temp.Prev = Head.Prev;
            //    Head.Prev = temp;
            //}
           
        }
    }
}
