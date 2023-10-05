using System;

public class DynamicList
{
    private class Node
    {
        private object element;
        private Node next;

        public object Element
        {
            get { return element; }
            set { element = value; }
        }

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }

        public Node(object element, Node prevNode)
        {
            this.element = element;
            prevNode.next = this;
        }

        public Node(object element)
        {
            this.element = element;
            this.next = null;
        }
    }

    private Node head;
    private Node tail;
    private int count;

    public DynamicList()
    {
        this.head = null;
        this.tail = null;
        this.count = 0;
    }

    public void Add(object item)
    {
        Node newNode = new Node(item);

        if (this.head == null)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            this.tail.Next = newNode;
            this.tail = newNode;
        }

        this.count++;
    }

    public object Remove(int index)
    {
        if (index < 0 || index >= this.count)
        {
            throw new ArgumentOutOfRangeException("Индексът е извън границите на списъка.");
        }

        if (index == 0)
        {
            object removedItem = this.head.Element;
            this.head = this.head.Next;
            this.count--;
            return removedItem;
        }
        else
        {
            Node prevNode = this.head;
            for (int i = 0; i < index - 1; i++)
            {
                prevNode = prevNode.Next;
            }

            object removedItem = prevNode.Next.Element;
            prevNode.Next = prevNode.Next.Next;
            this.count--;
            return removedItem;
        }
    }

    public int Remove(object item)
    {
        int index = IndexOf(item);

        if (index != -1)
        {
            Remove(index);
        }

        return index;
    }

    public int IndexOf(object item)
    {
        Node currentNode = this.head;
        for (int i = 0; i < this.count; i++)
        {
            if (currentNode.Element.Equals(item))
            {
                return i;
            }

            currentNode = currentNode.Next;
        }

        return -1;
    }

    public bool Contains(object item)
    {
        return IndexOf(item) != -1;
    }

    public object this[int index]
    {
        get
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("Индексът е извън границите на списъка.");
            }

            Node currentNode = this.head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Element;
        }
    }

    public int Count
    {
        get { return this.count; }
    }
}
