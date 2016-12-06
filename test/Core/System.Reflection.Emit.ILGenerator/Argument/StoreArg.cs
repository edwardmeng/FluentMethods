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
        public void StoreArg()
        {
            var method = new DynamicMethod("x", typeof(string), new[] { typeof(string) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldstr, "Fizz");
            il.StoreArg(0);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<string, string>)method.CreateDelegate(typeof(Func<string, string>));
            Assert.Equal("Fizz", func("Buzz"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgMuchArguments()
        {
            var method = new DynamicMethod("x", typeof(string), new[]
            {
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(string)
            });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldstr, "Fizz");
            il.StoreArg(256);
            il.Emit(OpCodes.Ldarg,256);
            il.Emit(OpCodes.Ret);

            var func = (MuchArgumentsHandler<string, string>)method.CreateDelegate(typeof(MuchArgumentsHandler<string, string>));
            Assert.Equal("Fizz", func(
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                "Buzz"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgChar()
        {
            var method = new DynamicMethod("x", typeof(char), new[] { typeof(char) });
            var il = method.GetILGenerator();
            il.StoreArg(0, (char)20);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<char, char>)method.CreateDelegate(typeof(Func<char, char>));
            Assert.Equal((char)20, func((char)30));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgByte()
        {
            var method = new DynamicMethod("x", typeof(byte), new[] { typeof(byte) });
            var il = method.GetILGenerator();
            il.StoreArg(0, (byte)20);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<byte, byte>)method.CreateDelegate(typeof(Func<byte, byte>));
            Assert.Equal((byte)20, func(30));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgSByte()
        {
            var method = new DynamicMethod("x", typeof(sbyte), new[] { typeof(sbyte) });
            var il = method.GetILGenerator();
            il.StoreArg(0, (sbyte)20);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<sbyte, sbyte>)method.CreateDelegate(typeof(Func<sbyte, sbyte>));
            Assert.Equal((sbyte)20, func(30));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgInt16()
        {
            var method = new DynamicMethod("x", typeof(short), new[] { typeof(short) });
            var il = method.GetILGenerator();
            il.StoreArg(0, (short)20);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<short, short>)method.CreateDelegate(typeof(Func<short, short>));
            Assert.Equal((short)20, func(30));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgUInt16()
        {
            var method = new DynamicMethod("x", typeof(ushort), new[] { typeof(ushort) });
            var il = method.GetILGenerator();
            il.StoreArg(0, (ushort)20);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<ushort, ushort>)method.CreateDelegate(typeof(Func<ushort, ushort>));
            Assert.Equal((ushort)20, func(30));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgInt32()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.StoreArg(0,20);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<int, int>)method.CreateDelegate(typeof(Func<int, int>));
            Assert.Equal(20, func(30));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgUInt32()
        {
            var method = new DynamicMethod("x", typeof(uint), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            il.StoreArg(0, (uint)20);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, uint>)method.CreateDelegate(typeof(Func<uint, uint>));
            Assert.Equal((uint)20, func(30));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgInt64()
        {
            var method = new DynamicMethod("x", typeof(long), new[] { typeof(long) });
            var il = method.GetILGenerator();
            il.StoreArg(0, (long)20);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<long, long>)method.CreateDelegate(typeof(Func<long, long>));
            Assert.Equal((long)20, func(30));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgUInt64()
        {
            var method = new DynamicMethod("x", typeof(ulong), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            il.StoreArg(0, (ulong)20);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, ulong>)method.CreateDelegate(typeof(Func<ulong, ulong>));
            Assert.Equal((ulong)20, func(30));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgFloat()
        {
            var method = new DynamicMethod("x", typeof(float), new[] { typeof(float) });
            var il = method.GetILGenerator();
            il.StoreArg(0, (float)20.5);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<float, float>)method.CreateDelegate(typeof(Func<float, float>));
            Assert.Equal((float)20.5, func((float)30.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgDouble()
        {
            var method = new DynamicMethod("x", typeof(double), new[] { typeof(double) });
            var il = method.GetILGenerator();
            il.StoreArg(0, (double)20.5);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<double, double>)method.CreateDelegate(typeof(Func<double, double>));
            Assert.Equal((double)20.5, func((double)30.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgDecimal()
        {
            var method = new DynamicMethod("x", typeof(decimal), new[] { typeof(decimal) });
            var il = method.GetILGenerator();
            il.StoreArg(0, (decimal)20.5);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<decimal, decimal>)method.CreateDelegate(typeof(Func<decimal, decimal>));
            Assert.Equal((decimal)20.5, func((decimal)30.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgBoolean()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(bool) });
            var il = method.GetILGenerator();
            il.StoreArg(0, true);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<bool, bool>)method.CreateDelegate(typeof(Func<bool, bool>));
            Assert.Equal(true, func(false));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreArgString()
        {
            var method = new DynamicMethod("x", typeof(string), new[] { typeof(string) });
            var il = method.GetILGenerator();
            il.StoreArg(0, "Fizz");
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ret);

            var func = (Func<string, string>)method.CreateDelegate(typeof(Func<string, string>));
            Assert.Equal("Fizz", func("Buzz"));
        }
    }
}
