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
        public void ConvertToCheckedChar()
        {
            var method = new DynamicMethod("x", typeof(char), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertToChecked<char>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, char>)method.CreateDelegate(typeof(Func<int, char>));
            Assert.Equal((char)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToCheckedByte()
        {
            var method = new DynamicMethod("x", typeof(byte), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertToChecked<byte>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, byte>)method.CreateDelegate(typeof(Func<int, byte>));
            Assert.Equal((byte)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToCheckedSByte()
        {
            var method = new DynamicMethod("x", typeof(sbyte), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertToChecked<sbyte>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, sbyte>)method.CreateDelegate(typeof(Func<int, sbyte>));
            Assert.Equal((sbyte)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToCheckedInt16()
        {
            var method = new DynamicMethod("x", typeof(short), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertToChecked<short>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, short>)method.CreateDelegate(typeof(Func<int, short>));
            Assert.Equal((short)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToCheckedUInt16()
        {
            var method = new DynamicMethod("x", typeof(ushort), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertToChecked<ushort>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, ushort>)method.CreateDelegate(typeof(Func<int, ushort>));
            Assert.Equal((ushort)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToCheckedInt32()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(long) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertToChecked<int>();
            il.Emit(OpCodes.Ret);

            var func = (Func<long, int>)method.CreateDelegate(typeof(Func<long, int>));
            Assert.Equal(32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToCheckedUInt32()
        {
            var method = new DynamicMethod("x", typeof(uint), new[] { typeof(long) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertToChecked<uint>();
            il.Emit(OpCodes.Ret);

            var func = (Func<long, uint>)method.CreateDelegate(typeof(Func<long, uint>));
            Assert.Equal(32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToCheckedInt64()
        {
            var method = new DynamicMethod("x", typeof(long), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertToChecked<long>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, long>)method.CreateDelegate(typeof(Func<int, long>));
            Assert.Equal((long)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToCheckedUInt64()
        {
            var method = new DynamicMethod("x", typeof(ulong), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertToChecked<ulong>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, ulong>)method.CreateDelegate(typeof(Func<int, ulong>));
            Assert.Equal((ulong)32, func(32));
        }
    }
}
