using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Gen
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyBuilder asmBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("GenAsm"), AssemblyBuilderAccess.Save);
            ModuleBuilder modBuilder = asmBuilder.DefineDynamicModule("GenAsm", "GenAsm.exe");
            TypeBuilder typBuilder = modBuilder.DefineType("GenType");

            MethodBuilder metBuilder = typBuilder.DefineMethod("ILoveAVE", MethodAttributes.Static);

            asmBuilder.SetEntryPoint(metBuilder);

            ILGenerator il = metBuilder.GetILGenerator();
            il.Emit(OpCodes.Ldstr, "Hello, AVE!");
            il.Emit(OpCodes.Call, typeof(System.Console).GetMethod("WriteLine", new Type[] { typeof(string) }));
            il.Emit(OpCodes.Ret);

            typBuilder.CreateType();
            asmBuilder.Save("GenAsm.exe");
        }
    }
}
