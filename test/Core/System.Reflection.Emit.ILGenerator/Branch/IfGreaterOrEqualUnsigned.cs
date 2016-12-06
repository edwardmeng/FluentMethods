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
        public void BranchIfGreaterOrEqualUnsignedUnsigned()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(uint), typeof(uint) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.BranchTo(elseLabel).IfGreaterOrEqualUnsigned();
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, uint, bool>)method.CreateDelegate(typeof(Func<uint, uint, bool>));
            Assert.True(func(3, 2));
            Assert.True(func(2, 2));
            Assert.False(func(2, 3));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfGreaterOrEqualUnsignedShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(uint), typeof(uint) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.BranchShortTo(elseLabel).IfGreaterOrEqualUnsigned();
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint, uint, bool>)method.CreateDelegate(typeof(Func<uint, uint, bool>));
            Assert.True(func(3, 2));
            Assert.True(func(2, 2));
            Assert.False(func(2, 3));
        }
    }
}
