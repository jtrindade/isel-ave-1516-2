using System;
using System.Collections.Generic;

interface IPutEnd<in T>
{
    void Put(T item);
}

interface ITakeEnd<out T>
{
    T Take();
}

class Queue<T> : IPutEnd<T>, ITakeEnd<T>
{
    private LinkedList<T> list = new LinkedList<T>();
    
    public void Put(T item)
    {
        list.AddLast(item);
    }
    
    public T Take()
    {
        if (list.Count == 0)
            throw new InvalidOperationException();
        
        T res = list.First.Value;
        list.RemoveFirst();
        return res;
    }
}

class A {}
class B : A {}
class C : B {}

class Consumer<T>
{
    private ITakeEnd<T> source;
    
    public Consumer(ITakeEnd<T> source)
    {
        this.source = source;
    }
    
    public void Consume()
    {
        T obj = source.Take();
        Console.WriteLine(obj.GetType().Name);
    }
}

class Producer<T> where T : new()
{
    private IPutEnd<T> sink;
    
    public Producer(IPutEnd<T> sink)
    {
        this.sink = sink;
    }
    
    public void Produce()
    {
        sink.Put(new T());
    }
}

class UseQueue
{
    static void Main()
    {
        /*
        Queue<int> queue = new Queue<int>();
        
        queue.Put(1);
        queue.Put(2);
        queue.Put(3);
        
        Console.WriteLine(queue.Take());
        Console.WriteLine(queue.Take());
        Console.WriteLine(queue.Take());
        */
        
        Queue<B> queue = new Queue<B>();
        
        Producer<C> prod = new Producer<C>(queue);
        Consumer<A> cons = new Consumer<A>(queue);
        
        prod.Produce();
        prod.Produce();
        prod.Produce();

        cons.Consume();
        cons.Consume();
        cons.Consume();
    }
}