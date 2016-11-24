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
        public void Divide()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(int), typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Divide();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, int, int>)method.CreateDelegate(typeof(Func<int, int, int>));
            Assert.Equal(3, func(20, 6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DivideChar()
        {
            var method = new DynamicMethod("x", typeof(char), new[] { typeof(char) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Divide((char)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<char, char>)method.CreateDelegate(typeof(Func<char, char>));
            Assert.Equal((char)3, func((char)20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DivideByte()
        {
            var method = new DynamicMethod("x", typeof(byte), new[] { typeof(byte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Divide((byte)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<byte, byte>)method.CreateDelegate(typeof(Func<byte, byte>));
            Assert.Equal((byte)3, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DivideSByte()
        {
            var method = new DynamicMethod("x", typeof(sbyte), new[] { typeof(sbyte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Divide((sbyte)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<sbyte, sbyte>)method.CreateDelegate(typeof(Func<sbyte, sbyte>));
            Assert.Equal((sbyte)3, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DivideInt16()
        {
            var method = new DynamicMethod("x", typeof(short), new[] { typeof(short) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Divide((short)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<short, short>)method.CreateDelegate(typeof(Func<short, short>));
            Assert.Equal((short)3, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DivideUInt16()
        {
            var method = new DynamicMethod("x", typeof(ushort), new[] { typeof(ushort) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Divide((ushort)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<ushort, ushort>)method.CreateDelegate(typeof(Func<ushort, ushort>));
            Assert.Equal((ushort)3, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DivideInt32()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Divide(6);
            il.Emit(OpCodes.Ret);

            var func = (Func<int, int>)method.CreateDelegate(typeof(Func<int, int>));
            Assert.Equal(3, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DivideUInt32()
        {
            var method = new DynamicMethod("x", typeof(uint), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Divide((uint)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, uint>)method.CreateDelegate(typeof(Func<uint, uint>));
            Assert.Equal((uint)3, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DivideInt64()
        {
            var method = new DynamicMethod("x", typeof(long), new[] { typeof(long) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Divide((long)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<long, long>)method.CreateDelegate(typeof(Func<long, long>));
            Assert.Equal((long)3, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DivideUInt64()
        {
            var method = new DynamicMethod("x", typeof(ulong), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Divide((ulong)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, ulong>)method.CreateDelegate(typeof(Func<ulong, ulong>));
            Assert.Equal((ulong)3, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DivideFloat()
        {
            var method = new DynamicMethod("x", typeof(float), new[] { typeof(float) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Divide((float)6.5);
            il.Emit(OpCodes.Ret);

            var func = (Func<float, float>)method.CreateDelegate(typeof(Func<float, float>));
            Assert.Equal((float)3.5, func((float)22.75));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DivideDouble()
        {
            var method = new DynamicMethod("x", typeof(double), new[] { typeof(double) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Divide((double)6.5);
            il.Emit(OpCodes.Ret);

            var func = (Func<double, double>)method.CreateDelegate(typeof(Func<double, double>));
            Assert.Equal((double)3.5, func((double)22.75));
        }
    }
}
