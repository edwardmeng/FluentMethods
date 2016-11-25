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
                new[] { typeof(List<int>) });
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

            var type = typeBuilder.CreateType();
            var func = (Action<List<int>>)Delegate.CreateDelegate(typeof(Action<List<int>>), type.GetMethod("x"));
            var l = new List<int>();
            Assert.Throws<ArgumentNullException>(() => func(l));
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

            var type = typeBuilder.CreateType();
            var func = (Action<List<int>>)Delegate.CreateDelegate(typeof(Action<List<int>>), type.GetMethod("x"));
            var l = new List<int>();
            func(l);
            Assert.Equal(0, l.Count);
        }
    }
}
