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
        public void DefaultBoolean()
        {
            var method = new DynamicMethod("x", typeof(bool), new Type[0]);
            var il = method.GetILGenerator();
            il.Default<bool>();
            il.Emit(OpCodes.Ret);

            var func = (Func<bool>)method.CreateDelegate(typeof(Func<bool>));
            Assert.Equal(false, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DefaultChar()
        {
            var method = new DynamicMethod("x", typeof(char), new Type[0]);
            var il = method.GetILGenerator();
            il.Default<char>();
            il.Emit(OpCodes.Ret);

            var func = (Func<char>)method.CreateDelegate(typeof(Func<char>));
            Assert.Equal((char)0, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DefaultByte()
        {
            var method = new DynamicMethod("x", typeof(byte), new Type[0]);
            var il = method.GetILGenerator();
            il.Default<byte>();
            il.Emit(OpCodes.Ret);

            var func = (Func<byte>)method.CreateDelegate(typeof(Func<byte>));
            Assert.Equal((byte)0, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DefaultSByte()
        {
            var method = new DynamicMethod("x", typeof(sbyte), new Type[0]);
            var il = method.GetILGenerator();
            il.Default<sbyte>();
            il.Emit(OpCodes.Ret);

            var func = (Func<sbyte>)method.CreateDelegate(typeof(Func<sbyte>));
            Assert.Equal((sbyte)0, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DefaultInt16()
        {
            var method = new DynamicMethod("x", typeof(short), new Type[0]);
            var il = method.GetILGenerator();
            il.Default<short>();
            il.Emit(OpCodes.Ret);

            var func = (Func<short>)method.CreateDelegate(typeof(Func<short>));
            Assert.Equal((short)0, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DefaultUInt16()
        {
            var method = new DynamicMethod("x", typeof(ushort), new Type[0]);
            var il = method.GetILGenerator();
            il.Default<ushort>();
            il.Emit(OpCodes.Ret);

            var func = (Func<ushort>)method.CreateDelegate(typeof(Func<ushort>));
            Assert.Equal((ushort)0, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DefaultInt32()
        {
            var method = new DynamicMethod("x", typeof(int), new Type[0]);
            var il = method.GetILGenerator();
            il.Default<int>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int>)method.CreateDelegate(typeof(Func<int>));
            Assert.Equal(0, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DefaultUInt32()
        {
            var method = new DynamicMethod("x", typeof(uint), new Type[0]);
            var il = method.GetILGenerator();
            il.Default<uint>();
            il.Emit(OpCodes.Ret);

            var func = (Func<uint>)method.CreateDelegate(typeof(Func<uint>));
            Assert.Equal((uint)0, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DefaultInt64()
        {
            var method = new DynamicMethod("x", typeof(long), new Type[0]);
            var il = method.GetILGenerator();
            il.Default<long>();
            il.Emit(OpCodes.Ret);

            var func = (Func<long>)method.CreateDelegate(typeof(Func<long>));
            Assert.Equal((long)0, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DefaultUInt64()
        {
            var method = new DynamicMethod("x", typeof(ulong), new Type[0]);
            var il = method.GetILGenerator();
            il.Default<ulong>();
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong>)method.CreateDelegate(typeof(Func<ulong>));
            Assert.Equal((ulong)0, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DefaultFloat()
        {
            var method = new DynamicMethod("x", typeof(float), new Type[0]);
            var il = method.GetILGenerator();
            il.Default<float>();
            il.Emit(OpCodes.Ret);

            var func = (Func<float>)method.CreateDelegate(typeof(Func<float>));
            Assert.Equal((float)0, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DefaultDouble()
        {
            var method = new DynamicMethod("x", typeof(double), new Type[0]);
            var il = method.GetILGenerator();
            il.Default<double>();
            il.Emit(OpCodes.Ret);

            var func = (Func<double>)method.CreateDelegate(typeof(Func<double>));
            Assert.Equal((double)0, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DefaultStruct()
        {
            var method = new DynamicMethod("x", typeof(Guid), new Type[0]);
            var il = method.GetILGenerator();
            il.Default<Guid>();
            il.Emit(OpCodes.Ret);

            var func = (Func<Guid>)method.CreateDelegate(typeof(Func<Guid>));
            Assert.Equal(Guid.Empty, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DefaultClass()
        {
            var method = new DynamicMethod("x", typeof(string), new Type[0]);
            var il = method.GetILGenerator();
            il.Default<string>();
            il.Emit(OpCodes.Ret);

            var func = (Func<string>)method.CreateDelegate(typeof(Func<string>));
            Assert.Null(func());
        }
    }
}
