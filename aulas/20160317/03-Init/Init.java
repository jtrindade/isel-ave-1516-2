class A
{
    private int x = Init.GetX();

    protected int GetValue() { return x; }
    
    public A()
    {
        System.out.println("A::.ctor");
        System.out.println("GetValue() : " + GetValue());
    }
}

class B extends A
{
    private int y = Init.GetY();

    protected int GetValue() { return y; }

    public B()
    {
        System.out.println("B::.ctor");
    }
}

class C extends B
{
    private int z = Init.GetZ();

    protected int GetValue() { return z; }

    public C()
    {
        System.out.println("C::.ctor");
    }
}

public class Init
{
    static int GetX()
    {
        System.out.println("A::x");
        return 5;
    }

    static int GetY()
    {
        System.out.println("B::y");
        return 6;
    }
    
    static int GetZ()
    {
        System.out.println("C::z");
        return 7;
    }
    
    public static void main(String[] args)
    {
        C obj = new C();
    }
}
