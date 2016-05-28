using System;

class MyType<T>
{
    private static int val;
    
    public int Val
    {
        get { return val;  }
        set { val = value; }
    }
}

public class Static
{
    public static void Main()
    {
        MyType<int>    mt_int = new MyType<int>();
        MyType<string> mt_str = new MyType<string>();
        
        mt_int.Val = 3;
        mt_str.Val = 7;
        
        Console.WriteLine(mt_int.Val);
        Console.WriteLine(mt_str.Val);
    }
}
