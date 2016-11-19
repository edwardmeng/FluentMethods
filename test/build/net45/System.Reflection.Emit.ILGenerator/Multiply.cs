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
        public void Multiply()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(int), typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Multiply();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, int, int>)method.CreateDelegate(typeof(Func<int, int, int>));
            Assert.Equal(120, func(20, 6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyChar()
        {
            var method = new DynamicMethod("x", typeof(char), new[] { typeof(char) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Multiply((char)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<char, char>)method.CreateDelegate(typeof(Func<char, char>));
            Assert.Equal((char)120, func((char)20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyByte()
        {
            var method = new DynamicMethod("x", typeof(byte), new[] { typeof(byte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Multiply((byte)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<byte, byte>)method.CreateDelegate(typeof(Func<byte, byte>));
            Assert.Equal((byte)120, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplySByte()
        {
            var method = new DynamicMethod("x", typeof(sbyte), new[] { typeof(sbyte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Multiply((sbyte)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<sbyte, sbyte>)method.CreateDelegate(typeof(Func<sbyte, sbyte>));
            Assert.Equal((sbyte)120, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyInt16()
        {
            var method = new DynamicMethod("x", typeof(short), new[] { typeof(short) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Multiply((short)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<short, short>)method.CreateDelegate(typeof(Func<short, short>));
            Assert.Equal((short)120, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyUInt16()
        {
            var method = new DynamicMethod("x", typeof(ushort), new[] { typeof(ushort) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Multiply((ushort)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<ushort, ushort>)method.CreateDelegate(typeof(Func<ushort, ushort>));
            Assert.Equal((ushort)120, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyInt32()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Multiply(6);
            il.Emit(OpCodes.Ret);

            var func = (Func<int, int>)method.CreateDelegate(typeof(Func<int, int>));
            Assert.Equal(120, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyUInt32()
        {
            var method = new DynamicMethod("x", typeof(uint), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Multiply((uint)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, uint>)method.CreateDelegate(typeof(Func<uint, uint>));
            Assert.Equal((uint)120, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyInt64()
        {
            var method = new DynamicMethod("x", typeof(long), new[] { typeof(long) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Multiply((long)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<long, long>)method.CreateDelegate(typeof(Func<long, long>));
            Assert.Equal((long)120, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyUInt64()
        {
            var method = new DynamicMethod("x", typeof(ulong), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Multiply((ulong)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, ulong>)method.CreateDelegate(typeof(Func<ulong, ulong>));
            Assert.Equal((ulong)120, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyFloat()
        {
            var method = new DynamicMethod("x", typeof(float), new[] { typeof(float) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Multiply((float)6.5);
            il.Emit(OpCodes.Ret);

            var func = (Func<float, float>)method.CreateDelegate(typeof(Func<float, float>));
            Assert.Equal((float)133.25, func((float)20.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyDouble()
        {
            var method = new DynamicMethod("x", typeof(double), new[] { typeof(double) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Multiply((double)6.5);
            il.Emit(OpCodes.Ret);

            var func = (Func<double, double>)method.CreateDelegate(typeof(Func<double, double>));
            Assert.Equal((double)133.25, func((double)20.5));
        }
    }
}
