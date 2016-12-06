using System;
using System.Collections.Generic;
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
        public void TryFaultWithThrow()
        {
            var typeBuilder = _moduleBuilder.DefineType("TryFaultWithThrow",
                TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit);
            var method = typeBuilder.DefineMethod("x",
                MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig, null,
                new[] {typeof(List<int>)});
            var il = method.GetILGenerator();
            using (il.Try())
            {
                il.Throw<ArgumentNullException>("value");
                using (il.Fault())
                {
                    il.LoadArg(0);
                    il.LoadConst(20);
                    il.Call((List<int> list, int value) => list.Add(value));
                }
            }
            il.Emit(OpCodes.Ret);
            var l = new List<int>();
#if NetCore
            var type = typeBuilder.CreateTypeInfo();
#else
            var type = typeBuilder.CreateType();
#endif
            Assert.Throws<TargetInvocationException>(() => type.GetMethod("x").Invoke(null, new object[] { l }));
            Assert.Equal(1, l.Count);
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void TryFaultWithoutThrow()
        {
            var typeBuilder = _moduleBuilder.DefineType("TryFaultWithoutThrow",
               TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit);
            var method = typeBuilder.DefineMethod("x",
                MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig, null,
                new[] { typeof(List<int>) });
            var il = method.GetILGenerator();
            using (il.Try())
            {
                using (il.Fault())
                {
                    il.LoadArg(0);
                    il.LoadConst(20);
                    il.Call((List<int> list, int value) => list.Add(value));
                }
            }
            il.Emit(OpCodes.Ret);

#if NetCore
            var type = typeBuilder.CreateTypeInfo();
#else
            var type = typeBuilder.CreateType();
#endif
            var l = new List<int>();
            type.GetMethod("x").Invoke(null, new object[] { l });
            Assert.Equal(0, l.Count);
        }
    }
}
