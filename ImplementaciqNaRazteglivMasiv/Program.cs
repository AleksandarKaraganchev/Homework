using System;

public struct ArrayList<T>
{
    private T[] items;
    private int count;

    public ArrayList(int capacity)
    {
        this.items = new T[capacity];
        this.count = 0;
    }

    public int Count
    {
        get { return this.count; }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Индексът е извън границите на списъка.");
            }

            return this.items[index];
        }
    }

    public void Add(T item)
    {
        if (this.count == this.items.Length)
        {
            // Увеличаваме капацитета на масива два пъти
            int newCapacity = this.items.Length == 0 ? 2 : this.items.Length * 2;
            T[] newItems = new T[newCapacity];

            for (int i = 0; i < this.count; i++)
            {
                newItems[i] = this.items[i];
            }

            this.items = newItems;
        }

        this.items[this.count] = item;
        this.count++;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= this.count)
        {
            throw new IndexOutOfRangeException("Индексът е извън границите на списъка.");
        }

        T removedItem = this.items[index];

        for (int i = index; i < this.count - 1; i++)
        {
            this.items[i] = this.items[i + 1];
        }

        this.count--;

        return removedItem;
    }
}

class Program
{
    static void Main()
    {
        ArrayList<int> list = new ArrayList<int>(2);

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        Console.WriteLine($"Брой на елементите: {list.Count}");
        Console.WriteLine($"Елемент с индекс 2: {list[2]}");

        int removedItem = list.RemoveAt(1);
        Console.WriteLine($"Премахнат елемент: {removedItem}");

        Console.WriteLine($"Брой на елементите след премахване: {list.Count}");
    }
}
