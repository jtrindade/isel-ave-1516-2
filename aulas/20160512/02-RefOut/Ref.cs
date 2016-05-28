using System;

class Ref
{
    static int Oper(int arg1, ref int arg2, out int arg3)
    {
        Console.WriteLine("arg1: {0}", arg1);
        Console.WriteLine("arg2: {0}", arg2);
        //Console.WriteLine("arg3: {0}", arg3);
        
        arg2 = 22;
        arg3 = 33;
        return 44;
    }
    
    static void Main()
    {
        
        int val1 = 1;
        int val2 = 2;
        int val3 = 3;
        
        int res = Oper(val1, ref val2, out val3);
        
        Console.WriteLine("val1: {0}", val1);
        Console.WriteLine("val2: {0}", val2);
        Console.WriteLine("val3: {0}", val3);
    }
}