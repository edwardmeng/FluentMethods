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
        public void BranchIfEqualToChar()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(char) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfEqualTo((char)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<char, bool>)method.CreateDelegate(typeof(Func<char, bool>));
            Assert.True(func((char)20));
            Assert.False(func((char)25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToCharShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(char) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfEqualTo((char)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<char, bool>)method.CreateDelegate(typeof(Func<char, bool>));
            Assert.True(func((char)20));
            Assert.False(func((char)25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToBoolean()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(bool) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfEqualTo(true);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<bool, bool>)method.CreateDelegate(typeof(Func<bool, bool>));
            Assert.True(func(true));
            Assert.False(func(false));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToBooleanShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(bool) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfEqualTo(true);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<bool, bool>)method.CreateDelegate(typeof(Func<bool, bool>));
            Assert.True(func(true));
            Assert.False(func(false));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToByte()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(byte) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfEqualTo((byte)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<byte, bool>)method.CreateDelegate(typeof(Func<byte, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToByteShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(byte) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfEqualTo((byte)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<byte, bool>)method.CreateDelegate(typeof(Func<byte, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToSByte()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(sbyte) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfEqualTo((sbyte)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<sbyte, bool>)method.CreateDelegate(typeof(Func<sbyte, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToSByteShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(sbyte) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfEqualTo((sbyte)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<sbyte, bool>)method.CreateDelegate(typeof(Func<sbyte, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToInt16()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(short) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfEqualTo((short)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<short, bool>)method.CreateDelegate(typeof(Func<short, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToInt16ShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(short) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfEqualTo((short)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<short, bool>)method.CreateDelegate(typeof(Func<short, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToUInt16()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ushort) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfEqualTo((ushort)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<ushort, bool>)method.CreateDelegate(typeof(Func<ushort, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToUInt16ShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ushort) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfEqualTo((ushort)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<ushort, bool>)method.CreateDelegate(typeof(Func<ushort, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToInt32()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(int) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfEqualTo(20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<int, bool>)method.CreateDelegate(typeof(Func<int, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToInt32ShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(int) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfEqualTo(20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<int, bool>)method.CreateDelegate(typeof(Func<int, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToUInt32()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfEqualTo((uint)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, bool>)method.CreateDelegate(typeof(Func<uint, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToUInt32ShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(uint) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfEqualTo((uint)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, bool>)method.CreateDelegate(typeof(Func<uint, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToInt64()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(long) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfEqualTo((long)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<long, bool>)method.CreateDelegate(typeof(Func<long, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToInt64ShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(long) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfEqualTo((long)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<long, bool>)method.CreateDelegate(typeof(Func<long, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToUInt64()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfEqualTo((ulong)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, bool>)method.CreateDelegate(typeof(Func<ulong, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToUInt64ShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(ulong) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfEqualTo((ulong)20);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<ulong, bool>)method.CreateDelegate(typeof(Func<ulong, bool>));
            Assert.True(func(20));
            Assert.False(func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToFloat()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(float) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfEqualTo((float)20.5);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<float, bool>)method.CreateDelegate(typeof(Func<float, bool>));
            Assert.True(func((float)20.5));
            Assert.False(func((float)25.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToFloatShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(float) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfEqualTo((float)20.5);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<float, bool>)method.CreateDelegate(typeof(Func<float, bool>));
            Assert.True(func((float)20.5));
            Assert.False(func((float)25.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToDouble()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(double) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfEqualTo(20.5);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<double, bool>)method.CreateDelegate(typeof(Func<double, bool>));
            Assert.True(func(20.5));
            Assert.False(func(25.5));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualToDoubleShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(double) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfEqualTo(20.5);
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<double, bool>)method.CreateDelegate(typeof(Func<double, bool>));
            Assert.True(func(20.5));
            Assert.False(func(25.5));
        }
    }
}
