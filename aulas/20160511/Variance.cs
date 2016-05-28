using System;
using System.Collections.Generic;

class A {}

class B : A {}

class C : B {}

class ArraysVariance
{
    public static void ShowBs(B[] bbs)
    {
        foreach (B obj in bbs) 
        {
            Console.Write("{0} ", obj.GetType().Name);
        }
        Console.WriteLine();
    }
    
    public static void ReplaceB(B[] bbs, B aNewB)
    {
        Console.WriteLine("Replacing {0} with {1} ",
            bbs[0].GetType().Name,
            aNewB.GetType().Name);
        
        bbs[0] = aNewB;
    }
}

class GenericsInvariance
{
    public static void ShowListOfBs(List<B> bbs)
    {
        foreach (B obj in bbs) 
        {
            Console.Write("{0} ", obj.GetType().Name);
        }
        Console.WriteLine();
    }
}

class OverridesInvariance
{
    class Base
    {
        public virtual B oper() { return new B(); }
    }
    
    class Derived : Base
    {
        // Embora seja seguro permitir que o retorno de 'oper' seja redefinido para 'C',
        // a plataforma (e a linguagem C#) não o permite.
        public override B oper() { return new C(); }
    }
}

class DelegatesVariance
{
    public delegate B CreateB();
    
    public static void CreateAndShow(CreateB creator)
    {
        B aNewB = creator();
        Console.Write("{0}", aNewB.GetType().Name);
    }

    public static A makeA() { return new A(); }    
    public static B makeB() { return new B(); }    
    public static C makeC() { return new C(); }    

    public delegate void UseB(B obj);
    
    public static void PrintA(A obj) { Console.WriteLine("A: {0} ", obj.GetType().Name); }    
    public static void PrintB(B obj) { Console.WriteLine("B: {0} ", obj.GetType().Name); }    
    public static void PrintC(C obj) { Console.WriteLine("C: {0} ", obj.GetType().Name); }    
    
    public static void CallUseB(UseB oper, B someB)
    {
        oper(someB);
    }
}

class Variance
{
    static void Main()
    {
        B[] data1 = new B[] { new B(), new B(), new B() };
        B[] data2 = new B[] { new C(), new B(), new C() };
        C[] data3 = new C[] { new C(), new C(), new C() };
        
        List<B> list1 = new List<B>(data1);
        List<C> list3 = new List<C>(data3);
        
        ArraysVariance.ShowBs(data1);
        ArraysVariance.ShowBs(data2);
        ArraysVariance.ShowBs(data3);
        
        ArraysVariance.ReplaceB(data1, new B());
        ArraysVariance.ReplaceB(data1, new C());
        ArraysVariance.ReplaceB(data3, new C());
        try
        {
            ArraysVariance.ReplaceB(data3, new B());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }    
    
        GenericsInvariance.ShowListOfBs(list1);
        //GenericsInvariance.ShowListOfBs(list3);
        
        DelegatesVariance.CreateAndShow(DelegatesVariance.makeB);
        DelegatesVariance.CreateAndShow(DelegatesVariance.makeC);
        
        DelegatesVariance.CallUseB(DelegatesVariance.PrintA, new C());
        DelegatesVariance.CallUseB(DelegatesVariance.PrintB, new C());
        //DelegatesVariance.CallUseB(DelegatesVariance.PrintC, new B());
    }
}
