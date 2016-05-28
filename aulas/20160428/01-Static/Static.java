class MyType<T>
{
    private static int val;
    
    public int  getVal()          { return val;  }
    public void setVal(int value) { val = value; }
}

public class Static
{
    public static void main(String[] args)
    {
        MyType<Integer> mt_int = new MyType<Integer>();
        MyType<String>  mt_str = new MyType<String>();
        
        mt_int.setVal(3);
        mt_str.setVal(7);
        
        System.out.println(mt_int.getVal());
        System.out.println(mt_str.getVal());
    }
}
