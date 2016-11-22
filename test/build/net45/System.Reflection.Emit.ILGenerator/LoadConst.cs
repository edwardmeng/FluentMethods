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
        public void LoadConstInt32()
        {
            LoadConstInt32(-1);
            LoadConstInt32(0);
            LoadConstInt32(1);
            LoadConstInt32(2);
            LoadConstInt32(3);
            LoadConstInt32(4);
            LoadConstInt32(5);
            LoadConstInt32(6);
            LoadConstInt32(7);
            LoadConstInt32(8);
            LoadConstInt32(20);
            LoadConstInt32(200);
            LoadConstInt32(-200);
            LoadConstInt32(int.MinValue);
            LoadConstInt32(int.MaxValue);
        }

        private void LoadConstInt32(int value)
        {
            var method = new DynamicMethod("xm", typeof(int), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<int>)method.CreateDelegate(typeof(Func<int>));
            Assert.Equal(value, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadConstUInt32()
        {
            LoadConstUInt32(0);
            LoadConstUInt32(1);
            LoadConstUInt32(2);
            LoadConstUInt32(3);
            LoadConstUInt32(4);
            LoadConstUInt32(5);
            LoadConstUInt32(6);
            LoadConstUInt32(7);
            LoadConstUInt32(8);
            LoadConstUInt32(20);
            LoadConstUInt32(200);
            LoadConstUInt32((uint)int.MaxValue + 20);
            LoadConstUInt32(uint.MinValue);
            LoadConstUInt32(uint.MaxValue);
        }

        private void LoadConstUInt32(uint value)
        {
            var method = new DynamicMethod("xm", typeof(uint), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint>)method.CreateDelegate(typeof(Func<uint>));
            Assert.Equal(value, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadConstInt64()
        {
            LoadConstInt64(-1);
            LoadConstInt64(0);
            LoadConstInt64(1);
            LoadConstInt64(2);
            LoadConstInt64(3);
            LoadConstInt64(4);
            LoadConstInt64(5);
            LoadConstInt64(6);
            LoadConstInt64(7);
            LoadConstInt64(8);
            LoadConstInt64(20);
            LoadConstInt64(200);
            LoadConstInt64(-200);
            LoadConstInt64((long)int.MaxValue + 20);
            LoadConstInt64((long)int.MinValue - 20);
            LoadConstInt64(long.MaxValue);
            LoadConstInt64(long.MinValue);
        }

        private void LoadConstInt64(long value)
        {
            var method = new DynamicMethod("xm", typeof(long), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<long>)method.CreateDelegate(typeof(Func<long>));
            Assert.Equal(value, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadConstUInt64()
        {
            LoadConstUInt64(0);
            LoadConstUInt64(1);
            LoadConstUInt64(2);
            LoadConstUInt64(3);
            LoadConstUInt64(4);
            LoadConstUInt64(5);
            LoadConstUInt64(6);
            LoadConstUInt64(7);
            LoadConstUInt64(8);
            LoadConstUInt64(20);
            LoadConstUInt64(200);
            LoadConstUInt64((ulong)long.MaxValue + 20);
            LoadConstUInt64(ulong.MaxValue);
            LoadConstUInt64(ulong.MinValue);
        }

        private void LoadConstUInt64(ulong value)
        {
            var method = new DynamicMethod("xm", typeof(ulong), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong>)method.CreateDelegate(typeof(Func<ulong>));
            Assert.Equal(value, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadConstFloat()
        {
            LoadConstFloat(0);
            LoadConstFloat((float)0.5);
            LoadConstFloat(float.MaxValue);
            LoadConstFloat(float.MinValue);
        }

        private void LoadConstFloat(float value)
        {
            var method = new DynamicMethod("xm", typeof(float), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<float>)method.CreateDelegate(typeof(Func<float>));
            Assert.Equal(value, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadConstDouble()
        {
            LoadConstDouble(0);
            LoadConstDouble(0.5);
            LoadConstDouble(double.MaxValue);
            LoadConstDouble(double.MinValue);
        }

        private void LoadConstDouble(double value)
        {
            var method = new DynamicMethod("xm", typeof(double), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<double>)method.CreateDelegate(typeof(Func<double>));
            Assert.Equal(value, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadConstBoolean()
        {
            LoadConstBoolean(true);
            LoadConstBoolean(false);
        }

        private void LoadConstBoolean(bool value)
        {
            var method = new DynamicMethod("xm", typeof(bool), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<bool>)method.CreateDelegate(typeof(Func<bool>));
            Assert.Equal(value, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadConstChar()
        {
            LoadConstChar((char)0);
            LoadConstChar((char)32);
            LoadConstChar(char.MaxValue);
            LoadConstChar(char.MinValue);
        }

        private void LoadConstChar(char value)
        {
            var method = new DynamicMethod("xm", typeof(char), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<char>)method.CreateDelegate(typeof(Func<char>));
            Assert.Equal(value, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadConstByte()
        {
            LoadConstByte(0);
            LoadConstByte(20);
            LoadConstByte(byte.MaxValue);
            LoadConstByte(byte.MinValue);
        }

        private void LoadConstByte(byte value)
        {
            var method = new DynamicMethod("xm", typeof(byte), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<byte>)method.CreateDelegate(typeof(Func<byte>));
            Assert.Equal(value, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadConstSByte()
        {
            LoadConstSByte(0);
            LoadConstSByte(20);
            LoadConstSByte(-20);
            LoadConstSByte(sbyte.MinValue);
            LoadConstSByte(sbyte.MaxValue);
        }

        private void LoadConstSByte(sbyte value)
        {
            var method = new DynamicMethod("xm", typeof(sbyte), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<sbyte>)method.CreateDelegate(typeof(Func<sbyte>));
            Assert.Equal(value, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadConstString()
        {
            LoadConstString(null);
            LoadConstString(string.Empty);
            LoadConstString("Fizz");
        }

        private void LoadConstString(string value)
        {
            var method = new DynamicMethod("xm", typeof(string), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<string>)method.CreateDelegate(typeof(Func<string>));
            Assert.Equal(value, func());
        }


#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadConstDecimal()
        {
            LoadConstDecimal(0);
            LoadConstDecimal((decimal)12.345);
            LoadConstDecimal(decimal.MaxValue);
            LoadConstDecimal(decimal.MinValue);
            LoadConstDecimal(decimal.One);
            LoadConstDecimal(decimal.MinusOne);
            LoadConstDecimal(int.MaxValue);
            LoadConstDecimal(int.MinValue);
            LoadConstDecimal(long.MinValue);
            LoadConstDecimal(long.MaxValue);
        }

        private void LoadConstDecimal(decimal value)
        {
            var method = new DynamicMethod("xm", typeof(decimal), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<decimal>)method.CreateDelegate(typeof(Func<decimal>));
            Assert.Equal(value, func());
        }
    }
}
