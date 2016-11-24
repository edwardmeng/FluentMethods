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
        public void And()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(int), typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.And();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, int, int>)method.CreateDelegate(typeof(Func<int, int, int>));
            Assert.Equal(20 & 6, func(20, 6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void AndBoolean()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(bool) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.And(false);
            il.Emit(OpCodes.Ret);

            var func = (Func<bool, bool>)method.CreateDelegate(typeof(Func<bool, bool>));
            Assert.Equal(false, func(true));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void AndByte()
        {
            var method = new DynamicMethod("x", typeof(byte), new[] { typeof(byte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.And((byte)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<byte, byte>)method.CreateDelegate(typeof(Func<byte, byte>));
            Assert.Equal((byte)20 & (byte)6, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void AndSByte()
        {
            var method = new DynamicMethod("x", typeof(sbyte), new[] { typeof(sbyte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.And((sbyte)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<sbyte, sbyte>)method.CreateDelegate(typeof(Func<sbyte, sbyte>));
            Assert.Equal((sbyte)20 & (sbyte)6, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void AndInt16()
        {
            var method = new DynamicMethod("x", typeof(short), new[] { typeof(short) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.And((short)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<short, short>)method.CreateDelegate(typeof(Func<short, short>));
            Assert.Equal((short)20 & (short)6, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void AndUInt16()
        {
            var method = new DynamicMethod("x", typeof(ushort), new[] { typeof(ushort) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.And((ushort)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<ushort, ushort>)method.CreateDelegate(typeof(Func<ushort, ushort>));
            Assert.Equal((ushort)20 & (ushort)6, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void AndInt32()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.And(6);
            il.Emit(OpCodes.Ret);

            var func = (Func<int, int>)method.CreateDelegate(typeof(Func<int, int>));
            Assert.Equal(20 & 6, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void AndUInt32()
        {
            var method = new DynamicMethod("x", typeof(uint), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.And((uint)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, uint>)method.CreateDelegate(typeof(Func<uint, uint>));
            Assert.Equal(20 & (uint)6, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void AndInt64()
        {
            var method = new DynamicMethod("x", typeof(long), new[] { typeof(long) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.And((long)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<long, long>)method.CreateDelegate(typeof(Func<long, long>));
            Assert.Equal(20 & (long)6, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void AndUInt64()
        {
            var method = new DynamicMethod("x", typeof(ulong), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.And((ulong)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, ulong>)method.CreateDelegate(typeof(Func<ulong, ulong>));
            Assert.Equal((ulong)20 & 6, func(20));
        }
    }
}
