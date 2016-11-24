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
        public void BranchIfLessThanChar()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(char) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfLessThan((char)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<char, bool>)method.CreateDelegate(typeof(Func<char, bool>));
            Assert.True(func((char)15));
            Assert.False(func((char)20));
            Assert.False(func((char)25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanCharShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(char) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfLessThan((char)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<char, bool>)method.CreateDelegate(typeof(Func<char, bool>));
            Assert.True(func((char)15));
            Assert.False(func((char)20));
            Assert.False(func((char)25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanByte()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(byte) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfLessThan((byte)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<byte, bool>)method.CreateDelegate(typeof(Func<byte, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanByteShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(byte) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfLessThan((byte)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<byte, bool>)method.CreateDelegate(typeof(Func<byte, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanSByte()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(sbyte) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfLessThan((sbyte)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<sbyte, bool>)method.CreateDelegate(typeof(Func<sbyte, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanSByteShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(sbyte) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfLessThan((sbyte)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<sbyte, bool>)method.CreateDelegate(typeof(Func<sbyte, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanInt16()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(short) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfLessThan((short)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<short, bool>)method.CreateDelegate(typeof(Func<short, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanInt16ShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(short) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfLessThan((short)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<short, bool>)method.CreateDelegate(typeof(Func<short, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanUInt16()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ushort) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfLessThan((ushort)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<ushort, bool>)method.CreateDelegate(typeof(Func<ushort, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanUInt16ShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ushort) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfLessThan((ushort)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<ushort, bool>)method.CreateDelegate(typeof(Func<ushort, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanInt32()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(int) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfLessThan(20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<int, bool>)method.CreateDelegate(typeof(Func<int, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanInt32ShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(int) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfLessThan(20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<int, bool>)method.CreateDelegate(typeof(Func<int, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanUInt32()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfLessThan((uint)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, bool>)method.CreateDelegate(typeof(Func<uint, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanUInt32ShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfLessThan((uint)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, bool>)method.CreateDelegate(typeof(Func<uint, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanInt64()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(long) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfLessThan((long)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<long, bool>)method.CreateDelegate(typeof(Func<long, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanInt64ShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(long) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfLessThan((long)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<long, bool>)method.CreateDelegate(typeof(Func<long, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanUInt64()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfLessThan((ulong)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, bool>)method.CreateDelegate(typeof(Func<ulong, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanUInt64ShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfLessThan((ulong)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, bool>)method.CreateDelegate(typeof(Func<ulong, bool>));
            Assert.True(func(15));
            Assert.False(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanFloat()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(float) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfLessThan((float)20.5);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<float, bool>)method.CreateDelegate(typeof(Func<float, bool>));
            Assert.True(func((float)15.5));
            Assert.False(func((float)20.5));
            Assert.False(func((float)25.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanFloatShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(float) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfLessThan((float)20.5);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<float, bool>)method.CreateDelegate(typeof(Func<float, bool>));
            Assert.True(func((float)15.5));
            Assert.False(func((float)20.5));
            Assert.False(func((float)25.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanDouble()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(double) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfLessThan(20.5);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<double, bool>)method.CreateDelegate(typeof(Func<double, bool>));
            Assert.True(func(15.5));
            Assert.False(func(20.5));
            Assert.False(func(25.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfLessThanDoubleShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(double) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfLessThan(20.5);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<double, bool>)method.CreateDelegate(typeof(Func<double, bool>));
            Assert.True(func(15.5));
            Assert.False(func(20.5));
            Assert.False(func(25.5));
        }
    }
}
