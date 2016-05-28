.assembly extern mscorlib
{
    .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
    .ver 4:0:0:0
}

.assembly Prog
{

}

.class public Prog
{
    .method public static string GetText()
    {
        ldstr       "Exception instead of String"
        newobj      instance void [mscorlib]System.Exception::.ctor(string)
        ret
    }
}
