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
        public void SubtractUnsignedChecked()
        {
            var method = new DynamicMethod("x", typeof(uint), new[] { typeof(uint), typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.SubtractUnsignedChecked();
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, uint, uint>)method.CreateDelegate(typeof(Func<uint, uint, uint>));
            Assert.Equal((uint)14, func(20, 6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void SubtractUnsignedCheckedChar()
        {
            var method = new DynamicMethod("x", typeof(char), new[] { typeof(char) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.SubtractUnsignedChecked((char)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<char, char>)method.CreateDelegate(typeof(Func<char, char>));
            Assert.Equal((char)14, func((char)20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void SubtractUnsignedCheckedByte()
        {
            var method = new DynamicMethod("x", typeof(byte), new[] { typeof(byte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.SubtractUnsignedChecked((byte)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<byte, byte>)method.CreateDelegate(typeof(Func<byte, byte>));
            Assert.Equal((byte)14, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void SubtractUnsignedCheckedUInt16()
        {
            var method = new DynamicMethod("x", typeof(ushort), new[] { typeof(ushort) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.SubtractUnsignedChecked((ushort)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<ushort, ushort>)method.CreateDelegate(typeof(Func<ushort, ushort>));
            Assert.Equal((ushort)14, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void SubtractUnsignedCheckedUInt32()
        {
            var method = new DynamicMethod("x", typeof(uint), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.SubtractUnsignedChecked((uint)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, uint>)method.CreateDelegate(typeof(Func<uint, uint>));
            Assert.Equal((uint)14, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void SubtractUnsignedCheckedUInt64()
        {
            var method = new DynamicMethod("x", typeof(ulong), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.SubtractUnsignedChecked((ulong)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, ulong>)method.CreateDelegate(typeof(Func<ulong, ulong>));
            Assert.Equal((ulong)14, func(20));
        }
    }
}
