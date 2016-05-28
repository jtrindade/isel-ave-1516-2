using System;
using System.Collections;
using System.Collections.Generic;

public class Gen1
{
    public static double Average1(IEnumerable items)
    {
        double acc = 0.0;
        int num = 0;
        foreach (Object obj in items)
        {
            acc += (int)obj;
            num += 1;
        }
        return num > 0 ? acc/num : acc;
    }
    
    public static double Average2(IEnumerable<int> items)
    {
        double acc = 0.0;
        int num = 0;
        foreach (int obj in items)
        {
            acc += obj;
            num += 1;
        }
        return num > 0 ? acc/num : acc;
    }
    
    public static void Example()
    {
        Console.WriteLine(Average1(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        Console.WriteLine(Average2(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        Console.WriteLine(Average1(new double[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0 }));
    }
}        

class Use<T>
{
    private T val;
    
    public T Val
    {
        get { return val; }
        set { val = value; }
    }    
}

public class Gen2
{
    public static void Example()
    {
        Use<string> obj1 = new Use<string>();
        obj1.Val = "abc";
        Console.WriteLine(obj1.Val);
        
        Use<int> obj2 = new Use<int>();
        obj2.Val = 88;
        Console.WriteLine(obj2.Val + 2);
    }
}

public class Generics
{
    public static void Main()
    {
        Gen1.Example();
        Gen2.Example();
    }
}
