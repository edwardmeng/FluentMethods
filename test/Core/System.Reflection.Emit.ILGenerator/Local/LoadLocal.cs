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
        public void LoadLocal()
        {
            var method = new DynamicMethod("x", typeof(int), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(int));
            il.LoadConst(20);
            il.Emit(OpCodes.Stloc, local);
            il.LoadLocal(local);
            il.Emit(OpCodes.Ret);

            var func = (Func<int>)method.CreateDelegate(typeof(Func<int>));
            Assert.Equal(20, func());
        }
    }
}
