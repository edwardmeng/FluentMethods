using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace FluentMethods.UnitTests
{
    public partial class ILGeneratorFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadFieldAddress()
        {
            var typeBuilder = _moduleBuilder.DefineType("LoadFieldAddress",
                TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit);
            var field = typeBuilder.DefineField("Value", typeof(int), FieldAttributes.Public);
            var method = typeBuilder.DefineMethod("TryParse",
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final, typeof(bool),
                new[] { typeof(string) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Ldarg_0);
            il.LoadFieldAddress(field);
            il.Emit(OpCodes.Call, typeof(int).GetMethods(BindingFlags.Public | BindingFlags.Static).Single(x => x.Name == "TryParse" && x.GetParameters().Length == 2));
            il.Emit(OpCodes.Ret);

#if NetCore
            var type = typeBuilder.CreateTypeInfo();
#else
            var type = typeBuilder.CreateType();
#endif
            var instance = type.GetConstructor(new Type[0]).Invoke(new object[0]);
            Assert.True((bool)type.GetMethod("TryParse").Invoke(instance, new object[] { "25" }));
            Assert.Equal(25, type.GetField("Value").GetValue(instance));
        }
    }
}
