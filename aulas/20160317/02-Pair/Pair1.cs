struct Pair
{
    public int i1;
    public int i2;
    
    public Pair(int x) { i1 = x; i2 = -x; }
}

public class UsePair
{
    public static void Main()
    {
        Pair p;
        
        p.i1 = 3;
        p.i2 = 4;
        
        int s = Add(p);
        
        System.Console.WriteLine(s);
        
        System.Console.WriteLine(Add(new Pair()));

        System.Console.WriteLine(Add(new Pair(5)));
        
        Pair p2 = new Pair(8);
        System.Console.WriteLine(Add(p2));
    }
    
    private static int Add(Pair pair)
    {
        return pair.i1 + pair.i2;
    }
}
