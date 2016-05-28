using System;

class Comp
{
    struct Point
    {
        public int x;
        public int y;
        
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }
        
        public override bool Equals(Object other)
        {
            return (other is Point) && this == (Point)other;
        }
        
        public bool Equals(Point other)
        {
            return this == other;
        }
        
        public static bool operator ==(Point p1, Point p2)
        {
            return p1.x == p2.x && p1.y == p2.y;
        }
        
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }
    }

    static void Main()
    {
        string s1 = "alpha";
        string s2 = "alpha";
        
        string s3 = s1 + 's';
        string s4 = s1 + 's';
        
        Console.WriteLine("s1 == s2 ? {0}", s1 == s2);
        Console.WriteLine("s3 == s4 ? {0}", s3 == s4);
        
        Console.WriteLine("s1 same as s2 ? {0}",
                          Object.ReferenceEquals(s1, s2));
        Console.WriteLine("s3 same as s4 ? {0}",
                          Object.ReferenceEquals(s3, s4));
                          
        Console.WriteLine("s1 equivalent to s2 ? {0}",
                          s1.Equals(s2));
        Console.WriteLine("s3 equivalent to s4 ? {0}",
                          s3.Equals(s4));

        object os3 = s3;
        object os4 = s4;
                          
        Console.WriteLine("os3 == os4 ? {0}", os3 == os4);
        Console.WriteLine("os3 same as os4 ? {0}",
                           Object.ReferenceEquals(os3, os4));

        //Console.WriteLine("s3 == os4 ? {0}", s3 == os4);
        //Console.WriteLine("os3 == s4 ? {0}", os3 == s4);

        Console.WriteLine("----"); 
        
        Point p1; p1.x = 3; p1.y = 4;
        Point p2 = new Point { x = 3, y = 4 };
        
        Console.WriteLine("p1 == p2 ? {0}", p1 == p2);
        Console.WriteLine("p1 equivalent to p2 ? {0}",
                          p1.Equals(p2));

        Console.WriteLine("p1 same as p2 ? {0}",
                          Object.ReferenceEquals(p1, p2));
        Console.WriteLine("p1 same as p1 ? {0}",
                          Object.ReferenceEquals(p1, p1));
                          
        Object op1 = p1;
        Object op2 = p2;
        
        Console.WriteLine("op1 same as op2 ? {0}",
                          Object.ReferenceEquals(op1, op2));
        
        Console.WriteLine("op1 == op2 ? {0}", op1 == op2);

        Console.WriteLine("op1 equivalent to op2 ? {0}",
                          op1.Equals(op2));
    }
    
}