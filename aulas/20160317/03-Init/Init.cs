using System;

class A
{
    private int x = Init.GetX();

    protected virtual int GetValue() { return x; }

    public A()
    {
        Console.WriteLine("A::.ctor");
        Console.WriteLine("GetValue() : " + GetValue());
    }
}

class B : A
{
    private int y = Init.GetY();

    protected override int GetValue() { return y; }

    public B()
    {
        Console.WriteLine("B::.ctor");
    }
}

class C : B
{
    private int z = Init.GetZ();

    protected override int GetValue() { return z; }

    public C()
    {
        Console.WriteLine("C::.ctor");
    }
}

class Init
{
    static internal int GetX()
    {
        Console.WriteLine("A::x");
        return 5;
    }

    static internal int GetY()
    {
        Console.WriteLine("B::y");
        return 6;
    }
    
    static internal int GetZ()
    {
        Console.WriteLine("C::z");
        return 7;
    }
    
    static void Main()
    {
        C obj = new C();
    }
}