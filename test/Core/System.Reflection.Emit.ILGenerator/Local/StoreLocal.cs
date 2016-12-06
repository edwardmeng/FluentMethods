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
        public void StoreLocal()
        {
            var method = new DynamicMethod("x", typeof(int), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(int));
            il.LoadConst(20);
            il.StoreLocal(local);
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<int>)method.CreateDelegate(typeof(Func<int>));
            Assert.Equal(20, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreLocalBoolean()
        {
            var method = new DynamicMethod("x", typeof(bool), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(bool));
            il.StoreLocal(local, true);
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<bool>)method.CreateDelegate(typeof(Func<bool>));
            Assert.Equal(true, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreLocalChar()
        {
            var method = new DynamicMethod("x", typeof(char), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(char));
            il.StoreLocal(local, (char)20);
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<char>)method.CreateDelegate(typeof(Func<char>));
            Assert.Equal((char)20, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreLocalByte()
        {
            var method = new DynamicMethod("x", typeof(byte), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(byte));
            il.StoreLocal(local, (byte)20);
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<byte>)method.CreateDelegate(typeof(Func<byte>));
            Assert.Equal((byte)20, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreLocalSByte()
        {
            var method = new DynamicMethod("x", typeof(sbyte), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(sbyte));
            il.StoreLocal(local, (sbyte)20);
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<sbyte>)method.CreateDelegate(typeof(Func<sbyte>));
            Assert.Equal((sbyte)20, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreLocalUInt16()
        {
            var method = new DynamicMethod("x", typeof(ushort), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(ushort));
            il.StoreLocal(local, (ushort)20);
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<ushort>)method.CreateDelegate(typeof(Func<ushort>));
            Assert.Equal((ushort)20, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreLocalInt16()
        {
            var method = new DynamicMethod("x", typeof(short), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(short));
            il.StoreLocal(local, (short)20);
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<short>)method.CreateDelegate(typeof(Func<short>));
            Assert.Equal((short)20, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreLocalInt32()
        {
            var method = new DynamicMethod("x", typeof(int), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(int));
            il.StoreLocal(local,(int)20);
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<int>)method.CreateDelegate(typeof(Func<int>));
            Assert.Equal(20, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreLocalUInt32()
        {
            var method = new DynamicMethod("x", typeof(uint), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(uint));
            il.StoreLocal(local, (uint)20);
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint>)method.CreateDelegate(typeof(Func<uint>));
            Assert.Equal((uint)20, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreLocalInt64()
        {
            var method = new DynamicMethod("x", typeof(long), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(long));
            il.StoreLocal(local, (long)20);
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<long>)method.CreateDelegate(typeof(Func<long>));
            Assert.Equal((long)20, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreLocalUInt64()
        {
            var method = new DynamicMethod("x", typeof(ulong), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(ulong));
            il.StoreLocal(local, (ulong)20);
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong>)method.CreateDelegate(typeof(Func<ulong>));
            Assert.Equal((ulong)20, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreLocalFloat()
        {
            var method = new DynamicMethod("x", typeof(float), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(float));
            il.StoreLocal(local, (float)20.5);
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<float>)method.CreateDelegate(typeof(Func<float>));
            Assert.Equal((float)20.5, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreLocalDouble()
        {
            var method = new DynamicMethod("x", typeof(double), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(double));
            il.StoreLocal(local, (double)20.5);
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<double>)method.CreateDelegate(typeof(Func<double>));
            Assert.Equal((double)20.5, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreLocalDecimal()
        {
            var method = new DynamicMethod("x", typeof(decimal), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(decimal));
            il.StoreLocal(local, (decimal)20.5);
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<decimal>)method.CreateDelegate(typeof(Func<decimal>));
            Assert.Equal((decimal)20.5, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreLocalString()
        {
            var method = new DynamicMethod("x", typeof(string), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(string));
            il.StoreLocal(local, "Fizz");
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<string>)method.CreateDelegate(typeof(Func<string>));
            Assert.Equal("Fizz", func());
        }
    }
}
