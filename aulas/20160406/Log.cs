using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Field|AttributeTargets.Property)]
class DontLogAttribute : Attribute
{
    
}

[AttributeUsage(AttributeTargets.Field|AttributeTargets.Property)]
class LogLevelAttribute : Attribute
{
    public int Level { get; private set; }
    public LogLevelAttribute(int level) { Level = level; }
}

class Logger
{
    const BindingFlags PUBLIC_INSTANCE = BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy;

    public static void Log(object obj, int reqLevel)
    {
        if (obj != null)
        {
            Type t = obj.GetType();
            Console.Write("{0} {{ ", t.Name);
            foreach (FieldInfo f in t.GetFields(PUBLIC_INSTANCE))
            {
                if (IsLogAllowed(f)) {
                    int defLevel = GetLogLevel(f);
                    if (defLevel <= reqLevel) {
                        Console.Write("{0}: {1}; ", f.Name, f.GetValue(obj));
                    }
                }
            }
            Console.WriteLine('}');
        }
    }
    
    private static bool IsLogAllowed(MemberInfo m)
    {
        return !m.IsDefined(typeof(DontLogAttribute));
    }
    
    private static int GetLogLevel(MemberInfo m)
    {
        Attribute[] attrs = (Attribute[])m.GetCustomAttributes(typeof(LogLevelAttribute), true);
        return attrs.Length > 0 ? ((LogLevelAttribute)attrs[0]).Level : -1;
    }
}

[Serializable]
class Info {

    [DontLog]
    public int a;

    [NonSerialized]
    public int b;

    [LogLevel(2)]
    public int c;

    [LogLevel(4)]
    public int d;
    
    public Info(int aa, int bb, int cc, int dd) 
    {
        a = aa; b = bb; c = cc; d = dd;
    }
}

class User {

    public int userId;
    
    public string username;

    [DontLog]
    public string password;

    [LogLevel(3)]
    public string fullName;

    [LogLevel(5)]
    public double factor;
    
    public User(int userId, string username, string password, string fullName, double factor) 
    {
        this.userId   = userId;
        this.username = username;
        this.password = password;
        this.fullName = fullName;
        this.factor   = factor;
    }
}

class Test
{
    public static void Main()
    {
        Info info = new Info(1, 2, 3, 4);
        User user = new User(1, "afonso1", "elReX", "Afonso Henriques", 1.95);
        
        Logger.Log(info, 2);
        Logger.Log(user, 4);
        Logger.Log(user, 2);
    }
}
