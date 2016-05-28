using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Linq
{
    class Student
    {
        public int    Number  { get; set; }
        public string Name    { get; set; }
        public bool   HasQuit { get; set; }
        public int    Grade   { get; set; }
    }

    static List<Student> students = new List<Student>()
    {
        new Student { Number = 1111, Name = "Afonso",   HasQuit = false, Grade = 16 },
        new Student { Number = 2222, Name = "Sancho",   HasQuit = true },
        new Student { Number = 3333, Name = "Dinis",    HasQuit = false, Grade = 13 },
        new Student { Number = 4444, Name = "Pedro",    HasQuit = false, Grade = 17 },
        new Student { Number = 5555, Name = "Fernando", HasQuit = true },
    };
    
    static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
    {
        foreach (T item in items) action(item);
    }
    
    static void Show(IEnumerable<Student> data)
    {
        data.Where(s => !s.HasQuit).OrderBy(s => s.Grade).Select(s => s.Name).ForEach(Console.WriteLine);
    }

    public static void Main(string[] args)
    {
        Show(students);
    }
}
