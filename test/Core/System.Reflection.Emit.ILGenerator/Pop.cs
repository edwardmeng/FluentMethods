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
        public void Pop()
        {
            var method = new DynamicMethod("x", typeof(int), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(20);
            il.LoadConst(25);
            il.Pop();
            il.Emit(OpCodes.Ret);

            var func = (Func<int>)method.CreateDelegate(typeof(Func<int>));
            Assert.Equal(20, func());
        }
    }
}
