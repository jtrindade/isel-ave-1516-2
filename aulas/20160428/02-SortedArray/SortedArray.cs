using System;

public class SortedArray<T> where T : IComparable<T>
{
    private int count;
    private T[] items;
    
    public SortedArray(int capacity)
    {
        items = new T[capacity];
    }
    
    public int Capacity
    {
        get { return items.Length; }
    }
    
    public int Count
    {
        get { return count; }
    }
    
    public void Add(T item)
    {
        if (Count == Capacity)
            throw new InvalidOperationException("The array is full");
        
        int i;
        for (i = count; i > 0 && items[i-1].CompareTo(item) > 0; --i)
        {
            items[i] = items[i-1];
        }
        items[i] = item;
        count += 1;
    }
    
    public T this[int idx]
    {
        get { return items[idx]; }
    }
}

public class UseSortedArray
{
    public static void Main()
    {
        SortedArray<int> coll = new SortedArray<int>(8);
        coll.Add(3);
        coll.Add(1);
        coll.Add(5);
        coll.Add(-1);
        
        for (int i = 0; i < coll.Count; ++i)
        {
            Console.WriteLine(coll[i]);
        }
    }
}
