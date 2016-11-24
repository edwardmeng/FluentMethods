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
        public void CompareGreaterUnsigned()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(uint), typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.CompareGreaterUnsigned();
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, uint, bool>)method.CreateDelegate(typeof(Func<uint, uint, bool>));
            Assert.Equal(false, func(20, 20));
            Assert.Equal(true, func(20, 6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CompareGreaterThanUnsignedChar()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(char) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareGreaterThanUnsigned((char)6);
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
        public void CompareGreaterThanUnsignedByte()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(byte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareGreaterThanUnsigned((byte)6);
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
        public void CompareGreaterThanUnsignedUInt16()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ushort) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareGreaterThanUnsigned((ushort)6);
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
        public void CompareGreaterThanUnsignedUInt32()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareGreaterThanUnsigned((uint)6);
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
        public void CompareGreaterThanUnsignedUInt64()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.CompareGreaterThanUnsigned((ulong)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, bool>)method.CreateDelegate(typeof(Func<ulong, bool>));
            Assert.Equal(true, func(20));
            Assert.Equal(false, func(6));
        }
    }
}
