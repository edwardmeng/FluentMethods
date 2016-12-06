using System;
using System.Collections.Generic;
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
        public void TryFinally()
        {
            var method = new DynamicMethod("x", null, new[] { typeof(List<int>) });
            var il = method.GetILGenerator();
            var local = il.DeclareLocal<Exception>();
            using (il.Try())
            {
                il.Throw<OverflowException>();
                il.LoadNull().StoreLocal(local);
                using (il.Finally())
                {
                    il.LoadArg(0);
                    il.LoadConst(20);
                    il.Call((List<int> list, int value) => list.Add(value));
                }
            }
            il.Emit(OpCodes.Ret);

            var func = (Action<List<int>>)method.CreateDelegate(typeof(Action<List<int>>));
            var l = new List<int>();
            Assert.Throws<OverflowException>(() => func(l));
            Assert.Equal(1, l.Count);
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void TryCatchFinally()
        {
            var method = new DynamicMethod("x", typeof(Exception), new[] { typeof(List<int>) });
            var il = method.GetILGenerator();
            var local = il.DeclareLocal<Exception>();
            using (il.Try())
            {
                il.Throw<OverflowException>();
                il.LoadNull().StoreLocal(local);
                using (il.Catch<OverflowException>())
                {
                    il.ConvertTo<Exception>().StoreLocal(local);
                }
                using (il.Finally())
                {
                    il.LoadArg(0);
                    il.LoadConst(20);
                    il.Call((List<int> list, int value) => list.Add(value));
                }
            }
            il.LoadLocal(local);
            il.Emit(OpCodes.Ret);

            var func = (Func<List<int>, Exception>)method.CreateDelegate(typeof(Func<List<int>, Exception>));
            var l = new List<int>();
            Assert.IsInstanceOf<OverflowException>(func(l));
            Assert.Equal(1, l.Count);
        }
    }
}
