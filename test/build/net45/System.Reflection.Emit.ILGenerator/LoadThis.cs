using System;
using System.Reflection;
using System.Reflection.Emit;

namespace FluentMethods.UnitTests
{
    public partial class ILGeneratorFixture
    {
        private static readonly ModuleBuilder _moduleBuilder;

        static ILGeneratorFixture()
        {
#if NetCore
            _moduleBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("ILEmit"), AssemblyBuilderAccess.RunAndCollect).DefineDynamicModule("ILEmit");
#else
            _moduleBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("ILEmit"), AssemblyBuilderAccess.Run).DefineDynamicModule("ILEmit");
#endif
        }
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadThis()
        {
            var typeBuilder = _moduleBuilder.DefineType("LoadThis",
                TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit);
            var field = typeBuilder.DefineField("Value", typeof(int), FieldAttributes.Public);
            var method = typeBuilder.DefineMethod("GetValue",
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final, typeof(int), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadThis();
            il.Emit(OpCodes.Ldfld, field);
            il.Emit(OpCodes.Ret);

            var type = typeBuilder.CreateType();
            var instance = type.GetConstructor(new Type[0]).Invoke(new object[0]);
            type.GetField("Value").SetValue(instance, 25);
            Assert.Equal(25, type.GetMethod("GetValue").Invoke(instance, new object[0]));
        }
    }
}
