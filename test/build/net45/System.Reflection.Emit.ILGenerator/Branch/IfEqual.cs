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
        public void BranchIfEqual()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(int), typeof(int) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.BranchTo(elseLabel).IfEqual();
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<int, int, bool>)method.CreateDelegate(typeof(Func<int, int, bool>));
            Assert.True(func(2, 2));
            Assert.False(func(2, 3));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BranchIfEqualShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(int), typeof(int) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.BranchShortTo(elseLabel).IfEqual();
            il.LoadConst(false);
            il.Emit(OpCodes.Br, endLabel);
            il.MarkLabel(elseLabel);
            il.LoadConst(true);
            il.MarkLabel(endLabel);
            il.Emit(OpCodes.Ret);

            var func = (Func<int, int, bool>)method.CreateDelegate(typeof(Func<int, int, bool>));
            Assert.True(func(2, 2));
            Assert.False(func(2, 3));
        }
    }
}
