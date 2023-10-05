using System;

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        CustomArrayList list = new CustomArrayList();

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        Console.WriteLine($"Брой на елементите: {list.Count}");
        Console.WriteLine($"Елемент с индекс 2: {list[2]}");

        int removedItem = (int)list.Remove(1);
        Console.WriteLine($"Премахнат елемент: {removedItem}");

        Console.WriteLine($"Брой на елементите след премахване: {list.Count}");
    }
}
public class CustomArrayList
{
    private object[] arr;
    private int count;

    public int Count
    {
        get { return count; }
    }

    private static readonly int INITIAL_CAPACITY = 4;

    public CustomArrayList()
    {
        arr = new object[INITIAL_CAPACITY];
        count = 0;
    }

    public void Add(object item)
    {
        EnsureCapacity();
        arr[count++] = item;
    }

    public void Insert(int index, object item)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentOutOfRangeException("Индексът е извън границите на списъка.");
        }

        EnsureCapacity();

        for (int i = count; i > index; i--)
        {
            arr[i] = arr[i - 1];
        }

        arr[index] = item;
        count++;
    }

    public int IndexOf(object item)
    {
        for (int i = 0; i < count; i++)
        {
            if (arr[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    public void Clear()
    {
        arr = new object[INITIAL_CAPACITY];
        count = 0;
    }

    public bool Contains(object item)
    {
        return IndexOf(item) != -1;
    }

    public object this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("Индексът е извън границите на списъка.");
            }

            return arr[index];
        }
    }

    public object Remove(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException("Индексът е извън границите на списъка.");
        }

        object removedItem = arr[index];

        for (int i = index; i < count - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        arr[count - 1] = null;
        count--;

        return removedItem;
    }

    public int Remove(object item)
    {
        int index = IndexOf(item);

        if (index != -1)
        {
            Remove(index);
            return index;
        }

        return -1;
    }

    private void EnsureCapacity()
    {
        if (count == arr.Length)
        {
            int newCapacity = arr.Length * 2;
            Array.Resize(ref arr, newCapacity);
        }
    }
}
