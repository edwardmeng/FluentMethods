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
        public void CompareLessUnsigned()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(uint), typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.CompareLessUnsigned();
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, uint, bool>)method.CreateDelegate(typeof(Func<uint, uint, bool>));
            Assert.Equal(false, func(20, 20));
            Assert.Equal(true, func(6, 20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareLessThanUnsignedChar()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThanUnsigned((char)20);
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
        public void CompareLessThanUnsignedByte()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(byte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThanUnsigned((byte)20);
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
        public void CompareLessThanUnsignedUInt16()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ushort) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThanUnsigned((ushort)20);
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
        public void CompareLessThanUnsignedUInt32()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThanUnsigned((uint)20);
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
        public void CompareLessThanUnsignedUInt64()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareLessThanUnsigned((ulong)20);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, bool>)method.CreateDelegate(typeof(Func<ulong, bool>));
            Assert.Equal(true, func(6));
            Assert.Equal(false, func(20));
        }
    }
}
