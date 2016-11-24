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
        public void MultiplyUnsignedChecked()
        {
            var method = new DynamicMethod("x", typeof(uint), new[] { typeof(uint), typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.MultiplyUnsignedChecked();
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, uint, uint>)method.CreateDelegate(typeof(Func<uint, uint, uint>));
            Assert.Equal((uint)120, func(20, 6));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyUnsignedCheckedChar()
        {
            var method = new DynamicMethod("x", typeof(char), new[] { typeof(char) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.MultiplyUnsignedChecked((char)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<char, char>)method.CreateDelegate(typeof(Func<char, char>));
            Assert.Equal((char)120, func((char)20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyUnsignedCheckedByte()
        {
            var method = new DynamicMethod("x", typeof(byte), new[] { typeof(byte) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.MultiplyUnsignedChecked((byte)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<byte, byte>)method.CreateDelegate(typeof(Func<byte, byte>));
            Assert.Equal((byte)120, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyUnsignedCheckedUInt16()
        {
            var method = new DynamicMethod("x", typeof(ushort), new[] { typeof(ushort) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.MultiplyUnsignedChecked((ushort)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<ushort, ushort>)method.CreateDelegate(typeof(Func<ushort, ushort>));
            Assert.Equal((ushort)120, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyUnsignedCheckedUInt32()
        {
            var method = new DynamicMethod("x", typeof(uint), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.MultiplyUnsignedChecked((uint)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, uint>)method.CreateDelegate(typeof(Func<uint, uint>));
            Assert.Equal((uint)120, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MultiplyUnsignedCheckedUInt64()
        {
            var method = new DynamicMethod("x", typeof(ulong), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.MultiplyUnsignedChecked((ulong)6);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, ulong>)method.CreateDelegate(typeof(Func<ulong, ulong>));
            Assert.Equal((ulong)120, func(20));
        }
    }
}
