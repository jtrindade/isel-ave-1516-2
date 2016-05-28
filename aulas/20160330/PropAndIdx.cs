using System;
using System.Reflection;

class Point
{
    private int x;
    
    public int X
    {
        get { return x; }
        set { x = value; }
    }
    
    public int Y
    {
        get;
        set;
    }
    
    public virtual double Radius
    {
        get
        {
            return Math.Sqrt(X*X+Y*Y);
        }
    }
    
    public override string ToString()
    {
        return String.Format("{{ X: {0}; Y: {1} }}", X, Y);
    }
    
    public int this[int idx]
    {
        get 
        {
            switch (idx)
            {
                case 0: return X;
                case 1: return Y;
            }
            throw new IndexOutOfRangeException();
        }
        
        set 
        {
            switch (idx)
            {
                case 0: X = value; break;
                case 1: Y = value; break;
            }
            throw new IndexOutOfRangeException();
        }
    }
    
    public int this[string idx]
    {
        get 
        {
            switch (idx)
            {
                case "x": return X;
                case "y": return Y;
            }
            throw new IndexOutOfRangeException();
        }
        
        set 
        {
            switch (idx)
            {
                case "x": X = value; break;
                case "y": Y = value; break;
            }
            throw new IndexOutOfRangeException();
        }
    }
}

class Point3D : Point
{
    private int z;
    
    public int Z 
    {
        get { return z; }
        set { z = value; }
    }

    public override double Radius
    {
        get
        {
            return Math.Sqrt(X*X+Y*Y+Z*Z);
        }
    }
    
    public override string ToString()
    {
        return String.Format("{{ X: {0}; Y: {1}; Z: {2}; }}", X, Y, Z);
    }
}

class Prog
{
    static void Main()
    {
        Point p = new Point();
        p.X = 3;
        p.Y = 4;
        
        Console.WriteLine(p);
        Console.WriteLine(p.Radius);
        Console.WriteLine("X: {0}, Y: {1}", p[0], p[1]);
        Console.WriteLine("X: {0}, Y: {1}", p["x"], p["y"]);
        
        Console.WriteLine();
        Inspector.Dump(p);
        Console.WriteLine();

        Point3D p3d = new Point3D();
        p3d.X = 3;
        p3d.Y = 4;
        p3d.Z = 5;
        
        Console.WriteLine(p3d);
        Console.WriteLine(p3d.Radius);

        Console.WriteLine();
        Inspector.Dump(p3d);
        Console.WriteLine();
    }
}

class Inspector
{
    public static void Dump(object obj)
    {
        Dump(obj, obj.GetType());
    }
    
    private static void Dump(object obj, Type t)
    {
        if (t != typeof(object))
        {
            Dump(obj, t.BaseType);
        }
        
        FieldInfo[] fields =
            t.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance /*| BindingFlags.FlattenHierarchy */
            );
        
        foreach (FieldInfo field in fields)
        {
            Console.WriteLine("{0}: {1}", field.Name, field.GetValue(obj));
        }
    }
}
