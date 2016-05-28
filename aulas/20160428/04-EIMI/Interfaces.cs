using System;
using System.Collections;
using System.Collections.Generic;

class MyEnumerable<T> : IEnumerable<T>
{
    public IEnumerator<T> GetEnumerator()
    {
        Console.WriteLine("MyEnumerable<T>.GetEnumerator");
        return null;
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        Console.WriteLine("IEnumerable.GetEnumerator");
        return null;
    }
}

public class Interfaces
{
    public static void Main()
    {
        MyEnumerable<int> en = new MyEnumerable<int>();
        IEnumerable ee = en;

        // Duas versões de GetEnumerator diferem apenas no tipo de retorno.
        // Implementação explícita da interface IEnumerable evita a ambiguidade. 
        en.GetEnumerator();
        ee.GetEnumerator();
    }
}