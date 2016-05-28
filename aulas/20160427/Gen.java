import java.util.*;

public class Gen
{
    public static double average1(Iterable items)
    {
        double acc = 0.0;
        int num = 0;
        for (Object obj : items)
        {
            acc += ((Integer)obj).intValue();
            num += 1;
        }
        return num > 0 ? acc/num : acc;
    }
    
    public static double average2(Iterable<Integer> items)
    {
        double acc = 0.0;
        int num = 0;
        for (Integer obj : items)
        {
            acc += obj;
            num += 1;
        }
        return num > 0 ? acc/num : acc;
    }
    
    public static void main(String[] args)
    {
        System.out.printf("%f\n", average1(Arrays.asList(1, 2, 3, 4, 5, 6, 7, 8, 9 )));
        System.out.printf("%f\n", average2(Arrays.asList(1, 2, 3, 4, 5, 6, 7, 8, 9 )));
        System.out.printf("%f\n", average1(Arrays.asList(1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0 )));
    }
}
