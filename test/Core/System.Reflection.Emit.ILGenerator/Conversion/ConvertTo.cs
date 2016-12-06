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
        public void ConvertToChar()
        {
            var method = new DynamicMethod("x", typeof(char), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertTo<char>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, char>)method.CreateDelegate(typeof(Func<int, char>));
            Assert.Equal((char)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToByte()
        {
            var method = new DynamicMethod("x", typeof(byte), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertTo<byte>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, byte>)method.CreateDelegate(typeof(Func<int, byte>));
            Assert.Equal((byte)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToSByte()
        {
            var method = new DynamicMethod("x", typeof(sbyte), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertTo<sbyte>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, sbyte>)method.CreateDelegate(typeof(Func<int, sbyte>));
            Assert.Equal((sbyte)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToInt16()
        {
            var method = new DynamicMethod("x", typeof(short), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertTo<short>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, short>)method.CreateDelegate(typeof(Func<int, short>));
            Assert.Equal((short)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToUInt16()
        {
            var method = new DynamicMethod("x", typeof(ushort), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertTo<ushort>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, ushort>)method.CreateDelegate(typeof(Func<int, ushort>));
            Assert.Equal((ushort)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToInt32()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(long) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertTo<int>();
            il.Emit(OpCodes.Ret);

            var func = (Func<long, int>)method.CreateDelegate(typeof(Func<long, int>));
            Assert.Equal(32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToUInt32()
        {
            var method = new DynamicMethod("x", typeof(uint), new[] { typeof(long) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertTo<uint>();
            il.Emit(OpCodes.Ret);

            var func = (Func<long, uint>)method.CreateDelegate(typeof(Func<long, uint>));
            Assert.Equal((uint)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToInt64()
        {
            var method = new DynamicMethod("x", typeof(long), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertTo<long>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, long>)method.CreateDelegate(typeof(Func<int, long>));
            Assert.Equal((long)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToUInt64()
        {
            var method = new DynamicMethod("x", typeof(ulong), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertTo<ulong>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, ulong>)method.CreateDelegate(typeof(Func<int, ulong>));
            Assert.Equal((ulong)32, func(32));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToFloat()
        {
            var method = new DynamicMethod("x", typeof(float), new[] { typeof(double) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertTo<float>();
            il.Emit(OpCodes.Ret);

            var func = (Func<double, float>)method.CreateDelegate(typeof(Func<double, float>));
            Assert.Equal((float)32.5, func(32.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToDouble()
        {
            var method = new DynamicMethod("x", typeof(double), new[] { typeof(float) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertTo<double>();
            il.Emit(OpCodes.Ret);

            var func = (Func<float, double>)method.CreateDelegate(typeof(Func<float, double>));
            Assert.Equal(32.5, func((float)32.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertToClass()
        {
            var method = new DynamicMethod("x", typeof(string), new[] { typeof(object) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ConvertTo<string>();
            il.Emit(OpCodes.Ret);

            var func = (Func<object, string>)method.CreateDelegate(typeof(Func<object, string>));
            Assert.Equal("Fizz", func("Fizz"));
        }
    }
}
