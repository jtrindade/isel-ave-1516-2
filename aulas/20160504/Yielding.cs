using System;
using System.Collections;
using System.Collections.Generic;

public class Yielding
{
    static IEnumerator<int> OneToFive()
    {
        yield return 1;
        yield return 2;
        yield return 3;
        yield return 4;
        yield return 5;
    }

    static void UseOneToFive()
	{
		IEnumerator<int> nums = OneToFive();
		while (nums.MoveNext())
		{
			Console.WriteLine(nums.Current);
		}
        nums.Dispose();
	}

    static IEnumerable<Y> Map<X,Y>(IEnumerable<X> src, Func<X,Y> map)
    {
        foreach (X item in src)
        {
            yield return map(item);
        }
    }
    
    static void UseMap()
    {
        int[] nums = { 1, 2, 3, 4, 5 };
        foreach (int n in Map(nums, x => x*x))
        {
            Console.WriteLine(n);
        }
    }
    
	public static void Main()
	{
		UseOneToFive();
        UseMap();
	}
}