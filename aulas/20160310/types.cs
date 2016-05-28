using System;
using System.Reflection;

class Types
{
    class A
    {
        public int x = 0;
        
        public void oper() {}
        
        public virtual void meth() {}
    }

    class B : A
    {
        public int y = 0;

        public new void oper() {}

        public override void meth() {}
    }
    
    static void Main()
    {
        ShowTypes(new object());
        ShowTypes(3);
        ShowTypes("alpha");
        ShowTypes(new A());
        ShowTypes(new B());

        ShowMembers(new object());
        ShowMembers(3);
        ShowMembers("alpha");
        ShowMembers(new A());
        ShowMembers(new B());
    }
    
    static void ShowTypes(object obj) 
    {
        Type t = obj.GetType();
        Console.WriteLine("{1}: {0}", t.FullName, t.IsValueType ? 'V' : 'R');
        for (Type cls = t.BaseType; cls != null; cls = cls.BaseType) {
            Console.WriteLine("   {1}: {0}", cls.FullName, cls.IsValueType ? 'V' : 'R');
        }
        Type[] itfs = t.GetInterfaces();
        for (int i = 0; i < itfs.Length; ++i) {
            Console.WriteLine("   I: {0}", itfs[i].FullName);
        }
    }
    
    static void ShowMembers(object obj)
    {
        Type t = obj.GetType();
        Console.WriteLine("T: {0}", t.FullName);
        
        BindingFlags flags =
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static;

        MemberInfo[] members = t.GetMembers(flags);
        
        foreach (MemberInfo m in members) {
            Console.WriteLine("   {0} {1}\t\t{2}",
                              m.MemberType,
                              m.Name,
                              m.DeclaringType);
        }
    }
}