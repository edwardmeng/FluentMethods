using System;
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
        public void NegateSByte()
        {
            var method = new DynamicMethod("x", typeof(sbyte), new[] { typeof(sbyte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Negate();
            il.Emit(OpCodes.Ret);

            var func = (Func<sbyte, sbyte>)method.CreateDelegate(typeof(Func<sbyte, sbyte>));
            Assert.Equal(-20, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void NegateInt16()
        {
            var method = new DynamicMethod("x", typeof(short), new[] { typeof(short) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Negate();
            il.Emit(OpCodes.Ret);

            var func = (Func<short, short>)method.CreateDelegate(typeof(Func<short, short>));
            Assert.Equal(-20, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void NegateInt32()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Negate();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, int>)method.CreateDelegate(typeof(Func<int, int>));
            Assert.Equal(-20, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void NegateInt64()
        {
            var method = new DynamicMethod("x", typeof(long), new[] { typeof(long) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Negate();
            il.Emit(OpCodes.Ret);

            var func = (Func<long, long>)method.CreateDelegate(typeof(Func<long, long>));
            Assert.Equal((long)-20, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void NegateFloat()
        {
            var method = new DynamicMethod("x", typeof(float), new[] { typeof(float) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Negate();
            il.Emit(OpCodes.Ret);

            var func = (Func<float, float>)method.CreateDelegate(typeof(Func<float, float>));
            Assert.Equal((float)-20.5, func((float)20.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void NegateDouble()
        {
            var method = new DynamicMethod("x", typeof(double), new[] { typeof(double) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Negate();
            il.Emit(OpCodes.Ret);

            var func = (Func<double, double>)method.CreateDelegate(typeof(Func<double, double>));
            Assert.Equal(-20.5, func(20.5));
        }
    }
}
