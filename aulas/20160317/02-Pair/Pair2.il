.assembly extern mscorlib
{
    .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
    .ver 4:0:0:0
}

.assembly Pair2
{

}

.class value Pair
{
    .field public int32 i1
    .field public int32 i2
}

.class public UsePair
{
    .method public static void Begin()
    {
        .entrypoint
        
        .locals init (
            [0] valuetype Pair p
        )
        
        ldloca.s 0
        ldc.i4.3
        stfld int32 Pair::i1
        
        ldloca.s 0
        ldc.i4.4
        stfld int32 Pair::i2
        
        ldloc.0
        call int32 UsePair::Add(valuetype Pair)
        
        call void [mscorlib]System.Console::WriteLine(int32)
        
        ret
    }
    
    .method private static int32 Add(valuetype Pair pair)
    {
        ldarg.0
        ldfld int32 Pair::i1
        ldarg.0
        ldfld int32 Pair::i2
        add
        ret
    }
}
