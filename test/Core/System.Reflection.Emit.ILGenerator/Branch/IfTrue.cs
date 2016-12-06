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
        public void BranchIfTrue()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(bool) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchTo(elseLabel).IfTrue();
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
        public void BranchIfTrueShortForm()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(bool) });
            var il = method.GetILGenerator();
            var elseLabel = il.DefineLabel();
            var endLabel = il.DefineLabel();
            il.Emit(OpCodes.Ldarg_0);
            il.BranchShortTo(elseLabel).IfTrue();
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
    }
}
