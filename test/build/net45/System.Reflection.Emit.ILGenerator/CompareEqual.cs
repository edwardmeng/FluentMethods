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
        public void CompareEqual()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(int), typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.CompareEqual();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, int, bool>)method.CreateDelegate(typeof(Func<int, int, bool>));
            Assert.Equal(true, func(20, 20));
            Assert.Equal(false, func(20, 6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareEqualToChar()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(char) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareEqualTo((char)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<char, bool>)method.CreateDelegate(typeof(Func<char, bool>));
            Assert.Equal(true, func((char)20));
            Assert.Equal(false, func((char)6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareEqualToByte()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(byte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareEqualTo((byte)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<byte, bool>)method.CreateDelegate(typeof(Func<byte, bool>));
            Assert.Equal(true, func(20));
            Assert.Equal(false, func(6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareEqualToSByte()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(sbyte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareEqualTo((sbyte)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<sbyte, bool>)method.CreateDelegate(typeof(Func<sbyte, bool>));
            Assert.Equal(true, func(20));
            Assert.Equal(false, func(6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareEqualToInt16()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(short) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareEqualTo((short)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<short, bool>)method.CreateDelegate(typeof(Func<short, bool>));
            Assert.Equal(true, func(20));
            Assert.Equal(false, func(6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareEqualToUInt16()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ushort) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareEqualTo((ushort)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<ushort, bool>)method.CreateDelegate(typeof(Func<ushort, bool>));
            Assert.Equal(true, func(20));
            Assert.Equal(false, func(6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareEqualToInt32()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareEqualTo(20);
            il.Emit(OpCodes.Ret);

            var func = (Func<int, bool>)method.CreateDelegate(typeof(Func<int, bool>));
            Assert.Equal(true, func(20));
            Assert.Equal(false, func(6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareEqualToUInt32()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareEqualTo((uint)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, bool>)method.CreateDelegate(typeof(Func<uint, bool>));
            Assert.Equal(true, func(20));
            Assert.Equal(false, func(6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareEqualToInt64()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(long) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareEqualTo((long)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<long, bool>)method.CreateDelegate(typeof(Func<long, bool>));
            Assert.Equal(true, func(20));
            Assert.Equal(false, func(6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareEqualToUInt64()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareEqualTo((ulong)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, bool>)method.CreateDelegate(typeof(Func<ulong, bool>));
            Assert.Equal(true, func(20));
            Assert.Equal(false, func(6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareEqualToFloat()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(float) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareEqualTo((float)20.5);
            il.Emit(OpCodes.Ret);

            var func = (Func<float, bool>)method.CreateDelegate(typeof(Func<float, bool>));
            Assert.Equal(true, func((float)20.5));
            Assert.Equal(false, func((float)6.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareEqualToDouble()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(double) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareEqualTo(20.5);
            il.Emit(OpCodes.Ret);

            var func = (Func<double, bool>)method.CreateDelegate(typeof(Func<double, bool>));
            Assert.Equal(true, func(20.5));
            Assert.Equal(false, func(6.5));
        }
    }
}
