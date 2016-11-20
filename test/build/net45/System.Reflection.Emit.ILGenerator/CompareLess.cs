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
        public void CompareLess()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(int), typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.CompareLess();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, int, bool>)method.CreateDelegate(typeof(Func<int, int, bool>));
            Assert.Equal(false, func(20, 20));
            Assert.Equal(true, func(6, 20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareLessThanChar()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThan((char)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<int, bool>)method.CreateDelegate(typeof(Func<int, bool>));
            Assert.Equal(true, func(6));
            Assert.Equal(false, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareLessThanByte()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(byte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThan((byte)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<byte, bool>)method.CreateDelegate(typeof(Func<byte, bool>));
            Assert.Equal(true, func(6));
            Assert.Equal(false, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareLessThanSByte()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(sbyte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThan((sbyte)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<sbyte, bool>)method.CreateDelegate(typeof(Func<sbyte, bool>));
            Assert.Equal(true, func(6));
            Assert.Equal(false, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareLessThanInt16()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(short) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThan((short)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<short, bool>)method.CreateDelegate(typeof(Func<short, bool>));
            Assert.Equal(true, func(6));
            Assert.Equal(false, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareLessThanUInt16()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ushort) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThan((ushort)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<ushort, bool>)method.CreateDelegate(typeof(Func<ushort, bool>));
            Assert.Equal(true, func(6));
            Assert.Equal(false, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareLessThanInt32()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThan(20);
            il.Emit(OpCodes.Ret);

            var func = (Func<int, bool>)method.CreateDelegate(typeof(Func<int, bool>));
            Assert.Equal(true, func(6));
            Assert.Equal(false, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareLessThanUInt32()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThan((uint)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, bool>)method.CreateDelegate(typeof(Func<uint, bool>));
            Assert.Equal(true, func(6));
            Assert.Equal(false, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareLessThanInt64()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(long) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThan((long)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<long, bool>)method.CreateDelegate(typeof(Func<long, bool>));
            Assert.Equal(true, func(6));
            Assert.Equal(false, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareLessThanUInt64()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThan((ulong)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, bool>)method.CreateDelegate(typeof(Func<ulong, bool>));
            Assert.Equal(true, func(6));
            Assert.Equal(false, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareLessThanFloat()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(float) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThan((float)20.5);
            il.Emit(OpCodes.Ret);

            var func = (Func<float, bool>)method.CreateDelegate(typeof(Func<float, bool>));
            Assert.Equal(true, func((float)6.5));
            Assert.Equal(false, func((float)20.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareLessThanDouble()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(double) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThan(20.5);
            il.Emit(OpCodes.Ret);

            var func = (Func<double, bool>)method.CreateDelegate(typeof(Func<double, bool>));
            Assert.Equal(true, func(6.5));
            Assert.Equal(false, func(20.5));
        }
    }
}
