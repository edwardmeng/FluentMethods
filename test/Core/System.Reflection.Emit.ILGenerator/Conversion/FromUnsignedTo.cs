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
        public void FromUnsignedToChar()
        {
            var method = new DynamicMethod("x", typeof(char), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.FromUnsignedTo<char>();
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, char>)method.CreateDelegate(typeof(Func<uint, char>));
            Assert.Equal((char)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FromUnsignedToByte()
        {
            var method = new DynamicMethod("x", typeof(byte), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.FromUnsignedTo<byte>();
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, byte>)method.CreateDelegate(typeof(Func<uint, byte>));
            Assert.Equal((byte)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FromUnsignedToSByte()
        {
            var method = new DynamicMethod("x", typeof(sbyte), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.FromUnsignedTo<sbyte>();
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, sbyte>)method.CreateDelegate(typeof(Func<uint, sbyte>));
            Assert.Equal((sbyte)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FromUnsignedToInt16()
        {
            var method = new DynamicMethod("x", typeof(short), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.FromUnsignedTo<short>();
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, short>)method.CreateDelegate(typeof(Func<uint, short>));
            Assert.Equal((short)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FromUnsignedToUInt16()
        {
            var method = new DynamicMethod("x", typeof(ushort), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.FromUnsignedTo<ushort>();
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, ushort>)method.CreateDelegate(typeof(Func<uint, ushort>));
            Assert.Equal((ushort)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FromUnsignedToInt32()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.FromUnsignedTo<int>();
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, int>)method.CreateDelegate(typeof(Func<ulong, int>));
            Assert.Equal(32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FromUnsignedToUInt32()
        {
            var method = new DynamicMethod("x", typeof(uint), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.FromUnsignedTo<uint>();
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, uint>)method.CreateDelegate(typeof(Func<ulong, uint>));
            Assert.Equal((uint)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FromUnsignedToInt64()
        {
            var method = new DynamicMethod("x", typeof(long), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.FromUnsignedTo<long>();
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, long>)method.CreateDelegate(typeof(Func<ulong, long>));
            Assert.Equal((long)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FromUnsignedToUInt64()
        {
            var method = new DynamicMethod("x", typeof(ulong), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.FromUnsignedTo<ulong>();
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, ulong>)method.CreateDelegate(typeof(Func<uint, ulong>));
            Assert.Equal((ulong)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FromUnsignedToFloat()
        {
            var method = new DynamicMethod("x", typeof(float), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.FromUnsignedTo<float>();
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, float>)method.CreateDelegate(typeof(Func<ulong, float>));
            Assert.Equal((float)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FromUnsignedToDouble()
        {
            var method = new DynamicMethod("x", typeof(double), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.FromUnsignedTo<double>();
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, double>)method.CreateDelegate(typeof(Func<ulong, double>));
            Assert.Equal((double)32, func(32));
        }
    }
}
